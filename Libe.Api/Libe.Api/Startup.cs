using AutoMapper;
using Libe.Domain.Core.Entities;
using Libe.Infrastructure.Bussines.Mapper;
using Libe.Infrastructure.Bussines.Services;
using Libe.Infrastructure.Data.EF;
using Libe.Services.Interfaces.Interfaces;
using Libe.Services.Interfaces.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Libe.Api
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
            services.AddOptions<JwtOptions>();

            services.AddDbContext<ApiDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly("../Infrastructure/Libe.Infrastructure.Data")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApiDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["Auth:JwtAuth:Issuer"],
                        ValidAudience = Configuration["Auth:JwtAuth:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                        Convert.FromBase64String(Configuration["Auth:JwtAuth:SigningKey"]))
                    };
                });
            services.AddControllers();
            var mapConfiguration = new MapperConfiguration(ms =>
            {
                ms.AddProfile(new MapProfile());
            });
            IMapper mapper = mapConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Libe.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Libe.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
