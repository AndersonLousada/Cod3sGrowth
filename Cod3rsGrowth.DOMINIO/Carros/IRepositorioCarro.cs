using System.Collections.Generic;

namespace Cod3rsGrowth.DOMINIO.Carros
{
    public interface IRepositorioCarro
    {
        public List<Carro> ObterTodos(Filtro filtro);
        public Carro? ObterPorId(int id);
        public void Atualizar(Carro carro); 
        public void Remover(int id);
        public void Criar(Carro carro);
    }
}