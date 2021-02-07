using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gopat.Crm.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Serilog;


namespace Gopat.Crm.Api
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
            services.AddDistributedMemoryCache();

            services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
                .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));


            if (Configuration.GetValue<string>("Env") == "Development")
            {
                Log.Information("Creating in memory db...");
                services.AddDbContext<GopatContext>(opt => opt.UseInMemoryDatabase("GoPat"));
            }
            else
            {
                Log.Information("Using SQL Server...");
                var connectionString = Configuration.GetValue<string>("ConnectionStrings:PetstarEpos");
                services.AddDbContext<GopatContext>(opt => opt.UseSqlServer(connectionString).LogTo(Log.Information));
            }

            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerDocument();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
