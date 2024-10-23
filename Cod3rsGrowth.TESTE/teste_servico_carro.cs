using Cod3rsGrowth.DOMINIO.Carros;
using FluentAssertions;

namespace Cod3rsGrowth.TESTE
{
    public class teste_servico_carro : TesteBase
    {
        private readonly ServicoCarro _servicoCarro;
        public teste_servico_carro()
        {
            _servicoCarro = GetService<ServicoCarro>();
        }

        [Fact]
        public void deve_retornar_lista_vazia_de_carros_ao_ObterTodos_com_filtro_invalido()
        {
            //Arrange
            CarregarDadosParaTeste();
            var filtro = new Filtro { Modelo = "Uno" };

            //Act
            var lista = _servicoCarro.ObterTodos(filtro);

            //Assert
            lista.Should().BeEmpty();
            lista.Count.Should().Be(0);
            lista.Should().NotContain(new Carro());
            RemoverDadosDeTeste();
        }
        
        [Fact]
        public void deve_retornar_lista_com_um_item_ao_ObterTodos_com_filtro_valido()
        {
            //Arrange
            CarregarDadosParaTeste();
            var filtro = new Filtro { Modelo = "147" };

            //Act
            var lista = _servicoCarro.ObterTodos(filtro);

            //Assert
            lista.Count.Should().Be(1);
            lista.First().Modelo.Should().Be("147");
            RemoverDadosDeTeste();
        }

        [Fact]
        public void deve_retornar_lista_de_carros_ao_ObterTodos_sem_filtro()
        {
            //Arrange
            CarregarDadosParaTeste();
            var filtro = new Filtro();

            //Act
            var lista = _servicoCarro.ObterTodos(filtro);

            //Assert
            lista.Count.Should().Be(2);
            RemoverDadosDeTeste();
        }
    }
} 