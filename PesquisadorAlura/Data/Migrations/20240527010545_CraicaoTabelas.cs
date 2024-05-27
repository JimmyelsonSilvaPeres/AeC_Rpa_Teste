using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CraicaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aec_consulta",
                columns: table => new
                {
                    con_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    con_texto_consulta = table.Column<string>(type: "TEXT", nullable: false),
                    Excecao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aec_consulta", x => x.con_id);
                });

            migrationBuilder.CreateTable(
                name: "aec_professor",
                columns: table => new
                {
                    pro_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pro_nome = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aec_professor", x => x.pro_id);
                });

            migrationBuilder.CreateTable(
                name: "aec_resultado",
                columns: table => new
                {
                    res_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    res_titulo = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    res_carga_horaria = table.Column<int>(type: "INTEGER", nullable: false),
                    res_descricao = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    res_con_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aec_resultado", x => x.res_id);
                    table.ForeignKey(
                        name: "FK_aec_resultado_aec_consulta_res_con_id",
                        column: x => x.res_con_id,
                        principalTable: "aec_consulta",
                        principalColumn: "con_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorResultado",
                columns: table => new
                {
                    ProfessoresId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResultadosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorResultado", x => new { x.ProfessoresId, x.ResultadosId });
                    table.ForeignKey(
                        name: "FK_ProfessorResultado_aec_professor_ProfessoresId",
                        column: x => x.ProfessoresId,
                        principalTable: "aec_professor",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorResultado_aec_resultado_ResultadosId",
                        column: x => x.ResultadosId,
                        principalTable: "aec_resultado",
                        principalColumn: "res_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aec_resultado_res_con_id",
                table: "aec_resultado",
                column: "res_con_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorResultado_ResultadosId",
                table: "ProfessorResultado",
                column: "ResultadosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessorResultado");

            migrationBuilder.DropTable(
                name: "aec_professor");

            migrationBuilder.DropTable(
                name: "aec_resultado");

            migrationBuilder.DropTable(
                name: "aec_consulta");
        }
    }
}
