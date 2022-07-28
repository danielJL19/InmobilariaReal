using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InmobilariaReal.Migrations
{
    public partial class migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    idcategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__140587C777A0F501", x => x.idcategoria);
                });

            migrationBuilder.CreateTable(
                name: "Reporte",
                columns: table => new
                {
                    id_reporte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reporte__87E4F5CB7B12C1E1", x => x.id_reporte);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false),
                    cant_pieza = table.Column<int>(type: "int", nullable: false),
                    cant_bano = table.Column<int>(type: "int", nullable: false),
                    idcategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__FF341C0D3B6E1AF8", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK_Categoria",
                        column: x => x.idcategoria,
                        principalTable: "Categoria",
                        principalColumn: "idcategoria");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_idcategoria",
                table: "Producto",
                column: "idcategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Reporte");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
