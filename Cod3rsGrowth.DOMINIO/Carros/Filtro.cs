
using System;

namespace Cod3rsGrowth.DOMINIO.Carros
{
    public sealed class Filtro
    {
        public string? Modelo { get; set; }
        public string? ProprietarioNome { get; set; }
        public DateTime AnoModelo { get; set; } = DateTime.MinValue;
        public decimal? ValorOfertado { get; set; }
        public Combustivel? Combustivel { get; set; }
    }
}