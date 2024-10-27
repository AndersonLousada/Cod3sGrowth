using FluentMigrator;

namespace Cod3rsGrowth.INFRA.Migracao
{
    [Migration(20241025185301)]
    public class _20241025185301_CriarTabelaCarro : Migration
    {
        public override void Up()
        {
            Create.Table("Carro")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Modelo").AsString().NotNullable()
                .WithColumn("Marca").AsString().NotNullable()
                .WithColumn("AnoModelo").AsDateTime().NotNullable()
                .WithColumn("AnoFabricacao").AsDateTime().NotNullable()
                .WithColumn("ValorCusto").AsDecimal().NotNullable()
                .WithColumn("ValorVenda").AsDecimal().NotNullable()
                .WithColumn("ValorOfertado").AsDecimal().NotNullable()
                .WithColumn("Quitado").AsBoolean().NotNullable()
                .WithColumn("ProprietarioNome").AsString().NotNullable()
                .WithColumn("Combustivel").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Carro");
        }
    }
}