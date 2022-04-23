
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Product.Sql.Context
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddProductDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, o => o.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .EnableDetailedErrors().EnableSensitiveDataLogging());

            return services;
        }

        public static async Task<IServiceCollection> ApplySqlDbMigrations(this IServiceCollection services)
        {
            try
            {
                var serviceProvider = services.BuildServiceProvider();

                var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
                if (context.Database.IsSqlServer())
                {
                    await context.Database.MigrateAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return services;
        }
    }
}
