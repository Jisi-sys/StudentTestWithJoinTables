
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Model;
using BusinessLayer.Services;
using DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;

namespace APIs
{
    public static class ServiceCollection
    {
        public static void ServicesForDAL(IServiceCollection services)
        {

            services.AddScoped<IStudentServices, StudentDAL>();
            services.AddScoped<ICourseServices, CourseDAL>();
            services.AddScoped<IBloodGroupServices, BloodGroupDAL>();
        }

    }
}
