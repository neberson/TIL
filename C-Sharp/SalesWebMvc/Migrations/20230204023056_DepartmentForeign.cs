using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace SalesWebMvc.Migrations
{
    public partial class DepartmentForeign : Migration
    {
        public void UpdateSellerDepartmentIsEmpty(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE SELLER SET DEPARTMENTID = 1 WHERE DEPARTMENTID IS NULL OR DEPARTMENTID = ''");
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            UpdateSellerDepartmentIsEmpty(migrationBuilder);

           migrationBuilder.DropForeignKey(
                name: "FK_Seller_Department_DepartmentId",
                table: "Seller");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Seller",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Department_DepartmentId",
                table: "Seller",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Department_DepartmentId",
                table: "Seller");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Seller",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Department_DepartmentId",
                table: "Seller",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
