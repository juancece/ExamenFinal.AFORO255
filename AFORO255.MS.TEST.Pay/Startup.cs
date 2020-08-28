using AFORO255.MS.TEST.Pay.RabbitMq.CommandHandlers;
using AFORO255.MS.TEST.Pay.RabbitMq.Commands;
using AFORO255.MS.TEST.Pay.Repository;
using AFORO255.MS.TEST.Pay.Repository.Data;
using AFORO255.MS.TEST.Pay.Service;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.AFORO255.Cross.RabbitMQ.Src;

namespace AFORO255.MS.TEST.Pay
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
            services.AddDbContext<ContextDatabase>(options =>
            {
                options.UseMySQL(Configuration["mysql:cn"]);
            });

            services.AddScoped<IRepositoryPay, RepositoryPay>();
            services.AddScoped<IServicePay, ServicePay>();
            services.AddScoped<IContextDatabase, ContextDatabase>();
            
            /* Start RabbitMA */
            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();
            services.AddTransient<IRequestHandler<PaymentCreateCommand, bool>, PaymentCommandHandler>();
            services.AddTransient<IRequestHandler<TransactionCreateCommand, bool>, TransactionCommandHandler>();
            /* End RabbitMQ */
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}