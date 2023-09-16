﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProEShop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class V202309162046 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryFeatures",
                table: "CategoryFeatures");

            migrationBuilder.DropIndex(
                name: "IX_CategoryFeatures_CategoryId",
                table: "CategoryFeatures");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CategoryFeatures");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CategoryFeatures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryFeatures",
                table: "CategoryFeatures",
                columns: new[] { "CategoryId", "FeatureId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryFeatures",
                table: "CategoryFeatures");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "CategoryFeatures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CategoryFeatures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryFeatures",
                table: "CategoryFeatures",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFeatures_CategoryId",
                table: "CategoryFeatures",
                column: "CategoryId");
        }
    }
}
