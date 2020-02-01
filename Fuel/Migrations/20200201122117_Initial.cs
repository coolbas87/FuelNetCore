using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fuel.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "dcID");

            migrationBuilder.CreateSequence<int>(
                name: "dfiID");

            migrationBuilder.CreateSequence<int>(
                name: "eofID");

            migrationBuilder.CreateSequence<int>(
                name: "eoflID");

            migrationBuilder.CreateSequence<int>(
                name: "eoID");

            migrationBuilder.CreateSequence<int>(
                name: "fuID");

            migrationBuilder.CreateTable(
                name: "dcDocuments",
                columns: table => new
                {
                    dcID = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR dcID"),
                    HIID = table.Column<byte[]>(rowVersion: true, nullable: true),
                    dcNo = table.Column<string>(maxLength: 35, nullable: false),
                    dcDate = table.Column<DateTime>(nullable: false),
                    dcType = table.Column<string>(maxLength: 20, nullable: false),
                    emID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 500, nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreateBy = table.Column<int>(nullable: false),
                    EditAt = table.Column<DateTime>(nullable: false),
                    EditBy = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dcDocuments", x => x.dcID);
                });

            migrationBuilder.CreateTable(
                name: "esfFuelTypes",
                columns: table => new
                {
                    fuID = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR fuID"),
                    HIID = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IsHasIncome = table.Column<bool>(nullable: false, defaultValue: false),
                    IsHasOutcome = table.Column<bool>(nullable: false, defaultValue: false),
                    IsHasRemains = table.Column<bool>(nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    CreateAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreateBy = table.Column<int>(nullable: false),
                    EditAt = table.Column<DateTime>(nullable: false),
                    EditBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_esfFuelTypes", x => x.fuID);
                });

            migrationBuilder.CreateTable(
                name: "mnEnergyObjects",
                columns: table => new
                {
                    eoID = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR eoID"),
                    HIID = table.Column<byte[]>(rowVersion: true, nullable: true),
                    eoCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreateBy = table.Column<int>(nullable: false),
                    EditAt = table.Column<DateTime>(nullable: false),
                    EditBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mnEnergyObjects", x => x.eoID);
                });

            migrationBuilder.CreateTable(
                name: "esfDailyFuelItems",
                columns: table => new
                {
                    dfiID = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR dfiID"),
                    HIID = table.Column<byte[]>(rowVersion: true, nullable: true),
                    dcID = table.Column<int>(nullable: false),
                    eoID = table.Column<int>(nullable: false),
                    fuID = table.Column<int>(nullable: false),
                    Income = table.Column<int>(nullable: false),
                    Outcome = table.Column<int>(nullable: false),
                    Remains = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreateBy = table.Column<int>(nullable: false),
                    EditAt = table.Column<DateTime>(nullable: false),
                    EditBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_esfDailyFuelItems", x => x.dfiID);
                    table.ForeignKey(
                        name: "FK_esfDailyFuelItems_dcDocuments_dcID",
                        column: x => x.dcID,
                        principalTable: "dcDocuments",
                        principalColumn: "dcID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_esfDailyFuelItems_mnEnergyObjects_eoID",
                        column: x => x.eoID,
                        principalTable: "mnEnergyObjects",
                        principalColumn: "eoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_esfDailyFuelItems_esfFuelTypes_fuID",
                        column: x => x.fuID,
                        principalTable: "esfFuelTypes",
                        principalColumn: "fuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mnEnergyObjectFiles",
                columns: table => new
                {
                    eoflID = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR eoflID"),
                    HIID = table.Column<byte[]>(rowVersion: true, nullable: true),
                    eoID = table.Column<int>(nullable: false),
                    Path = table.Column<string>(maxLength: 1024, nullable: false),
                    Filename = table.Column<string>(maxLength: 10, nullable: false),
                    DateFormat = table.Column<string>(maxLength: 10, nullable: false),
                    FileExt = table.Column<string>(maxLength: 3, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mnEnergyObjectFiles", x => x.eoflID);
                    table.ForeignKey(
                        name: "FK_mnEnergyObjectFiles_mnEnergyObjects_eoID",
                        column: x => x.eoID,
                        principalTable: "mnEnergyObjects",
                        principalColumn: "eoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mnEnergyObjectFuel",
                columns: table => new
                {
                    eofID = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR eofID"),
                    HIID = table.Column<byte[]>(rowVersion: true, nullable: true),
                    eoID = table.Column<int>(nullable: false),
                    fuID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mnEnergyObjectFuel", x => x.eofID);
                    table.ForeignKey(
                        name: "FK_mnEnergyObjectFuel_mnEnergyObjects_eoID",
                        column: x => x.eoID,
                        principalTable: "mnEnergyObjects",
                        principalColumn: "eoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mnEnergyObjectFuel_esfFuelTypes_fuID",
                        column: x => x.fuID,
                        principalTable: "esfFuelTypes",
                        principalColumn: "fuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_esfDailyFuelItems_dcID",
                table: "esfDailyFuelItems",
                column: "dcID");

            migrationBuilder.CreateIndex(
                name: "IX_esfDailyFuelItems_eoID",
                table: "esfDailyFuelItems",
                column: "eoID");

            migrationBuilder.CreateIndex(
                name: "IX_esfDailyFuelItems_fuID",
                table: "esfDailyFuelItems",
                column: "fuID");

            migrationBuilder.CreateIndex(
                name: "IX_mnEnergyObjectFiles_eoID",
                table: "mnEnergyObjectFiles",
                column: "eoID");

            migrationBuilder.CreateIndex(
                name: "IX_mnEnergyObjectFuel_eoID",
                table: "mnEnergyObjectFuel",
                column: "eoID");

            migrationBuilder.CreateIndex(
                name: "IX_mnEnergyObjectFuel_fuID",
                table: "mnEnergyObjectFuel",
                column: "fuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "esfDailyFuelItems");

            migrationBuilder.DropTable(
                name: "mnEnergyObjectFiles");

            migrationBuilder.DropTable(
                name: "mnEnergyObjectFuel");

            migrationBuilder.DropTable(
                name: "dcDocuments");

            migrationBuilder.DropTable(
                name: "mnEnergyObjects");

            migrationBuilder.DropTable(
                name: "esfFuelTypes");

            migrationBuilder.DropSequence(
                name: "dcID");

            migrationBuilder.DropSequence(
                name: "dfiID");

            migrationBuilder.DropSequence(
                name: "eofID");

            migrationBuilder.DropSequence(
                name: "eoflID");

            migrationBuilder.DropSequence(
                name: "eoID");

            migrationBuilder.DropSequence(
                name: "fuID");
        }
    }
}
