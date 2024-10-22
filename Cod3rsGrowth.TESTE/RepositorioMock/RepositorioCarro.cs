using Cod3rsGrowth.DOMINIO.Carros;

namespace Cod3rsGrowth.TESTE.RepositorioMock
{
    public class RepositorioCarro : IRepositorioCarro
    {
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

        public List<Carro> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}