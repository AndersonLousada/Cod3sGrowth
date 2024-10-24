using Cod3rsGrowth.DOMINIO.Carros;
using Cod3rsGrowth.TESTE.RepositorioMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.TESTE
{
    public class TesteBase
    {
        protected readonly IServiceCollection _service;
        public TesteBase()
        {
            _service = DefinirInjecaoDeDependencia();
        }

        private IServiceCollection DefinirInjecaoDeDependencia()
        {
            var services = new ServiceCollection();

            services.AddScoped<IRepositorioCarro, RepositorioCarro>();
            services.AddScoped<ValidadorCarro>();
            services.AddScoped<ServicoCarro>();

            return services;
        }

        protected T GetService<T>() => _service.BuildServiceProvider().GetRequiredService<T>();

        internal void CarregarDadosParaTeste()
        {
            var repositorio = new RepositorioCarro();
            repositorio.CarregarDadosParaTeste();
        }

        internal void RemoverDadosDeTeste()
        {
            var repositorio = new RepositorioCarro();
            repositorio.RemoverDadosDeTeste();
        }
    }
}