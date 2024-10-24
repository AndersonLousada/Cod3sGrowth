using System.Collections.Generic;

namespace Cod3rsGrowth.DOMINIO.Carros
{
    public class ServicoCarro
    {
        private readonly IRepositorioCarro _repositorio;

        public ServicoCarro(IRepositorioCarro repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Carro> ObterTodos(Filtro filtro)
        {
            return _repositorio.ObterTodos(filtro); 
        }
    }
}