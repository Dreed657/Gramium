using Gramium.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Gramium.Data.Common;
using Gramium.Data.Common.Repositories;
using Gramium.Data.Models;
using Gramium.Data.Repositories;
using Gramium.Data.Seeding;
using Gramium.Services.Authentication;
using Gramium.Services.Data;
using Gramium.Services.Mapping;
using Gramium.Services.Messaging;
using Gramium.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Gramium.Api.Common;
using AutoMapper;
using Gramium.Services.Data.Posts;
using AutoMapper.Configuration;
using Gramium.Services.Data.Authentication.CurrentUser;
using Gramium.Web.Infrastructure.Filters;

namespace Gramium.Api
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        private MapperConfigurationExpression MapperConfig { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>(IdentityOptionsProvider.GetIdentityOptions)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var key = Encoding.ASCII.GetBytes(this.Configuration["Jwt:Secret"]);

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddControllers(options => 
                        options.Filters.Add<ModelOrNotFoundActionFilter>()
                    );
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gramium.Api", Version = "v1" });
            });

            services.AddSingleton<IMapper>(x => new Mapper(new MapperConfiguration(this.MapperConfig)));
            services.AddTransient<Microsoft.Extensions.Configuration.IConfiguration>(_ => this.Configuration);
            services.AddTransient<IApiConfig, ApiConfig>();

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IPostsService, PostsService>();

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.MapperConfig = AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gramium.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
