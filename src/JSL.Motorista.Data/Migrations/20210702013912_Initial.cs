using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JSL.Motorista.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motorista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimeiroNome = table.Column<string>(type: "varchar(50)", nullable: true),
                    Caminhao_Marca = table.Column<string>(type: "varchar(50)", nullable: true),
                    Caminhao_Modelo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Caminhao_Placa = table.Column<string>(type: "varchar(50)", nullable: true),
                    Caminhao_Eixos = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorista", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motorista");
        }
    }
}
