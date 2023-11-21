using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Billing.RepositoryPattern.Domain.UnitOfWork;
using Billing.RepositoryPattern.InfraStructure.UnitOfWork;
using Billing.RepositoryPattern.InfraStructure;
using Billing.RepositoryPattern.Api.Services.UserService;
using Billing.RepositoryPattern.Api.Services.SalesService;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace Billing.RepositoryPattern.Api
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
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    ef => ef.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)),
                    ServiceLifetime.Scoped);

            services.AddControllers()
           .AddJsonOptions(o => o.JsonSerializerOptions
               .ReferenceHandler = ReferenceHandler.Preserve);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Billing.RepositoryPattern.Api", Version = "v1" });
            });

            services.AddControllersWithViews();
            services.AddHttpClient();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IMenuService), typeof(MenuService));
            services.AddTransient(typeof(ISalesService), typeof(SalesService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Billing.RepositoryPattern.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
