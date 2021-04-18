using Async_Inn.Data;
using Async_Inn.Data.Interfaces;
using Async_Inn.Models.Identity;
using Async_Inn.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn
{
    public class Startup
    {



        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AsyncInnDbContext>(options => {
                // Our DATABASE_URL from js days
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<AsyncInnDbContext>();

            services.AddTransient<IUserService, IdentityUserService>();
            services.AddTransient<JwtTokenService>();

            services.AddTransient<IHotel, HotelRepo>();
            services.AddTransient<IAmentity, AmentityRepo>();
            services.AddTransient<IRoom, RoomRepo>();
            services.AddTransient<IHotelRoom, HotelRoomRepo>();
            services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Async Inn",
                    Version = "v1",
                });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseSwagger(options => {
                options.RouteTemplate = "/api/{documentName}/swagger.json";

            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Async Inn lab");
                options.RoutePrefix = "";
              });

            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/hey", async context =>
                {
                    throw new InvalidOperationException("There is no Hey path. You utter fool. Pathetic. Get out of my sight.");
                });
                endpoints.MapGet("/", async context =>
                {
                    endpoints.MapControllers();
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
