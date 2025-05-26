using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PRUEBA_OPERATI.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaPotenciaParticipante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PotenciasParticipantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ZonaPotencia = table.Column<string>(type: "text", nullable: false),
                    Participante = table.Column<string>(type: "text", nullable: false),
                    Subcuenta = table.Column<string>(type: "text", nullable: false),
                    CapacidadDemandadaMW = table.Column<double>(type: "double precision", nullable: false),
                    RequisitoAnualMWAnio = table.Column<double>(type: "double precision", nullable: false),
                    ValorRequisitoEficienteMWAnio = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotenciasParticipantes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PotenciasParticipantes");
        }
    }
}
