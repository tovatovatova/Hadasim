﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COVID_19_Hadasim_.Migrations
{
    public partial class CHangeMemberKEY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Member",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_MemberId",
                table: "Member",
                column: "MemberId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_MemberId",
                table: "Member");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Member",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Id");
        }
    }
}
