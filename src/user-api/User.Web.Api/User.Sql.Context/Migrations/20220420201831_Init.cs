using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Sql.Context.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Username" },
                values: new object[,]
                {
                    { new Guid("0a5ab071-edff-4462-b15d-44f5269e6271"), "Carl.test@email.com", "Carl", "carl.test" },
                    { new Guid("37b118cb-695e-4250-98be-44244c8395ce"), "Doe.test@email.com", "Doe", "doe.test" },
                    { new Guid("460b92b7-100f-4d96-88f9-4d5e9b2aa996"), "Tim.test@email.com", "Tim", "tim.test" },
                    { new Guid("d5929e69-55ed-4b31-8fe6-5829d0583b8c"), "Jane.test@email.com", "Jane", "jane.test" },
                    { new Guid("e4ecacf2-c3d0-474c-b035-d1c365be0962"), "John.test@email.com", "John", "john.test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
