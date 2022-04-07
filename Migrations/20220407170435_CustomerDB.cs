using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupProject.Migrations
{
    public partial class CustomerDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)

        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });


            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "UserName", "FirstName", "LastName", "Address", "Email" },
                values: new object[] { 1, "JJones", "John", "Jones", "2222 E Drive", "JJones@gmail.com" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
        }
    }

