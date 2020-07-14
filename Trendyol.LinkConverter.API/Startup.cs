using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Trendyol.LinkConverter.API.ErrorHandling;
using Trendyol.LinkConverter.Application;
using Trendyol.LinkConverter.EntityFramework;
using Trendyol.LinkConverter.EntityFramework.Interfaces;
using Trendyol.LinkConverter.EntityFramework.Repositories;

namespace Trendyol.LinkConverter.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>( c => c.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));
            services.AddScoped<IConverterHelper, ConverterHelper>();
            services.AddScoped<IShortLinkRepositorty, ShortLinkRepository>();
            services.AddScoped<IShortLinkConverter, ShortLinkConverter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if(error != null)
                    {
                        var ex = error.Error;

                        await context.Response.WriteAsync(new ErrorDetailModel()
                        {
                            Message = ex.Message,
                            StatusCode = 500

                        }.ToString());
                    }
                });
            });
        }
    }
}
