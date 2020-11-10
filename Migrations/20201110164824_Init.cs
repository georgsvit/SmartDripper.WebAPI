using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDripper.WebAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    SymptomUk = table.Column<string>(nullable: true),
                    SymptomUa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserIdentity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIdentity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalProtocols",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MaxTemp = table.Column<double>(nullable: false),
                    MinTemp = table.Column<double>(nullable: false),
                    MaxPulse = table.Column<int>(nullable: false),
                    MinPulse = table.Column<int>(nullable: false),
                    MaxBloodPressure = table.Column<int>(nullable: false),
                    MinBloodPressure = table.Column<int>(nullable: false),
                    DiseaseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalProtocols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalProtocols_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientsLogNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsLogNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientsLogNotes_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserIdentityId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_UserIdentity_UserIdentityId",
                        column: x => x.UserIdentityId,
                        principalTable: "UserIdentity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserIdentityId = table.Column<Guid>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    IsTurnedOn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_UserIdentity_UserIdentityId",
                        column: x => x.UserIdentityId,
                        principalTable: "UserIdentity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserIdentityId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_UserIdentity_UserIdentityId",
                        column: x => x.UserIdentityId,
                        principalTable: "UserIdentity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserIdentityId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurses_UserIdentity_UserIdentityId",
                        column: x => x.UserIdentityId,
                        principalTable: "UserIdentity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<Guid>(nullable: true),
                    MedicalProtocolId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicaments_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicaments_MedicalProtocols_MedicalProtocolId",
                        column: x => x.MedicalProtocolId,
                        principalTable: "MedicalProtocols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DoctorId = table.Column<Guid>(nullable: true),
                    MedicamentId = table.Column<Guid>(nullable: true),
                    PatientId = table.Column<Guid>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Medicaments_MedicamentId",
                        column: x => x.MedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicamentLogNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    MedicamentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentLogNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicamentLogNotes_Medicaments_MedicamentId",
                        column: x => x.MedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    MedicamentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Medicaments_MedicamentId",
                        column: x => x.MedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DeviceId = table.Column<Guid>(nullable: false),
                    IsAutonomous = table.Column<bool>(nullable: false),
                    AppointmentId = table.Column<Guid>(nullable: true),
                    NurseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procedures_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedures_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Procedures_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserIdentityId",
                table: "Admin",
                column: "UserIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_MedicamentId",
                table: "Appointments",
                column: "MedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserIdentityId",
                table: "Devices",
                column: "UserIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserIdentityId",
                table: "Doctors",
                column: "UserIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalProtocols_DiseaseId",
                table: "MedicalProtocols",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentLogNotes_MedicamentId",
                table: "MedicamentLogNotes",
                column: "MedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_ManufacturerId",
                table: "Medicaments",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_MedicalProtocolId",
                table: "Medicaments",
                column: "MedicalProtocolId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_UserIdentityId",
                table: "Nurses",
                column: "UserIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MedicamentId",
                table: "Orders",
                column: "MedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientsLogNotes_PatientId",
                table: "PatientsLogNotes",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_AppointmentId",
                table: "Procedures",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_DeviceId",
                table: "Procedures",
                column: "DeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_NurseId",
                table: "Procedures",
                column: "NurseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "MedicamentLogNotes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PatientsLogNotes");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "UserIdentity");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "MedicalProtocols");

            migrationBuilder.DropTable(
                name: "Diseases");
        }
    }
}
