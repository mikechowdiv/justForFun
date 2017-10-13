using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class StudentRepo
    {
        public List<Student> GetAll()
        {
            using (StudentMgtSystemEntities context = new StudentMgtSystemEntities())
            {
                List<Student> li = new List<Student>();
                try
                {
                    var userlist = context.Students.ToList();
                    foreach (var item in userlist)
                    {
                        Student s1 = new Student();
                        s1.FirstName = item.FirstName;
                        s1.LastName = item.LastName;
                        s1.StudentId = item.StudentId;
                        s1.Major = item.Major;
                        s1.GPA = item.GPA;
                        li.Add(s1);
                    }
                    return li;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return li;
                }
            }
        }

        public bool Add(Student students)
        {
            using (StudentMgtSystemEntities context = new StudentMgtSystemEntities())
            {
                try
                {
                    context.Students.Add(students);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }

        public Student GetById(int id)
        {
            using (StudentMgtSystemEntities context = new StudentMgtSystemEntities())
            {
                Student obj = new Student();
                try
                {
                    obj = context.Students.FirstOrDefault(u => u.StudentId == id);
                    return obj;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return obj;
                }
            }
        }

        public bool Update(Student students)
        {
            using (StudentMgtSystemEntities context = new StudentMgtSystemEntities())
            {
                try
                {
                    context.Students.Attach(students);
                    context.Entry(students).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }

        public bool Delete(int id)
        {
            using (StudentMgtSystemEntities context = new StudentMgtSystemEntities())
            {
                try
                {
                    var s1 = context.Students.FirstOrDefault(u => u.StudentId == id);
                    context.Entry(s1).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }

    }
}
