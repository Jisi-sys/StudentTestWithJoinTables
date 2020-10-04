using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Model;
using System.Data;
using BusinessLayer.Services;

namespace DataAccessLayer
{
    public class CourseDAL :ICourseServices
    {
        DbConnectionOp dBConnectionOp = new DbConnectionOp();



        //-----GET ALL COURSE DETAILS------//
        public IEnumerable<Course> GetAllCourse()
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {

             new SqlParameter("@Action","SELECT")
            };
            using (var reader = dBConnectionOp.GetDataReader("CourseSP", parameters))
            {
                while (reader.Read())
                {
                    yield return new Course
                    {
                        CourseId = reader.IsDBNull("CourseId") ? 0 : reader.GetInt32("CourseId"),
                        CourseName = reader.IsDBNull("CourseName") ? string.Empty : reader.GetString("CourseName"),
                        Duration = reader.IsDBNull("Duration") ? string.Empty : reader.GetString("Duration")
                       
                    };

                }

            }

        }



        //-----GET COURSE BY ID------//


        public IEnumerable<Course> GetCourseById(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
               new SqlParameter("@cid",id),
               new SqlParameter("@Action", "SELECTBYID")
            };

            using (var reader = dBConnectionOp.GetDataReader("CourseSP", parameters))
            {
                while (reader.Read())
                {
                    yield return new Course
                    {
                        CourseId = reader.IsDBNull("CourseId") ? 0 : reader.GetInt32("CourseId"),
                        CourseName = reader.IsDBNull("CourseName") ? string.Empty : reader.GetString("CourseName"),
                        Duration = reader.IsDBNull("Duration") ? string.Empty : reader.GetString("Duration")

                    };

                }

            }
        }



        //-----ADD COURSE------//

        public void AddNewCourse(Course course)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
              {
                 new SqlParameter("@cname",course.CourseName),
                 new SqlParameter("@duration",course.Duration), 
                 new SqlParameter("@Action", "INSERT")
              };
            dBConnectionOp.ExecuteNonQuery("CourseSP", parameters);

        }



        //-----UPDATE COURSE------//

        public void UpdateCourse(int id,Course course)
        {
            List<SqlParameter> parameters = new List<SqlParameter>

            { 
                 new SqlParameter("@cname",course.CourseName),
                 new SqlParameter("@duration",course.Duration),
                 new SqlParameter("@Action", "UPDATE")
            };
            dBConnectionOp.ExecuteNonQuery("CourseSP", parameters);
        }


        //-----DELETE STUDENT------//

        public void DeleteCourse(int id)
        {

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                  new SqlParameter("@cid",id),
                  new SqlParameter("@Action", "DELETE")
            };
            dBConnectionOp.ExecuteNonQuery("CourseSP", parameters);

        }



    }
}
