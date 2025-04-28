using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Rental.DAC
{
    class imgDAC : IDisposable
    {
        MySqlConnection conn;

        public imgDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public bool AddProductImage(string pname, string fname)
        {
            string sql = "insert into product_img (prd_name, image) values(@prd_name, @fname)";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@prd_name", pname);
            cmd.Parameters.AddWithValue("@fname", fname);

            int iRowAffect = cmd.ExecuteNonQuery();
            return (iRowAffect > 0);

        }

        public bool AddProductBLOBImage(string pname, byte[] data)
        {
            string sql = "insert into product_img (prd_name, image) values(@prd_name, @image)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@prd_name", pname);

            cmd.Parameters.Add("@image", MySqlDbType.Blob);
            cmd.Parameters["@image"].Value = data;

            int iRowAffect = cmd.ExecuteNonQuery();
            return (iRowAffect > 0);
        }

        public bool DeleteProductImage(string pname)
        {
            string sql = "delete from product_img where prd_name = @pname";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@pname", pname);

            return (cmd.ExecuteNonQuery() > 0);
        }

        public string GetFilePath(string name)
        {
            string sql = "select image from product_img where prd_name = @name";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", name);
            if (cmd.ExecuteScalar() != null)
            {
                return cmd.ExecuteScalar().ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
