using Cod3rsGrowth.DOMINIO.Carros;
using FluentAssertions;
using System;

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

        [Fact]
        public void deve_retornar_carro_ao_ObterPorId_com_id_valido()
        {
            //Arrange
            CarregarDadosParaTeste();
            const int id = 1;

            //Act
            var carro = _servicoCarro.ObterPorId(id);

            //Assert
            carro.Should().NotBeNull();
            carro.Id.Should().Be(id);
            RemoverDadosDeTeste();
        }

        [Fact]
        public void deve_retornar_excessao_ao_informar_id_invalido()
        {
            //Arrange
            CarregarDadosParaTeste();
            const int id = 3;

            // Act
            var exception = Assert.Throws<Exception>(() => _servicoCarro.ObterPorId(id));

            // Assert
            exception.Message.Should().Be($"Recurso n�o encontrado com Id: {id}");
            RemoverDadosDeTeste();
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_cadastrar_sem_informar_modelo()
        {
            //Arrange
            var carro = new Carro
            {
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01,01),
                AnoModelo = new DateTime(1990, 01,01),
                Combustivel = Combustivel.Gasolina,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Criar(carro));

            // Assert
            exception.Message.Should().Contain("Campo modelo deve ser informado");
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_cadastrar_sem_informar_marca()
        {
            //Arrange
            var carro = new Carro
            {
                Modelo = "Ipanema",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Gasolina,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Criar(carro));

            // Assert
            exception.Message.Should().Contain("Campo marca deve ser informado");
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_cadastrar_sem_informar_ano_fabricacao()
        {
            //Arrange
            var carro = new Carro
            {
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Gasolina,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Criar(carro));

            // Assert
            exception.Message.Should().Contain("Campo ano de fabrica��o deve ser informado");
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_cadastrar_sem_informar_ano_modelo()
        {
            //Arrange
            var carro = new Carro
            {
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01, 01),
                Combustivel = Combustivel.Gasolina,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Criar(carro));

            // Assert
            exception.Message.Should().Contain("Campo ano de modelo deve ser informado");
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_cadastrar_com_ano_de_fabricacao_invalido()
        {
            //Arrange
            var carro = new Carro
            {
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1991, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Gasolina,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Criar(carro));

            // Assert
            exception.Message.Should().Contain("Ano de fabricacao n�o deve ser maior que ano modelo");
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_cadastrar_sem_informar_combustivel()
        {
            //Arrange
            var carro = new Carro
            {
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Criar(carro));

            // Assert
            exception.Message.Should().Contain("Campo combust�vel deve ser informado");
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_cadastrar_sem_informar_nome_do_proprietario()
        {
            //Arrange
            var carro = new Carro
            {
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Gasolina,
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Criar(carro));

            // Assert
            exception.Message.Should().Contain("Nome do propriet�rio deve ser informado");
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_cadastrar_sem_informar_valorCusto()
        {
            //Arrange
            var carro = new Carro
            {
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Gasolina,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorOfertado = 25000m
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Criar(carro));

            // Assert
            exception.Message.Should().Contain("Custo do ve�culo deve ser informado");
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_cadastrar_sem_informar_valor_oferta()
        {
            //Arrange
            var carro = new Carro
            {
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Gasolina,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Criar(carro));

            // Assert
            exception.Message.Should().Contain("Valor de oferta do ve�culo deve ser informado");
        }

        [Fact]
        public void deve_cadastrar_veiculo_ao_informar_dodos_os_dados_obrigatorios()
        {
            //Arrange
            var carro = new Carro
            {
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Gasolina,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            _servicoCarro.Criar(carro);

            // Assert
            var lista = _servicoCarro.ObterTodos(new Filtro());
            lista.Count.Should().Be(1);
            RemoverDadosDeTeste();
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_atualizar_sem_informar_ano_fabricacao()
        {
            //Arrange
            _servicoCarro.Criar(new Carro
            {
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Etanol,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            });

            const int id = 4;
            var carroParaAtualizar = new Carro
            {
                Id = id,
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Gasolina,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Atualizar(carroParaAtualizar));

            //Assert
            exception.Message.Should().Contain("Campo ano de fabrica��o deve ser informado");
            RemoverDadosDeTeste();
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_atualizar_sem_informar_modelo()
        {
            //Arrange
            _servicoCarro.Criar(new Carro
            {
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Etanol,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            });

            const int id = 4;
            var carroParaAtualizar = new Carro
            {
                Id = id,
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Gasolina,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Atualizar(carroParaAtualizar));

            //Assert
            exception.Message.Should().Contain("Campo modelo deve ser informado");
            RemoverDadosDeTeste();
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_atualizar_sem_informar_marca()
        {
            //Arrange
            _servicoCarro.Criar(new Carro
            {
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Etanol,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            });

            const int id = 4;
            var carroParaAtualizar = new Carro
            {
                Id = id,
                Modelo = "Ipanema",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Gasolina,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Atualizar(carroParaAtualizar));

            //Assert
            exception.Message.Should().Contain("Campo marca deve ser informado");
            RemoverDadosDeTeste();
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_atualizar_sem_informar_nome_do_proprietario()
        {
            //Arrange
            _servicoCarro.Criar(new Carro
            {
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Etanol,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            });

            const int id = 4;
            var carroParaAtualizar = new Carro
            {
                Id = id,
                Modelo = "Ipanema",
                Marca = "Chevrolet",
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Gasolina,
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            var exception = Assert.Throws<FluentValidation.ValidationException>(() => _servicoCarro.Atualizar(carroParaAtualizar));

            //Assert
            exception.Message.Should().Contain("Nome do proprietário deve ser informado");
            RemoverDadosDeTeste();
        }

        [Fact]
        public void deve_atualizar_veiculo_ao_informar_veiculo_valido()
        {
            //Arrange
            const int id = 9;
            _servicoCarro.Criar(new Carro
            {
                Id = id,
                Modelo = "Ipanema",
                Marca = "Xevrolet", //Cadastrando nome da marca errado
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Etanol,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            });

            const string marca = "Chevrolet";
            var carroParaAtualizar = new Carro
            {
                Id = id,
                Modelo = "Ipanema",
                Marca = marca, //Realizando corre��o
                AnoFabricacao = new DateTime(1989, 01, 01),
                AnoModelo = new DateTime(1990, 01, 01),
                Combustivel = Combustivel.Gasolina,
                ProprietarioNome = "Kimura",
                Quitado = true,
                ValorCusto = 18000m,
                ValorOfertado = 25000m
            };

            // Act
            _servicoCarro.Atualizar(carroParaAtualizar);

            // Assert
            var carro = _servicoCarro.ObterPorId(id);
            carro.Marca.Should().Be(marca);
            RemoverDadosDeTeste();
        }

        [Fact]
        public void deve_retornar_excessao_ao_tentar_remover_informando_id_invalido()
        {
            //Arrange
            const int id = 8;
            CarregarDadosParaTeste();

            //Act
            var exception = Assert.Throws<Exception>(() => _servicoCarro.Remover(id));

            //Assert
            exception.Message.Should().Contain($"Recurso não encontrado com Id: {id}");
            RemoverDadosDeTeste();
        }

        [Fact]
        public void deve_remover_carro_ao_infoirmar_id_valido()
        {
            //Arrange
            const int id = 1;
            CarregarDadosParaTeste();

            //Act
            _servicoCarro.Remover(id);

            //Assert
            var exception = Assert.Throws<Exception>(() => _servicoCarro.ObterPorId(id));
            exception.Message.Should().Contain($"Recurso não encontrado com Id: {id}");
            RemoverDadosDeTeste();
        }
    }
} 