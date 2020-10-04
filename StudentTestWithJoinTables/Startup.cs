
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DataAccessLayer;
using APIs.Controllers;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;

namespace APIs
{
    public class Startup
    {
        //protected string ConnectionString { get; set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication();
           services.AddScoped<IStudentServices, StudentDAL>();
           //services.ServicesForDAL(); 
            services.AddScoped<ICourseServices, CourseDAL>();
            services.AddScoped<IBloodGroupServices, BloodGroupDAL>();




            services.AddControllers();
            services.Configure<IISServerOptions>(options => { options.AutomaticAuthentication = false; });


            services.AddDirectoryBrowser();

            

            var connectionSection = Configuration.GetSection("ConnectionStrings").GetSection("DBConnectionString");
            services.Configure<ConnectionStrings>(connectionSection);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}

