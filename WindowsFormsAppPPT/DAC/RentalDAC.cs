using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace Rental.DAC
{
    class RentalDAC : IDisposable
    {


        MySqlConnection conn;

        public RentalDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public void RentalPrd(string cmpID, string empID, string[] prdIDs)
        {
            // rental insert 1건
            // rental_detail insert 여러건
            // product update 여러건
            // emp_rental insert 여러건

            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into rental (cmp_id, rent_startDate) values (@cmp_id, now());select last_insert_id();";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@cmp_id", cmpID);
                cmd.Transaction = trans;
                int newRentalID = Convert.ToInt32(cmd.ExecuteScalar());

                string sql = @"INSERT INTO rental_detail (rent_no, detail_no, prd_id, rent_price)
                                select @rent_no, @detail_no, @prd_id, price / grt_date from product where prd_id = @prd_id ";

                cmd.Parameters.Add("@rent_no", MySqlDbType.Int32);
                cmd.Parameters.Add("@detail_no", MySqlDbType.Int32);
                cmd.Parameters.Add("@prd_id", MySqlDbType.VarChar);

                cmd.CommandText = sql;

                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "insert into emp_rent (detail_no, emp_no, start_date) values (@detail_no, @emp_no, now())";
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.Parameters.AddWithValue("@emp_no", empID);
                cmd2.Parameters.Add("@detail_no", MySqlDbType.Int32);
                cmd2.Transaction = trans;


                string uSql = "update product set isRental = 'Y' where prd_id = @prd_id";
                MySqlCommand u_cmd = new MySqlCommand(uSql, conn);
                u_cmd.Transaction = trans;
                u_cmd.Parameters.Add("@prd_id", MySqlDbType.VarChar);

                

                for (int i = 0; i < prdIDs.Length; i++)
                {
                                   

                    cmd.Parameters["@detail_no"].Value = newRentalID.ToString() + (i + 1);
                    cmd.Parameters["@rent_no"].Value = newRentalID;
                    cmd.Parameters["@prd_id"].Value = prdIDs[i];
                    cmd.ExecuteNonQuery();

                    cmd2.Parameters["@detail_no"].Value = cmd.Parameters["@detail_no"].Value;
                    cmd2.ExecuteNonQuery();

                    
                    u_cmd.Parameters["@prd_id"].Value = prdIDs[i];
                    u_cmd.ExecuteNonQuery();

                    
                }



                trans.Commit();
            }

            catch (Exception err)
            {
                trans.Rollback();
                throw err;
            }

        }

        public DataTable GetAll() //대여가능 목록
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = @"SELECT prd_id, prd_name, C.name, built_cmp, built_date, (price / grt_date) rent_price
            FROM product P inner join common_code C on P.code = C.code
            WHERE isRental = 'N'";
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.Fill(ds, "Rentalabe");

            return ds.Tables["Rentalabe"];
        }

        public DataTable GetRentalable(string kinds, string txt) //대여가능 장비 검색
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            string sql=null;
            if (kinds == "제품명")
            {
                sql = @"SELECT prd_id, prd_name, C.name, built_cmp, built_date, (price / grt_date) rent_price
            FROM product P inner join common_code C on P.code = C.code
            WHERE isRental = 'N' and prd_name = @txt";
            }
            else if (kinds == "구분")
            {
                sql = @"SELECT prd_id, prd_name, C.name, built_cmp, built_date, (price / grt_date) rent_price
            FROM product P inner join common_code C on P.code = C.code
            WHERE isRental = 'N' and C.name = @txt";
            }
            else if (kinds == "제조사")
            {
                sql = @"SELECT prd_id, prd_name, C.name, built_cmp, built_date, (price / grt_date) rent_price
            FROM product P inner join common_code C on P.code = C.code
            WHERE isRental = 'N' and built_cmp = @txt";
            }

            da.SelectCommand = new MySqlCommand(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@txt", txt);
            da.Fill(ds, "Rentalabe");

            return ds.Tables["Rentalabe"];
        }

        public DataTable GetRentalAll(string id) // 고객사 별 대여중 장비 목록
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = $@"SELECT P.prd_id, prd_name, C.name, ER.emp_no, built_cmp, built_date, R.rent_startDate, (price / grt_date) rent_price
            FROM product P inner join common_code C on P.code = C.code
                           inner join rental_detail RD on P.prd_id = RD.prd_id
                           right outer join rental R on RD.rent_no = R.rent_no
                           right outer join emp_rent ER on RD.detail_no = ER.detail_no
            WHERE isRental = 'Y' and cmp_id ='{id}' and end_date is null
            GROUP BY prd_id";
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.Fill(ds, "Rentaling");

            return ds.Tables["Rentaling"];
        }
        
        public DataTable SearchRental(string id, string kinds, int value)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql;

            if (kinds == "렌탈번호")
            {
                sql = $@"SELECT P.prd_id, prd_name, C.name, ER.emp_no, built_cmp, built_date, R.rent_startDate, (price / grt_date) rent_price
            FROM product P inner join common_code C on P.code = C.code
                           inner join rental_detail RD on P.prd_id = RD.prd_id
                           right outer join rental R on RD.rent_no = R.rent_no
                           right outer join emp_rent ER on RD.detail_no = ER.detail_no
            WHERE isRental = 'Y' and cmp_id ='{id}' and end_date is null and R.rent_no = @value
            GROUP BY prd_id";

            }

            else
            {
                sql = $@"SELECT P.prd_id, prd_name, C.name, ER.emp_no, built_cmp, built_date, R.rent_startDate, (price / grt_date) rent_price
            FROM product P inner join common_code C on P.code = C.code
                           inner join rental_detail RD on P.prd_id = RD.prd_id
                           right outer join rental R on RD.rent_no = R.rent_no
                           right outer join emp_rent ER on RD.detail_no = ER.detail_no
            WHERE isRental = 'Y' and cmp_id ='{id}' and end_date is null and ER.emp_no = @value
            GROUP BY prd_id";
            }
            
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@value", value);
            da.Fill(ds, "Rentaling");

            return ds.Tables["Rentaling"];
        }

        public void QuitRental(string id) // 렌탈 해지
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                //product 테이블 update 1번 (Y를 N으로 변경)
                string sql = "update product set isRental = 'N' where prd_id=@prd_id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@prd_id", id);
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();

                //rental_detail 테이블 update 1번 (렌탈 종료날짜를 지정)
                cmd.CommandText = "update rental_detail set rent_endDate = now() where prd_id=@prd_id and rent_endDate is null";
                cmd.ExecuteNonQuery();

                //emp_rent 테이블 update 1번 ( prd_id 로  emp_rent 에서 detail_no 리턴)
                cmd.CommandText = "select detail_no from rental_detail where prd_id = @prd_id";
                int DNo = Convert.ToInt32(cmd.ExecuteScalar());

                //rent_no 로 emp_rent 에서 endDate 업데이트
                cmd.CommandText = "update emp_rent set end_date = now() where detail_no = @detail_no";
                cmd.Parameters.AddWithValue("@detail_no", DNo);
                cmd.ExecuteNonQuery();

                

                trans.Commit();
                
            }
            catch (Exception err)
            {
                trans.Rollback();
                throw err;
            }
                       
        }

        public void UpdateTot(string cmpid, int tot)
        {
            string sql = "update company set totPrice = @totPrice where cmp_id = @cmp_id ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@cmp_id", cmpid);
            cmd.Parameters.AddWithValue("@totPrice", tot);
            cmd.ExecuteNonQuery();
        }

        public void ChangeEmp(string cmpID, string ID, int empID) // 사용자 변경
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                //rental_detail 에서 prd_id로 detail_no 구하기
                string sql = "select detail_no from rental_detail where prd_id = @prd_id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@prd_id", ID);
                cmd.Transaction = trans;
                int DNo = Convert.ToInt32(cmd.ExecuteScalar());

                
                //emp_rent 에서 detail_no로 end_date 업데이트 
                cmd.CommandText = "update emp_rent set end_date = now() where detail_no = @detail_no";
                cmd.Parameters.AddWithValue("@detail_no", DNo);
                cmd.ExecuteNonQuery();

                //emp_rent 에 새로운 사번으로 insert (detail_no 그대로)
                cmd.CommandText = "insert into emp_rent (detail_no, emp_no, start_date) values (@detail_no, @emp_no, now())";
                cmd.Parameters.AddWithValue("@emp_no", empID);
                cmd.ExecuteNonQuery();



                trans.Commit();

            }
            catch (Exception err)
            {
                trans.Rollback();
                throw err;
            }
        }
    }
}
