using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ICourseServices
    {
        IEnumerable<Course> GetAllCourse();
        IEnumerable<Course> GetCourseById(int id);
        void AddNewCourse(Course course);
        void UpdateCourse(int id, Course course);
        void DeleteCourse(int id);
    }
}
