using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Sql.Context.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("5e2a9604-ad2a-4037-8d32-86c5e170ac7f"), "Chair description", "Chair", 25m },
                    { new Guid("7d2f8cb9-eb2b-407f-88d4-7e55dda8198d"), "Bed description", "Bed", 100m },
                    { new Guid("b46ac664-5b81-4cd5-b75c-c98fcb4f9e66"), "Tv description", "TV", 50m },
                    { new Guid("d3f37fa6-4a7a-407e-953b-71651f937fb8"), "Coffe description", "Coffe", 10m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
