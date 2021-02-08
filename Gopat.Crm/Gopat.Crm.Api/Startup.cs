using Gopat.Crm.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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


            if (Configuration.GetValue<string>("Env") == "Development")
            {
                Log.Information("Creating in memory db...");
                services.AddDbContext<GopatContext>(opt => opt.UseInMemoryDatabase("GoPat"));
            }
            else
            {
                Log.Information("Using SQL Server...");
                var connectionString = Configuration.GetValue<string>("ConnectionStrings:GoPat");
                services.AddDbContext<GopatContext>(opt => opt.UseSqlServer(connectionString).LogTo(Log.Information));
            }

            services.AddAutoMapper(typeof(Startup));


            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GopatContext dataContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Log.Information("Ensuring database exists...");
            dataContext.Database.EnsureCreated();

            app.UseSerilogRequestLogging(); // <-- Add this line

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
