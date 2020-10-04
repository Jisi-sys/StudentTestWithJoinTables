using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using DataAccessLayer.Common;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using BusinessLayer.Services;
using BusinessLayer.Model;

namespace DataAccessLayer
{
    public class StudentDAL : IStudentServices
    {
        DbConnectionOp dBConnectionOp = new DbConnectionOp();



        //-----GET ALL STUDENT DETAILS------//
        public IEnumerable<Student> GetAllStudent()
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {

             new SqlParameter("@Action","SELECT")
            };
            using (var reader = dBConnectionOp.GetDataReader("StudentSP", parameters))
            {
                while (reader.Read())
                {
                    yield return new Student
                    {
                        StudentID = reader.IsDBNull("StudentID") ? 0 : reader.GetInt32("StudentID"),
                        StudentName = reader.IsDBNull("StudentName") ? string.Empty : reader.GetString("StudentName"),
                        Age = reader.IsDBNull("Age") ? 0 : reader.GetInt32("Age"),
                        CourseId = reader.IsDBNull("CourseId") ? 0 : reader.GetInt32("CourseId"),
                        BloodGroupId = reader.IsDBNull("BloodGroupId") ? 0 : reader.GetInt32("BloodGroupId")
                    };
                }

            }

        }



        //-----GET STUDENT BY ID------//


        public IEnumerable<Student> GetStudentById(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
               new SqlParameter("@sid",id),
               new SqlParameter("@Action","SELECTBYID")
            };

            using(var reader = dBConnectionOp.GetDataReader("StudentSP", parameters))
            {
                while (reader.Read())
                {
                    yield return new Student
                    {
                        StudentID = reader.IsDBNull("StudentID") ? 0 : reader.GetInt32("StudentID"),
                        StudentName = reader.IsDBNull("StudentName") ? string.Empty : reader.GetString("StudentName"),
                        Age = reader.IsDBNull("Age") ? 0 : reader.GetInt32("Age"),
                        CourseId = reader.IsDBNull("CourseId") ? 0 : reader.GetInt32("CourseId"),
                        BloodGroupId = reader.IsDBNull("BloodGroupId") ? 0 : reader.GetInt32("BloodGroupId")
                    };

                }

            }
        }



        //-----ADD STUDENT------//

        public void AddNewStudent(Student student)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
              {
                    new SqlParameter("@name", student.StudentName),
                    new SqlParameter("@age",student.Age),
                    new SqlParameter("@courseid",student.CourseId),
                    new SqlParameter("@bloodgroupid",student.BloodGroupId),
                    new SqlParameter("@Action","INSERT")
              };
            dBConnectionOp.ExecuteNonQuery("StudentSP", parameters);

        }



        //-----UPDATE STUDENT------//

        public void UpdateStudent(int id, Student student)
        {
            List<SqlParameter> parameters = new List<SqlParameter>

                {
                    
                    new SqlParameter("@sid",student.StudentID),
                    new SqlParameter("@name", student.StudentName),
                    new SqlParameter("@age",student.Age),
                    new SqlParameter("@courseid",student.CourseId),
                    new SqlParameter("@bloodgroupid",student.BloodGroupId),
                    new SqlParameter("@Action","UPDATE")
                };
            dBConnectionOp.ExecuteNonQuery("StudentSP", parameters);
        }


        //-----DELETE STUDENT------//

        public void DeleteStudent(int id)
        {

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                  new SqlParameter("@sid",id),
                  new SqlParameter("@Action","DELETE")
            };
            dBConnectionOp.ExecuteNonQuery("StudentSP", parameters);

        }


    }

}

