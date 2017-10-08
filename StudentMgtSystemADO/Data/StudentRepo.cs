using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class StudentRepo
    {
        SqlCommand cmd;
        SqlConnection conn;

        public void openConnection()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
        }

        public StudentRepo()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString());
        }

        public DataTable GetAllData()
        {
            try
            {
                DataTable dt = new DataTable();
                openConnection();
                cmd = new SqlCommand("SELECT * FROM Student", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Student> GetAll()
        {
            DataTable dt = GetAllData();
            List<Student> studentList = new List<Student>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Student s1 = new Student();
                    s1.StudentId = Convert.ToInt32(dr["StudentId"].ToString());
                    s1.FirstName = Convert.ToString(dr["FirstName"].ToString());
                    s1.LastName = Convert.ToString(dr["LastName"].ToString());
                    s1.Major = Convert.ToString(dr["Major"].ToString());
                    s1.GPA = Convert.ToDecimal(dr["GPA"].ToString());
                    studentList.Add(s1);
                }
            }
            return studentList.ToList();
        }

        public bool Add(Student students)
        {
            if (students != null)
            {
                openConnection();
                string query = "INSERT INTO Student (FirstName,LastName,Major,GPA) VALUES(@FirstName,@LastName,@Major,@GPA)";
                cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@FirstName",students.FirstName);
                cmd.Parameters.AddWithValue("@LastName",students.LastName);
                cmd.Parameters.AddWithValue("@Major",students.Major);
                cmd.Parameters.AddWithValue("@GPA",students.GPA);
                cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }

        public Student GetById(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                openConnection();
                cmd = new SqlCommand("SELECT * FROM Student WHERE StudentID=" + id,conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                Student s1 = new Student();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        s1.StudentId = Convert.ToInt32(dr["StudentId"].ToString());
                        s1.FirstName = dr["FirstName"].ToString();
                        s1.LastName = dr["LastName"].ToString();
                        s1.Major = dr["Major"].ToString();
                        s1.GPA = Convert.ToDecimal(dr["GPA"].ToString());
                    }
                }
                return s1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Student students)
        {
            if (students != null)
            {
                openConnection();
                string query = "UPDATE Student SET FirstName=@FirstName, LastName=@LastName, Major=@Major, GPA=@GPA WHERE StudentId=@StudentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", students.StudentId);
                cmd.Parameters.AddWithValue("@FirstName",students.FirstName);
                cmd.Parameters.AddWithValue("@LastName",students.LastName);
                cmd.Parameters.AddWithValue("@Major",students.Major);
                cmd.Parameters.AddWithValue("@GPA",students.GPA);
                cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            if (id != 0)
            {
                openConnection();
                string query = "DELETE FROM Student WHERE StudentId=@StudentId";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@StudentId", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }
    }
}
