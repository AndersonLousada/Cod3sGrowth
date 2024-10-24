using Cod3rsGrowth.DOMINIO.Carros;

namespace Cod3rsGrowth.TESTE.RepositorioMock
{
    public class RepositorioCarro : IRepositorioCarro
    {
        private readonly Singleton _singleton;
        public RepositorioCarro()
        {
            _singleton = Singleton.Instance;
        }

        public void Atualizar(Carro carro)
        {
            throw new NotImplementedException();
        }

        public void Criar(Carro carro)
        {
            throw new NotImplementedException();
        }

        public Carro ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Carro> ObterTodos(Filtro filtro)
        {
            var carros = _singleton.ObterCarros();

            if (!string.IsNullOrWhiteSpace(filtro.Modelo))
            {
                carros = carros.Where(carro => carro.Modelo.Equals(filtro.Modelo)).ToList();
            }

            return carros;
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

        internal void CarregarDadosParaTeste()
        {
            var carro = new Carro
            {
                Modelo = "147",
                Marca = "Fiat",
                AnoFabricacao = new DateTime(1985, 01, 01),
                AnoModelo = new DateTime(1986, 01, 01),
                ValorCusto = 15500m,
                ValorVenda = 25500m,
                Quitado = true,
                ProprietarioNome = "Kelvin",
                Combustivel = Combustivel.Etanol
            };

            var carro2 = new Carro
            {
                Modelo = "City",
                Marca = "Fiat",
                AnoFabricacao = new DateTime(1978, 01, 01),
                AnoModelo = new DateTime(1978, 01, 01),
                ValorCusto = 55500m,
                ValorVenda =85500m,
                Quitado = true,
                ProprietarioNome = "Alexandre",
                Combustivel = Combustivel.Etanol
            };

            _singleton.ObterCarros().Add(carro);
            _singleton.ObterCarros().Add(carro2);
        }

        internal void RemoverDadosDeTeste()
        {

            _singleton.ObterCarros().RemoveAll(x => x.Modelo != null);
        }
    }
}