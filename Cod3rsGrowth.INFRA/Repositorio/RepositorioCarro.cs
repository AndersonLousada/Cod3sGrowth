using Cod3rsGrowth.DOMINIO.Carros;
using LinqToDB;
using System.Collections.Generic;
using System.Linq;

namespace Cod3rsGrowth.INFRA.Repositorio
{
    public class RepositorioCarro : RepositorioBase, IRepositorioCarro
    {
        public void Atualizar(Carro carro)
        {
            Carro().Where(x => x.Id == carro.Id)
                .Set(x => x.Marca, carro.Marca)
                .Set(x => x.Modelo, carro.Modelo)
                .Set(x => x.AnoModelo, carro.AnoModelo)
                .Set(x => x.AnoFabricacao, carro.AnoFabricacao)
                .Set(x => x.Combustivel, carro.Combustivel)
                .Set(x => x.ValorCusto, carro.ValorCusto)
                .Set(x => x.ValorOfertado, carro.ValorOfertado)
                .Set(x => x.ValorVenda, carro.ValorVenda)
                .Set(x => x.ProprietarioNome, carro.ProprietarioNome)
                .Update();
        }

        public void Criar(Carro carro)
        {
            Conexao().Insert(carro);
        }

        public Carro ObterPorId(int id)
        {
            return Carro().FirstOrDefault(x => x.Id == id);
        }

        public List<Carro> ObterTodos(Filtro filtro)
        {
            var query = Carro();

            if (!string.IsNullOrWhiteSpace(filtro.Modelo))
            {
                query = query.Where(x => x.Modelo.Equals(filtro.Modelo)) as ITable<Carro>;
            }

            return query.ToList();
        }

        public void Remover(int id)
        {
            Carro().Where(x => x.Id == id).Delete();
        }

        private ITable<Carro> Carro()
        {
            return Conexao().GetTable<Carro>();
        }
    }
}