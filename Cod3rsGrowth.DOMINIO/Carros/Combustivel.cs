using System.ComponentModel;

namespace Cod3rsGrowth.DOMINIO.Carros
{
    public enum Combustivel
    {
        [Description("Gasolina")]
        Gasolina,
        [Description("Flex - Etanol/Gasolina")]
        Flex,
        [Description("Etanol")]
        Etanol,
        [Description("Híbrido")]
        Hibrido,
        [Description("Elétrico")]
        Eletrico,
        [Description("Diesel")]
        Diesel
    }
}