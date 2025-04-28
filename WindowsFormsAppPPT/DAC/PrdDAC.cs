using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Rental.DAC
{
    class Prd
    {
        
        public string PrdID { get; set; }
        public string Code { get; set; }
        public string PrdName { get; set; }

        public string BltCmp { get; set; }
        public string BltDate { get; set; }
        public string Price { get; set; }
        public int GrtDate { get; set; }
        public string BltCmpNum { get; set; }
                
    }
    class PrdDAC : IDisposable
    {
        MySqlConnection conn;

        public PrdDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetAll()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = @"SELECT prd_id, prd_name, C.name, built_cmp, price, built_date, grt_date, built_cmp_num, isRental
            FROM product P inner join common_code C on P.code = C.code";
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.Fill(ds, "Product");

            return ds.Tables["Product"];
        }

        public int Insert(Prd prd)
        {

            
                string sql = @"INSERT INTO product(prd_id, code, prd_name, built_cmp, built_date, price, grt_date, built_cmp_num)
                            VALUES (@prd_id, @code, @prd_name, @built_cmp, @built_date, @price, @grt_date, @built_cmp_num)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@prd_id", prd.PrdID);
                cmd.Parameters.AddWithValue("@code", prd.Code);
                cmd.Parameters.AddWithValue("@prd_name", prd.PrdName);
                cmd.Parameters.AddWithValue("@built_cmp", prd.BltCmp);
                cmd.Parameters.AddWithValue("@built_date", prd.BltDate);
                cmd.Parameters.AddWithValue("@price", prd.Price);
                cmd.Parameters.AddWithValue("@grt_date", prd.GrtDate);
                cmd.Parameters.AddWithValue("@built_cmp_num", prd.BltCmpNum);

                return cmd.ExecuteNonQuery();
            
            
        }

        public int Update(Prd prd)
        {
            string sql = @"UPDATE product SET code=@code, prd_name=@prd_name , built_cmp=@built_cmp, built_date=@built_date,
            price=@price, grt_date=@grt_date, built_cmp_num=@built_cmp_num WHERE prd_id=@prd_id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@prd_id", prd.PrdID);
            cmd.Parameters.AddWithValue("@code", prd.Code);
            cmd.Parameters.AddWithValue("@prd_name", prd.PrdName);
            cmd.Parameters.AddWithValue("@built_cmp", prd.BltCmp);
            cmd.Parameters.AddWithValue("@built_date", prd.BltDate);
            cmd.Parameters.AddWithValue("@price", prd.Price);
            cmd.Parameters.AddWithValue("@built_cmp_num", prd.BltCmpNum);
            cmd.Parameters.AddWithValue("@grt_date", prd.GrtDate);

            return cmd.ExecuteNonQuery();
        }

        public int Delete(string id)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE FROM product WHERE prd_id=@prd_id";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@prd_id", id);

            return cmd.ExecuteNonQuery();
        }

        public DataTable GetSearchPrd(string kinds, string txt) //조회하는 함수
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            if(kinds == "제품명")
            {
                kinds = "prd_name";
            }
            else if (kinds == "제품번호")
            {
                kinds = "prd_id";
            }
            else if (kinds == "구분")
            {
                kinds = "name";
            }
            else if (kinds == "제조사")
            {
                kinds = "built_cmp";
            }

            string sql = $@"SELECT prd_id, prd_name, C.name, built_cmp, price, built_date, grt_date, built_cmp_num
            FROM product P inner join common_code C on P.code = C.code WHERE {kinds} = @txt";
            da.SelectCommand = new MySqlCommand(sql, conn);
            
            da.SelectCommand.Parameters.AddWithValue("@txt", txt);
            da.Fill(ds, "SProduct");

            return ds.Tables["SProduct"];
        }

        public Prd GetPrdInfo(string id)
        {
            string sql = @"SELECT prd_id, prd_name, C.name, built_cmp, (price / grt_date) rent_price, built_date, grt_date, built_cmp_num, isRental
            FROM product P inner join common_code C on P.code = C.code
            WHERE prd_id = @prd_id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@prd_id", id);
            MySqlDataReader reader = cmd.ExecuteReader();

            Prd prd = new Prd();
            if (reader.Read())
            {
                prd.PrdID = reader["prd_id"].ToString();
                prd.PrdName = reader["prd_name"].ToString();
                prd.Code = reader["name"].ToString();
                prd.BltCmp = reader["built_cmp"].ToString();
                prd.Price = reader["rent_price"].ToString();
            }
            return prd;
        }


    }
}
