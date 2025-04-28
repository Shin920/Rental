using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.DAC

{
    class CommonDAC : IDisposable
    {
        MySqlConnection conn;

        public CommonDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetCommonCode(string category)
        {
            string sql = "SELECT Code, Name FROM common_code WHERE category = @category";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@category", category);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string GetCode(string name) // 공통코드 name 을 code로 변환하는 함수
        {
            string sql = "SELECT code FROM common_code WHERE name = @name";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", name);
            MySqlDataReader reader = cmd.ExecuteReader();
            string code = null;
            if (reader.Read())
            {
                 code = reader["code"].ToString();
            }

            return code;
        }
    }
}
