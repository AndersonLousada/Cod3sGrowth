using System;

namespace Cod3rsGrowth.DOMINIO.Carros
{
    public sealed class Carro
    {
        public int? Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public DateTime AnoModelo { get; set; }
        public DateTime AnoFabricacao { get; set; }
        public decimal ValorCusto { get; set; }
        public decimal? ValorVenda { get; set; }
        public decimal ValorOfertado { get; set; }
        public bool Quitado { get; set; } = false;
        public string ProprietarioNome { get; set; }
        public Combustivel Combustivel { get; set; }
    }
}