using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NumberMachine.Migrations
{
    public partial class AddNumberOutput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "n",
                table: "NumberInput",
                newName: "N");

            migrationBuilder.RenameColumn(
                name: "m",
                table: "NumberInput",
                newName: "M");

            migrationBuilder.CreateTable(
                name: "NumberOutput",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InputID = table.Column<int>(nullable: false),
                    Operation = table.Column<int>(nullable: false),
                    Output = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberOutput", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NumberOutput_NumberInput_InputID",
                        column: x => x.InputID,
                        principalTable: "NumberInput",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumberOutput_InputID",
                table: "NumberOutput",
                column: "InputID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumberOutput");

            migrationBuilder.RenameColumn(
                name: "N",
                table: "NumberInput",
                newName: "n");

            migrationBuilder.RenameColumn(
                name: "M",
                table: "NumberInput",
                newName: "m");
        }
    }
}
