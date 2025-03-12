using FluentValidation;
using System;

namespace Cod3rsGrowth.DOMINIO.Carros
{
    public sealed class ValidadorCarro : AbstractValidator<Carro>
    {
        public ValidadorCarro()
        {
            RuleFor(carro => carro.Modelo)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo modelo deve ser informado");

            RuleFor(carro => carro.Marca)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo marca deve ser informado");

            RuleFor(carro => carro.AnoFabricacao)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo ano de fabricação deve ser informado");

            RuleFor(carro => carro.AnoModelo)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo ano de modelo deve ser informado");

            RuleFor(carro => carro)
                .Must(EhAnoDeCompraValido)
                .WithMessage("Ano de fabricação e modelo devem ser superiores a 2010");

            RuleFor(carro => carro)
                .Must(EhAnoFabricacaoValido)
                .WithMessage("Ano de fabricacao não deve ser maior que ano modelo");

            RuleFor(carro => carro.Combustivel)
                .IsInEnum()
                .WithMessage("Campo combustível deve ser informado");

            RuleFor(carro => carro.ProprietarioNome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome do proprietário deve ser informado");

            RuleFor(carro => carro.ValorCusto)
                .NotNull()
                .NotEmpty()
                .WithMessage("Custo do veículo deve ser informado");

            RuleFor(carro => carro.ValorOfertado)
                .NotNull()
                .NotEmpty()
                .WithMessage("Valor de oferta do veículo deve ser informado");
        }

        private bool EhAnoDeCompraValido(Carro carro)
        {
            return carro.AnoModelo.Year >= 2010 && carro.AnoFabricacao.Year >= 2010;
        }

        private bool EhAnoFabricacaoValido(Carro carro)
        {
            return carro.AnoModelo >= carro.AnoFabricacao;
        }
    }
}