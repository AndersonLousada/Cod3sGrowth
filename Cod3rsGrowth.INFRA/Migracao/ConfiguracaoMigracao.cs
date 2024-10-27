using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

namespace Cod3rsGrowth.INFRA.Migracao
{
    public static class ConfiguracaoMigracao
    {
        public static void MigrationRun(this IServiceCollection service)
        {
            service.CreateServices().UpdateDatabase();
        }

        private static IServiceProvider CreateServices(this IServiceCollection service)
        {
            string constring = ConfigurationManager.ConnectionStrings["CONNECTION_STRING"].ConnectionString;

            return service
                .AddFluentMigratorCore()
                    .ConfigureRunner(rb => rb
                    .AddSqlServer()
                        .WithGlobalConnectionString(constring)
                        .ScanIn(typeof(_20241025185301_CriarTabelaCarro).Assembly).For.Migrations())
                    .AddLogging(lb => lb.AddFluentMigratorConsole())
                    .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(this IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}