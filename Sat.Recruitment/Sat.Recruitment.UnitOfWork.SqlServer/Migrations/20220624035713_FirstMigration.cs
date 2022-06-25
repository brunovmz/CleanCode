using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sat.Recruitment.UnitOfWork.SqlServer.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(type: "varchar(50)", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "LastModifiedDate", "Money", "Name", "Phone", "UserType" },
                values: new object[] { 1, "Peru 2464", "Juan@marmol.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1234m, "Juan", "+5491154762312", "Normal" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "LastModifiedDate", "Money", "Name", "Phone", "UserType" },
                values: new object[] { 2, "Alvear y Colombres", "Franco.Perez@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112234m, "Franco", "+534645213542", "Premium" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "LastModifiedDate", "Money", "Name", "Phone", "UserType" },
                values: new object[] { 3, "Garay y Otra Calle", "Agustina@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112234m, "Agustina", "+534645213542", "SuperUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
