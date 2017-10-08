using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Data
{
    public class StudentRepo
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        public List<Student> GetAll()
        {
            return this.db.Query<Student>("SELECT * FROM Student").ToList();
        }

        public Student GetById(int id)
        {
            return this.db.Query<Student>("SELECT * FROM Student WHERE StudentId=@StudentId",new { StudentId=id}).FirstOrDefault();
        }

        public bool Add(Student students)
        {
            try
            {
                string sql = "INSERT INTO Student(FirstName,LastName,Major,GPA) VALUES (@FirstName,@LastName,@Major,@GPA);SELECT CAST(SCOPE_IDENTITY() AS int)";
                var returnId = this.db.Query<int>(sql,students).SingleOrDefault();
                students.StudentId = returnId;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Student students, string ColumnName)
        {
            string query = "UPDATE Student SET " + ColumnName + "=@" + ColumnName + " WHERE StudentId=@StudentId";
            var count = this.db.Execute(query,students);
            return count > 0;
        }

        public bool Delete(int id)
        {
            var affectedRows = this.db.Execute("DELETE FROM Student WHERE StudentId=@StudentId", new{StudentId=@id});
            return affectedRows > 0;
        }
    }
}
