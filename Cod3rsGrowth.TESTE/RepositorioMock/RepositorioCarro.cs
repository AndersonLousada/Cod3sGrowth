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
            var carroBanco = _singleton.ObterCarros().First(x => x.Id.Equals(carro.Id));
            carroBanco.Modelo = carro.Modelo;
            carroBanco.Marca = carro.Marca;
            carroBanco.AnoModelo = carro.AnoModelo;
            carroBanco.AnoFabricacao = carro.AnoFabricacao;
            carroBanco.ValorCusto = carro.ValorCusto;
            carroBanco.ValorVenda = carro.ValorVenda;
            carroBanco.ValorOfertado = carro.ValorOfertado;
            carroBanco.Quitado = carro.Quitado;
            carroBanco.ProprietarioNome = carro.ProprietarioNome;
            carroBanco.Combustivel = carro.Combustivel;
        }

        public void Criar(Carro carro)
        {
            carro.Id = _singleton.ObterNovoId();
            _singleton.ObterCarros().Add(carro);
        }

        public Carro? ObterPorId(int id)
        {
            return _singleton.ObterCarros().FirstOrDefault(x => x.Id.Equals(id));
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
                Id = 1,
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
                Id = 2,
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