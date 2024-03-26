using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COVID_19_Hadasim_.Migrations
{
    public partial class removeRecTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recovery");

            migrationBuilder.AddColumn<DateTime>(
                name: "PositiveRes",
                table: "Member",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecoveryDate",
                table: "Member",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositiveRes",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "RecoveryDate",
                table: "Member");

            migrationBuilder.CreateTable(
                name: "Recovery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    PositiveRes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecoveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recovery", x => x.Id);
                });
        }
    }
}
