using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.DAC;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace Rental.DAC
{
    public class AS
    {
        public string Code { get; set; }

        public string StatusCode { get; set; }

        public string ProductID { get; set; }

        public string Detail { get; set; }
    }
   
    class AsDAC : IDisposable
    {
       
        MySqlConnection conn;

        public AsDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetAllAtAD() // 관리자 화면에서 AS현황 조회
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = @"select as_no, cmp_name, RD.prd_id, C.name, (select name from common_code where code = A.status) status, in_date, out_date, detail, grt_date
from after_service A inner join common_code C on A.code = C.code
					 inner join emp_rent ER on A.emp_rent_num = ER.emp_rent_num
                     inner join employee E on ER.emp_no = E.emp_no
                     inner join rental_detail RD on ER.detail_no = RD.detail_no
                     inner join product P on RD.prd_id = P.prd_id
                     inner join company CP on E.cmp_id = CP.cmp_id";
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.Fill(ds, "ASMgmt");

            return ds.Tables["ASMgmt"];
        }

        public DataTable GetAllAtCU(string id) // 고객사 화면에서 AS현황 조회 (고객사id 받음)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = @"select RD.detail_no, C.name, in_date, (select name from common_code where code = A.status) status, detail, out_date
from after_service A inner join common_code C on A.code = C.code
					 inner join emp_rent ER on A.emp_rent_num = ER.emp_rent_num
                     inner join employee E on ER.emp_no = E.emp_no
                     inner join rental_detail RD on ER.detail_no = RD.detail_no
                     inner join product P on RD.prd_id = P.prd_id
                     inner join company CP on E.cmp_id = CP.cmp_id
where E.cmp_id = @cmp_id";
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@cmp_id", id);
            da.Fill(ds, "ASList");

            return ds.Tables["ASList"];
        }

        public DataTable GetSearchASCU(string cmp_id, string code, string fdate, string tdate) // 고객사화면 조건별 AS현황 조회
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            string sql;

            if (code == "notAsp06")
            {
                sql = @"select RD.detail_no, C.name, in_date, (select name from common_code where code = A.status) status, detail, out_date
from after_service A inner join common_code C on A.code = C.code
					 inner join emp_rent ER on A.emp_rent_num = ER.emp_rent_num
                     inner join employee E on ER.emp_no = E.emp_no
                     inner join rental_detail RD on ER.detail_no = RD.detail_no
                     inner join product P on RD.prd_id = P.prd_id
                     inner join company CP on E.cmp_id = CP.cmp_id
where E.cmp_id = @cmp_id and status != 'Asp06' and in_date >= @fdate and in_date <= @tdate";
            }

            else
            {
                sql = @"select RD.detail_no, C.name, in_date, (select name from common_code where code = A.status) status, detail, out_date
from after_service A inner join common_code C on A.code = C.code
					 inner join emp_rent ER on A.emp_rent_num = ER.emp_rent_num
                     inner join employee E on ER.emp_no = E.emp_no
                     inner join rental_detail RD on ER.detail_no = RD.detail_no
                     inner join product P on RD.prd_id = P.prd_id
                     inner join company CP on E.cmp_id = CP.cmp_id
where E.cmp_id = @cmp_id and status = 'Asp06' and in_date >= @fdate and in_date <= @tdate";
            }
            da.SelectCommand = new MySqlCommand(sql, conn);

            da.SelectCommand.Parameters.AddWithValue("@cmp_id", cmp_id);
            da.SelectCommand.Parameters.AddWithValue("@fdate", fdate);
            da.SelectCommand.Parameters.AddWithValue("@tdate", tdate);
            da.Fill(ds, "SASCU");

            return ds.Tables["SASCU"];
            
        }
        #region AS건 검색 함수(관리자)
        public DataTable GetSearchASAD(string cmp_name, string code, string fdate, string tdate) //관리자 화면 조건별로 AS건 검색하는 함수
        {  
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            string sql;
            if (cmp_name == "전체")
            {
                if (code == "notAsp06") // 전체, 처리중
                {

                    sql = @"select as_no, cmp_name, RD.prd_id, C.name, (select name from common_code where code = A.status) status, in_date, out_date, detail, grt_date
                        from after_service A inner
                        join common_code C on A.code = C.code
                        inner join emp_rent ER on A.emp_rent_num = ER.emp_rent_num
                        inner join employee E on ER.emp_no = E.emp_no
                        inner join rental_detail RD on ER.detail_no = RD.detail_no
                        inner join product P on RD.prd_id = P.prd_id
                        inner join company CP on E.cmp_id = CP.cmp_id
                        where status != 'Asp06' and in_date >= @fdate and in_date <= @tdate ";
                }

                else // 전체, 처리완료
                {
                    sql = @"select as_no, cmp_name, RD.prd_id, C.name, (select name from common_code where code = A.status) status, in_date, out_date, detail, grt_date
                        from after_service A inner
                        join common_code C on A.code = C.code
                        inner join emp_rent ER on A.emp_rent_num = ER.emp_rent_num
                        inner join employee E on ER.emp_no = E.emp_no
                        inner join rental_detail RD on ER.detail_no = RD.detail_no
                        inner join product P on RD.prd_id = P.prd_id
                        inner join company CP on E.cmp_id = CP.cmp_id
                        where status = 'Asp06' and in_date >= @fdate and in_date <= @tdate ";
                }
                da.SelectCommand = new MySqlCommand(sql, conn);

                
                da.SelectCommand.Parameters.AddWithValue("@fdate", fdate);
                da.SelectCommand.Parameters.AddWithValue("@tdate", tdate);
                da.Fill(ds, "SAS");

                return ds.Tables["SAS"];
            }
            else // 특정 고객사 
            {
                if (code == "notAsp06") // 특정 고객사, 처리중
                {

                    sql = @"select as_no, cmp_name, RD.prd_id, C.name, (select name from common_code where code = A.status) status, in_date, out_date, detail, grt_date
                        from after_service A inner
                        join common_code C on A.code = C.code
                        inner join emp_rent ER on A.emp_rent_num = ER.emp_rent_num
                        inner join employee E on ER.emp_no = E.emp_no
                        inner join rental_detail RD on ER.detail_no = RD.detail_no
                        inner join product P on RD.prd_id = P.prd_id
                        inner join company CP on E.cmp_id = CP.cmp_id
                        where cmp_name = @cmp_name and status != 'Asp06' and in_date >= @fdate and in_date <= @tdate ";
                }

                else // 특정 고객사, 처리완료
                {
                    sql = @"select as_no, cmp_name, RD.prd_id, C.name, (select name from common_code where code = A.status) status, in_date, out_date, detail, grt_date
                        from after_service A inner
                        join common_code C on A.code = C.code
                        inner join emp_rent ER on A.emp_rent_num = ER.emp_rent_num
                        inner join employee E on ER.emp_no = E.emp_no
                        inner join rental_detail RD on ER.detail_no = RD.detail_no
                        inner join product P on RD.prd_id = P.prd_id
                        inner join company CP on E.cmp_id = CP.cmp_id
                        where cmp_name = @cmp_name and status = 'Asp06' and in_date >= @fdate and in_date <= @tdate ";
                }
                da.SelectCommand = new MySqlCommand(sql, conn);

                da.SelectCommand.Parameters.AddWithValue("@cmp_name", cmp_name);
                da.SelectCommand.Parameters.AddWithValue("@fdate", fdate);
                da.SelectCommand.Parameters.AddWithValue("@tdate", tdate);
                da.Fill(ds, "SAS");

                return ds.Tables["SAS"];
            }
        }
        #endregion

        public string PrintNum(string prd_id) // 선택한 셀에 따라 제조사 번호를 리턴 (CellClick 이벤트에 사용)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"select built_cmp_num from product where prd_id = '{prd_id}'";
            return cmd.ExecuteScalar().ToString();
        }

        public int ChangeStatus(string cmpid, string as_no, string code)
        {
            string sql;
            if (code == "Asp06")
            {
                
                sql = @"UPDATE after_service SET status = @code, out_date = now() WHERE as_no = @as_no";
                // 이메일 보내기
                bool result = SendMail(cmpid, GetEmailAddress(as_no));

            }
            else
            {
                sql = @"UPDATE after_service SET status = @code WHERE as_no = @as_no";
            }
            MySqlCommand cmd = new MySqlCommand(sql, conn);


            cmd.Parameters.AddWithValue("@code", code);
            cmd.Parameters.AddWithValue("@as_no", as_no);

            return cmd.ExecuteNonQuery();

        }

        public int GetEmpRentNum(string pid) // emp_rent_num 구하는 함수
        {

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $@"select emp_rent_num 
                                from emp_rent ER inner join rental_detail RD on ER.detail_no = RD.detail_no
                                where prd_id = '{pid}'";
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool isProcessing(string id)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select count(emp_rent_num) from after_service where emp_rent_num = @ern and out_date is null";
            cmd.Parameters.AddWithValue("@ern", GetEmpRentNum(id));
            int result = Convert.ToInt32(cmd.ExecuteScalar());

            return result > 0;

        }

        public void RegNewAs(AS asc) // After_service 테이블에 신규 데이터 삽입
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"insert into after_service (code, emp_rent_num, detail, in_date) 
                                values (@code, @emp_rent_num, @detail, @in_date)";
            cmd.Parameters.AddWithValue("@code", asc.Code);
            cmd.Parameters.AddWithValue("@emp_rent_num", GetEmpRentNum(asc.ProductID));
            cmd.Parameters.AddWithValue("@detail", asc.Detail);
            cmd.Parameters.AddWithValue("@in_date", DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();

        }

        #region 이메일 보내는 함수(개인정보 있음)
        private bool SendMail(string cmpname, string email)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false; //시스템에 설정된 인증 정보를 사용하지 않는다.
                client.EnableSsl = true; //SSL을 사용한다.
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("gurwls0920@gmail.com", "sin910920");

                MailAddress mailTo = new MailAddress(email);
                MailAddress mailFrom = new MailAddress("gurwls0920@gmail.com");

                MailMessage message = new MailMessage(mailFrom, mailTo);

                message.Subject = $"[알림] 접수해주신 A/S가 완료 되었습니다..";
                message.Body = $"안녕하세요.\n default입니다. 제품/소모품이 전달되기까지 영업일 기준 2~3일 소요됩니다.";

                message.SubjectEncoding = Encoding.UTF8;
                message.BodyEncoding = Encoding.UTF8;

                client.Send(message);

                return true;
            }
            catch 
            {
                
                return false;
            }
                        
        }
        #endregion

        public string GetEmailAddress(string asno)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select email from employee E inner join emp_rent ER on E.emp_no = ER.emp_no

                             inner join after_service AFS on ER.emp_rent_num = AFS.emp_rent_num
                             where as_no = @as_no; ";
            cmd.Parameters.AddWithValue("@as_no", asno);
            return cmd.ExecuteScalar().ToString();
            

        }

        public DataTable GetChartASKinds() //차트 사용을 위한 데이터테이블
        {
            string sql = @"select c.name, count(c.Name) count
                         from after_service A inner join common_code C on A.code = C.code
                         group by c.name order by count desc";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}
