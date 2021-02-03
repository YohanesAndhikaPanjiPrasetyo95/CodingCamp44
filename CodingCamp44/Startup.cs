using CodingCamp44.Context;
using CodingCamp44.JWT;
using CodingCamp44.Repositories.Data;
using CodingCamp44.Repositories.Interfaces;
using CodingCamp44.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingCamp44.Handler;

namespace CodingCamp44
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));

            services.AddScoped<RoleRepository>();
	        services.AddScoped<AccountRepository>();
            services.AddScoped<EducationRepository>();
            services.AddScoped<UniversityRepository>();
            services.AddScoped<ProfilingRepository>();
            services.AddScoped<PersonRepository>();
	        services.AddScoped<JobRepository>();
	        services.AddScoped<JobRepository>();

            services.JwtConfigure(Configuration);
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}");
            });
        }
    }
}