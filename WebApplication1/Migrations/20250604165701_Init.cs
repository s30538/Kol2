using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    TemperatureCelsius = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Washing_Machine",
                columns: table => new
                {
                    WashingMachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxWeight = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Washing_Machine", x => x.WashingMachineId);
                });

            migrationBuilder.CreateTable(
                name: "Available_Program",
                columns: table => new
                {
                    AvailableProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WashingMachineID = table.Column<int>(type: "int", nullable: false),
                    ProgramID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Available_Program", x => x.AvailableProgramID);
                    table.ForeignKey(
                        name: "FK_Available_Program_Program_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "Program",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Available_Program_Washing_Machine_WashingMachineID",
                        column: x => x.WashingMachineID,
                        principalTable: "Washing_Machine",
                        principalColumn: "WashingMachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_History",
                columns: table => new
                {
                    AvailableProgramID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_History", x => new { x.AvailableProgramID, x.CustomerID });
                    table.ForeignKey(
                        name: "FK_Purchase_History_Available_Program_AvailableProgramID",
                        column: x => x.AvailableProgramID,
                        principalTable: "Available_Program",
                        principalColumn: "AvailableProgramID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_History_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "123456789" },
                    { 2, "Jane", "Doe", "123456789" },
                    { 3, "Julie", "Doe", "123456789" }
                });

            migrationBuilder.InsertData(
                table: "Program",
                columns: new[] { "ProgramId", "DurationMinutes", "Name", "TemperatureCelsius" },
                values: new object[,]
                {
                    { 1, 10, "Created", 10 },
                    { 2, 10, "Ongoing", 10 },
                    { 3, 10, "Completed", 10 }
                });

            migrationBuilder.InsertData(
                table: "Washing_Machine",
                columns: new[] { "WashingMachineId", "MaxWeight", "SerialNumber" },
                values: new object[] { 1, 20.2m, "2134" });

            migrationBuilder.InsertData(
                table: "Available_Program",
                columns: new[] { "AvailableProgramID", "Price", "ProgramID", "WashingMachineID" },
                values: new object[] { 1, 10.23m, 1, 1 });

            migrationBuilder.InsertData(
                table: "Purchase_History",
                columns: new[] { "AvailableProgramID", "CustomerID", "PurchaseDate", "Rating" },
                values: new object[] { 1, 1, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Available_Program_ProgramID",
                table: "Available_Program",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Available_Program_WashingMachineID",
                table: "Available_Program",
                column: "WashingMachineID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_History_CustomerID",
                table: "Purchase_History",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase_History");

            migrationBuilder.DropTable(
                name: "Available_Program");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Washing_Machine");
        }
    }
}
