using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Rental.DAC
{
    
    class Emp
    {
        public int EmpNo { get; set; }

        public string CmpID { get; set; }

        public string EmpName { get; set; }

        public string BirthDate { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
    class EmpDAC : IDisposable
    {
        MySqlConnection conn;

        public EmpDAC()
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

            string sql = "SELECT emp_no, emp_name, birth_date, phone, email FROM employee WHERE cmp_id = @cmp_id";
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@cmp_id", id);
            da.Fill(ds, "Employee");

            return ds.Tables["Employee"];
        }

        public int Insert(Emp emp)
        {
            string sql = @"INSERT INTO employee(emp_no, cmp_id, emp_name, birth_date, phone, email) 
                        VALUES (@emp_no, @cmp_id, @emp_name, @birth_date, @phone, @email)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@emp_no", emp.EmpNo);
            cmd.Parameters.AddWithValue("@cmp_id", emp.CmpID);
            cmd.Parameters.AddWithValue("@emp_name", emp.EmpName);
            cmd.Parameters.AddWithValue("@birth_date", emp.BirthDate);
            cmd.Parameters.AddWithValue("@phone", emp.Phone);
            cmd.Parameters.AddWithValue("@email", emp.Email);

            return cmd.ExecuteNonQuery();

        }

        public int Update(Emp emp)
        {
            string sql = "UPDATE employee SET emp_name=@emp_name, birth_date=@birth_date, phone=@phone, email=@email WHERE emp_no=@emp_no";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@emp_no", emp.EmpNo);
            cmd.Parameters.AddWithValue("@emp_name", emp.EmpName);
            cmd.Parameters.AddWithValue("@birth_date", emp.BirthDate);
            cmd.Parameters.AddWithValue("@phone", emp.Phone);
            cmd.Parameters.AddWithValue("@email", emp.Email);

            return cmd.ExecuteNonQuery();
        }

        public int Delete(int num)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE FROM employee WHERE emp_no=@emp_no";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@emp_no", num);

            return cmd.ExecuteNonQuery();
        }

        public DataTable GetSearchEmp(string kinds, string txt, string id)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();


            if (kinds == "이름")
            {
                kinds = "emp_name";

            }
            else if (kinds == "사번")
            {
                kinds = "emp_no";


            }
            string sql = $"SELECT emp_no, emp_name, birth_date, phone, email FROM employee WHERE {kinds} = @txt AND cmp_id = @id";
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@txt", txt);
            da.SelectCommand.Parameters.AddWithValue("@id", id);

            da.Fill(ds, "Employee");
            return ds.Tables["Employee"];

        }

        public bool isVaild(string cmp_id, string emp_id)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select count(emp_no) from employee where cmp_id = @cmp_id and emp_no = @emp_no";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@cmp_id", cmp_id);
            cmd.Parameters.AddWithValue("@emp_no", emp_id);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public DataTable GetSAll(string id) //신규 렌탈화면에서 사용
        {

            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = "select emp_name, emp_no from employee where cmp_id = @cmp_id;";
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@cmp_id", id);
            da.Fill(ds, "Employee");

            return ds.Tables["Employee"];
        }

        public DataTable GetSName(string id, string name)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = "select emp_name, emp_no from employee where cmp_id = @cmp_id and emp_name = @emp_name;";
            da.SelectCommand = new MySqlCommand(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@cmp_id", id);
            da.SelectCommand.Parameters.AddWithValue("@emp_name", name);
            da.Fill(ds, "Employee");

            return ds.Tables["Employee"];
        }
    }
}
