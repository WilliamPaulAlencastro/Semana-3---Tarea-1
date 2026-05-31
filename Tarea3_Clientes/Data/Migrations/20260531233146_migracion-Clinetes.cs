using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarea3_Clientes.Data.Migrations
{
    /// <inheritdoc />
    public partial class migracionClinetes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Tributaria = table.Column<int>(type: "int", nullable: false),
                    Num_Identificacion = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Razon_Social = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo_Postal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tiene_Credito = table.Column<bool>(type: "bit", nullable: false),
                    Creacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
