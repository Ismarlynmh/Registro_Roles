using Microsoft.EntityFrameworkCore.Migrations;

namespace Registro_Roles.Migrations
{
    public partial class Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aPermiso",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripción = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aPermiso", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "rPermiso",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PermisoId = table.Column<int>(type: "INTEGER", nullable: false),
                    EsAsignado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rPermiso", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "aPermisosDetalle",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "INTEGER", nullable: false),
                    PermisoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aPermisosDetalle", x => x.RolId);
                    table.ForeignKey(
                        name: "FK_aPermisosDetalle_aPermiso_RolId",
                        column: x => x.RolId,
                        principalTable: "aPermiso",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aPermisosDetalle_rPermiso_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "rPermiso",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aPermisosDetalle_PermisoId",
                table: "aPermisosDetalle",
                column: "PermisoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aPermisosDetalle");

            migrationBuilder.DropTable(
                name: "aPermiso");

            migrationBuilder.DropTable(
                name: "rPermiso");
        }
    }
}
