using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace Rental.DAC
{
    class EmpRentDAC : IDisposable
    {
        MySqlConnection conn;

        public EmpRentDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetAll(string id)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = @"select ER.emp_no, E.emp_name, RD.prd_id, start_date, end_date 
                           from emp_rent ER inner join rental_detail RD on ER.detail_no = RD.detail_no
			                                inner join employee E on ER.emp_no = E.emp_no
                           where cmp_id = @cmp_id
                           order by start_date";
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@cmp_id", id);
            da.Fill(ds, "Product");

            return ds.Tables["Product"];
        }

        public DataTable GetSAll(string id, string prdid)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = @"select ER.emp_no, E.emp_name, RD.prd_id, start_date, end_date 
                           from emp_rent ER inner join rental_detail RD on ER.detail_no = RD.detail_no
			                                inner join employee E on ER.emp_no = E.emp_no
                           where cmp_id = @cmp_id and RD.prd_id = @prd_id
                           order by start_date";
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@cmp_id", id);
            da.SelectCommand.Parameters.AddWithValue("@prd_id", prdid);
            da.Fill(ds, "Product");

            return ds.Tables["Product"];
        }
    }
}
