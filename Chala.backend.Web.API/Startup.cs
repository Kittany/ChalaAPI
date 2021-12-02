using Chala.backend.Core;
using Chala.backend.Core.IServices;
using Chala.backend.Data.SQL;
using Chala.backend.Services.Services;
using Chala.backend.Web.API.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chala.backend.Web.API
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                builder.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            services.AddDbContext<ChalaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("sqlCon"), b => b.MigrationsAssembly("Chala.backend.Data.SQL")));


            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UsersService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IRoutineService, RoutineService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<ITodoTaskService, TodoTaskService>();
            services.AddTransient<IForgotPasswordService, ForgotPasswordService>();
            services.AddTransient<IVerificationCodesService, VerificationCodesService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddHttpContextAccessor();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
