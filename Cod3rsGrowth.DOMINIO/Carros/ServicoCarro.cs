using FluentValidation;
using System;
using System.Collections.Generic;

namespace Cod3rsGrowth.DOMINIO.Carros
{
    public class ServicoCarro
    {
        private readonly IRepositorioCarro _repositorio;
        private readonly ValidadorCarro _validador;

        public ServicoCarro(IRepositorioCarro repositorio, ValidadorCarro validador)
        {
            _repositorio = repositorio;
            _validador = validador;
        }

        public List<Carro> ObterTodos(Filtro filtro)
        {
            return _repositorio.ObterTodos(filtro); 
        }

        public Carro ObterPorId(int id) 
        {
            return _repositorio.ObterPorId(id) ?? throw new Exception($"Recurso não encontrado com Id: {id}");
        }

        public void Criar(Carro carro) 
        {
            _validador.ValidateAndThrow(carro);
            _repositorio.Criar(carro);
        }

        public void Atualizar(Carro carro)
        {
            _validador.ValidateAndThrow(carro);
            ObterPorId((int)carro.Id!);
            _repositorio.Atualizar(carro);
        }

        public void Remover(int id)
        {
            var carro = ObterPorId(id);
            _repositorio.Remover((int)carro.Id!);
        }
    }
}