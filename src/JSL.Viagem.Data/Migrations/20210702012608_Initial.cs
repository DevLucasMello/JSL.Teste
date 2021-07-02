using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JSL.Viagem.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MotoristaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataHoraViajem = table.Column<DateTime>(type: "datetime", nullable: false),
                    LocalEntrega = table.Column<string>(type: "varchar(50)", nullable: false),
                    LocalSaida = table.Column<string>(type: "varchar(50)", nullable: false),
                    Km = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viagem");
        }
    }
}
