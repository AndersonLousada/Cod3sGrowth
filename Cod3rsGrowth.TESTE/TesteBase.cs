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

            //Escopo destinado para o uso do addScoped dos futuros serviços, validadores e repositórios

            return services;
        }

        protected T GetService<T>() => _service.BuildServiceProvider().GetRequiredService<T>();
    }
}