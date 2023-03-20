using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Km = table.Column<int>(type: "int", nullable: false),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "City", "Fuel", "ImagePath", "Km", "Name", "Price", "Transmission", "Year" },
                values: new object[,]
                {
                    { 1, "Kyiv", "Gasoline", "https://thumbs.img-sprzedajemy.pl/1000x901c/16/97/24/toyota-camry-hybrid-vi-2006-benzyna-slaskie-560029414.jpg", 300, "Toyota Camry", 7550m, "Manual", 2006 },
                    { 2, "Dnipro", "Diesel", "https://carteam.pl/img/53/53205/4929.jpg", 240, "Renault Megane", 7700m, "Manual", 2012 },
                    { 3, "Kiyv", "Diesel", "https://media.ed.edmunds-media.com/kia/sportage/2017/oem/2017_kia_sportage_4dr-suv_ex_fq_oem_1_1600.jpg", 99, "Kia Sportage", 17500m, "Robot", 2017 },
                    { 4, "Zhytomyr", "Diesel", "https://img.chceauto.pl/audi/q5/audi-q5-suv-3519-32981_head.jpg", 47, "Audi Q5", 59200m, "Automat", 2019 },
                    { 5, "Uzhhorod", "Diesel", "https://i.gaw.to/content/photos/10/97/109744_Porsche_Cayenne_Turbo_S_il_ne_fait_pas_dans_la_dentelle.jpg?460x287", 159, "Porsche Cayenne", 32500m, "Automat", 2013 },
                    { 6, "Kiyv", "Gasoline", "https://e7.pngegg.com/pngimages/968/736/png-clipart-car-ford-focus-electric-2013-ford-focus-2014-ford-focus-se-carrom-compact-car-sedan-thumbnail.png", 218, "Ford Focus", 6900m, "Automat", 2013 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
