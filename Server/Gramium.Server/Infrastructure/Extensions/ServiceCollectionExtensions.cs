using System.Text;
using Gramium.Server.Data;
using Gramium.Server.Data.Models;
using Gramium.Server.Features.Comments.Services;
using Gramium.Server.Features.Follows.Services;
using Gramium.Server.Features.Identity.Services;
using Gramium.Server.Features.Likes.Services;
using Gramium.Server.Features.Posts.Services;
using Gramium.Server.Features.Profiles.Services;
using Gramium.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Gramium.Server.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static AppSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<AppSettings>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<GramiumDbContext>(options => 
                    options.UseSqlServer(configuration.GetDefaultConnectionString())
                );
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<GramiumDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

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

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddTransient<ICommentsService, CommentsService>()
                .AddTransient<ILikesService, LikesService>()
                .AddTransient<IFollowsService, FollowsService>()
                .AddTransient<IProfileService, ProfileService>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<ICurrentUserService, CurrentUserService>()
                .AddTransient<IPostService, PostService>();
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "My Gramium API",
                        Version = "v1"
                    });
            });
        }

        public static IServiceCollection AddApiControllers(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSignalR();


            return services;
        }
    }
}
