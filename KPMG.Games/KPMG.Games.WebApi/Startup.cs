using KPMG.Games.Application.Application;
using KPMG.Games.Domain.Interfaces.Application;
using KPMG.Games.Domain.Interfaces.Repositories;
using KPMG.Games.Domain.Interfaces.Services;
using KPMG.Games.Infra.Data.Contexto;
using KPMG.Games.Infra.Data.Repositories;
using KPMG.Games.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KPMG.Games.WebApi
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
            services.AddMvc();
            services.AddControllers();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<KPGMGamesContext>(options =>
                {
                    options.UseSqlServer(Configuration["ConnectionString"],
                        sqlOptions => sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().
                        Assembly.GetName().Name));
                },
                ServiceLifetime.Scoped
            );

            services.AddScoped<IGameResultRepository, GameResultRepository>();
            services.AddScoped<IGameResultService, GameResultService>();
            services.AddScoped<IGameResultApplication, GameResultApplication>();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "KPMG Games",
                Version = "v1"
            }));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
