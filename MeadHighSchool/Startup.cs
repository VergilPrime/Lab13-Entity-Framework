﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeadHighSchool.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeadHighSchool
{
    public class Startup
    {
        // "Configuration" is a read-only property of type IConfiguration
        public IConfiguration Configuration { get; }

        // Constructor Method
        //When Startup is called in Program.cs. an IConfiguration must be passed in which gets placed in the "Configuration" property.
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        services.AddDbContext<StudentsDbContext>(options =>

                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(route => {
                route.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
