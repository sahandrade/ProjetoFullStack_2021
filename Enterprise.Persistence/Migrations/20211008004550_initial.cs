using Microsoft.EntityFrameworkCore.Migrations;

namespace Enterprise.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deptos",
                columns: table => new
                {
                    DeptoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sigla = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deptos", x => x.DeptoId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    FotoUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Rg = table.Column<string>(type: "TEXT", nullable: true),
                    DeptoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Deptos_DeptoId",
                        column: x => x.DeptoId,
                        principalTable: "Deptos",
                        principalColumn: "DeptoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Deptos",
                columns: new[] { "DeptoId", "Nome", "Sigla" },
                values: new object[] { 1, "Venda", "VEN" });

            migrationBuilder.InsertData(
                table: "Deptos",
                columns: new[] { "DeptoId", "Nome", "Sigla" },
                values: new object[] { 2, "Recurso Humanos", "RH" });

            migrationBuilder.InsertData(
                table: "Deptos",
                columns: new[] { "DeptoId", "Nome", "Sigla" },
                values: new object[] { 3, "Logistica", "LOG" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "DeptoId", "FotoUrl", "Nome", "Rg" },
                values: new object[] { 1, 1, "idfjidjf", "Marta Souza", "87878787" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "DeptoId", "FotoUrl", "Nome", "Rg" },
                values: new object[] { 6, 1, "idfjidjf", "João Cardoso", "87878787" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "DeptoId", "FotoUrl", "Nome", "Rg" },
                values: new object[] { 2, 2, "idfjidjf", "Leticia Muriel", "87878787" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "DeptoId", "FotoUrl", "Nome", "Rg" },
                values: new object[] { 3, 3, "idfjidjf", "Renato Silva", "87878787" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "DeptoId", "FotoUrl", "Nome", "Rg" },
                values: new object[] { 4, 3, "idfjidjf", "Noel Lucas Souza", "87878787" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "DeptoId", "FotoUrl", "Nome", "Rg" },
                values: new object[] { 5, 3, "idfjidjf", "Manoel Barbosa", "87878787" });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DeptoId",
                table: "Funcionarios",
                column: "DeptoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Deptos");
        }
    }
}
