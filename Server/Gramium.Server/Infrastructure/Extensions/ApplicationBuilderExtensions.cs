using Gramium.Server.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Gramium.Server.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUi(this IApplicationBuilder app)
        {
            return app
                .UseSwagger()
                .UseSwaggerUI(c => 
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gramium.Server v1")
                );
        }

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<GramiumDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
