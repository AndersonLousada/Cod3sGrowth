using Cod3rsGrowth.DOMINIO.Carros;
using Cod3rsGrowth.INFRA.Migracao;
using Cod3rsGrowth.INFRA.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static IServiceProvider serviceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            //Mentores foi feito a injeção aqui, porém se preferir podem pedir para criarem o modulo do injeção na camada correspondente
            var service = new ServiceCollection();
            service.AddScoped<IRepositorioCarro, RepositorioCarro>();
            service.AddScoped<ListaDeCarros>();
            service.MigrationRun();
            serviceProvider = service.BuildServiceProvider();

            Application.Run(serviceProvider.GetRequiredService<ListaDeCarros>());
        }
    }
}