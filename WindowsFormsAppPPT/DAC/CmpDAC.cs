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
    public class Cmp
    {
        public string CmpID { get; set; }

        public string CmpName { get; set; }

        public string Password { get; set; }

        public string IsAdmin { get; set; }

    }
    public class CmpDAC : IDisposable
    {
        MySqlConnection conn;
        public CmpDAC()
        {
            string strConn = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            conn = new MySqlConnection(strConn);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        //Company 정보 반환
        public Cmp GetCmpInfo(string cmpID)
        {

            string sql = "SELECT cmp_id, password, cmp_name, isAdmin FROM company WHERE cmp_id = @cmpID";    
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@cmpid", cmpID);
            MySqlDataReader reader = cmd.ExecuteReader();

            Cmp cp = null;
            if (reader.Read())
            {
                cp = new Cmp();
                cp.CmpID = reader["cmp_id"].ToString();
                cp.Password = reader["password"].ToString();
                cp.CmpName = reader["cmp_name"].ToString();
                cp.IsAdmin = reader["isAdmin"].ToString();

            }

            return cp;

        }

        public DataTable GetAll()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            

            string sql = "SELECT cmp_id, cmp_name, password, totPrice FROM company WHERE isAdmin = 'N'";
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.Fill(ds, "Company");

            return ds.Tables["Company"];
        }

        public int Insert(Cmp cp)
        {
            string sql = "INSERT INTO company(cmp_id, cmp_name, password) VALUES (@cmp_id, @cmp_name, @password)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@cmp_id", cp.CmpID);
            cmd.Parameters.AddWithValue("@cmp_name", cp.CmpName);
            cmd.Parameters.AddWithValue("@password", cp.Password);

            return cmd.ExecuteNonQuery();
        }

        public int Update(Cmp cp)
        {
            string sql = @"UPDATE company SET cmp_id=@cmp_id, cmp_name=@cmp_name, password=@password WHERE cmp_id=@cmp_id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@cmp_id", cp.CmpID);
            cmd.Parameters.AddWithValue("@cmp_name", cp.CmpName);
            cmd.Parameters.AddWithValue("@password", cp.Password);

            return cmd.ExecuteNonQuery();
        }

        public int Delete(string id)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE FROM company WHERE cmp_id=@pmp_id";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@cmp_id", id);

            return cmd.ExecuteNonQuery();
        }

        public DataTable GetSearchCmp(string kinds, string txt)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            if (kinds == "고객사명")
            {
                kinds = "cmp_name";
            }
            else if (kinds == "고객사코드")
            {
                kinds = "cmp_id";
            }

            string sql = $"SELECT cmp_id, cmp_name, password, totPrice FROM company WHERE {kinds} = @txt AND isAdmin = 'N'";
            da.SelectCommand = new MySqlCommand(sql, conn);

            da.SelectCommand.Parameters.AddWithValue("@txt", txt);
            da.Fill(ds, "Company");

            return ds.Tables["Company"];
        }

        public bool isExist(string id)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select count(*) from company where cmp_id=@cmp_id";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@cmp_id", id);
            return (Convert.ToInt32(cmd.ExecuteScalar()) > 0); 
        }
    }
}

