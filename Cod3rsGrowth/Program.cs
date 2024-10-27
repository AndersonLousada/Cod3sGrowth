using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            //Mentores foi feito a injeção aqui, porém se preferir podem pedir para criarem o modulo do injeção na camada correspondente
            var serviceCollection = new ServiceCollection();

            Application.Run(new Form1());
        }
    }
}