using AFORO255.MS.TEST.Security.Repository;
using AFORO255.MS.TEST.Security.Repository.Data;
using AFORO255.MS.TEST.Security.Service;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.AFORO255.Cross.Consul.Consul;
using MS.AFORO255.Cross.Consul.Mvc;
using MS.AFORO255.Cross.Jwt.Src;

namespace AFORO255.MS.TEST.Security
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
             /* Start Jwt */
            services.AddJwtCustomized();
            services.Configure<JwtOptions>(Configuration.GetSection("jwt"));
            /* End Jwt */
            
            services.AddDbContext<ContextDatabase>(options =>
            {
                options.UseSqlServer(Configuration["cnsql"]);
            });
            services.AddControllers();
            services.AddScoped<IRepositoryAccess, RepositoryAccess>();
            services.AddScoped<IServiceAccess, ServiceAccess>();
            services.AddScoped<IContextDatabase, ContextDatabase>();
            
            /* Start Consul */
            services.AddSingleton<IServiceId, ServiceId>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddConsul();
            /* End Consul */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHostApplicationLifetime hostApplicationLifetime, IConsulClient consulClient)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            var serviceId = app.UseConsul();
            hostApplicationLifetime.ApplicationStopped.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(serviceId);
            });
        }
    }
}