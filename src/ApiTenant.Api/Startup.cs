using ApiTenant.Api.Filters;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiTenant.Api
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
            services.AddHttpContextAccessor();

            services.AddSingleton<IDataAccess, MemoryDataAccess>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("oi", new OpenApiInfo { Title = "OI API", Version = "v1" });
                c.SwaggerDoc("btc", new OpenApiInfo { Title = "BTC API", Version = "v1" });
                c.SwaggerDoc("common", new OpenApiInfo { Title = "Common API", Version = "v1" });
                c.SwaggerDoc("vodafone", new OpenApiInfo { Title = "Vodafone API", Version = "v1" });
            });


            services.AddControllers(opt =>
            {
                opt.Filters.Add(new Auth());
                opt.Filters.Add(new ExceptionFilter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapFallbackToController("api/{controller}/{action}", endpoints.ServiceProvider.GetServices<HttpContext>()., "");
                endpoints.MapControllers();
            });

            app.UseSwagger();

            this.SwaggerEndpointsFactory(app);
        }

        public void SwaggerEndpointsFactory(IApplicationBuilder app)
        {
            var tenantDeploy = this.Configuration.GetValue<string>("TenantDeploy:Name");

            if(tenantDeploy == Tenants.Oi)
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/oi/swagger.json", "Oi Partner API");
                    c.SwaggerEndpoint("/swagger/common/swagger.json", "Common API");
                });
            }
            else if (tenantDeploy == Tenants.Btc)
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/btc/swagger.json", "BTC Partner API");
                    c.SwaggerEndpoint("/swagger/common/swagger.json", "Common API");
                });
            }
            else if (tenantDeploy == Tenants.Vodafone)
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/common/swagger.json", "Common API");
                    c.SwaggerEndpoint("/swagger/vodafone/swagger.json", "VodaFone Partner API");
                });
            }
            else
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/oi/swagger.json", "Oi Partner API");
                    c.SwaggerEndpoint("/swagger/btc/swagger.json", "BTC Partner API");
                    c.SwaggerEndpoint("/swagger/common/swagger.json", "Common API");
                    c.SwaggerEndpoint("/swagger/vodafone/swagger.json", "VodaFone Partner API");
                });
            }
        }
    }
}