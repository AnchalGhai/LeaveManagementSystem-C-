using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLeaveManagemntSystem.Migrations
{
    /// <inheritdoc />
    public partial class seeddata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "leavetype",
                columns: table => new
                {
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxPerYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leavetype", x => x.LeaveTypeId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_user_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_user_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "user",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "leaveapplication",
                columns: table => new
                {
                    LeaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ManagerComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppliedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveapplication", x => x.LeaveId);
                    table.ForeignKey(
                        name: "FK_leaveapplication_leavetype_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "leavetype",
                        principalColumn: "LeaveTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaveapplication_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "leavebalance",
                columns: table => new
                {
                    BalanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    TotalAssigned = table.Column<int>(type: "int", nullable: false),
                    Used = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leavebalance", x => x.BalanceId);
                    table.ForeignKey(
                        name: "FK_leavebalance_leavetype_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "leavetype",
                        principalColumn: "LeaveTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leavebalance_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_notification_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "department",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "IT" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "UserId", "DateOfJoining", "DepartmentId", "Email", "FullName", "ManagerId", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 26, 0, 54, 28, 574, DateTimeKind.Local).AddTicks(4793), 1, "admin@example.com", "Admin User", null, "Admin@123", "Admin" },
                    { 2, new DateTime(2025, 11, 26, 0, 54, 28, 574, DateTimeKind.Local).AddTicks(4807), 2, "manager@example.com", "John Manager", null, "Manager@123", "Manager" },
                    { 3, new DateTime(2025, 11, 26, 0, 54, 28, 574, DateTimeKind.Local).AddTicks(4809), 2, "employee@gmail.com", "Alice Employee", 2, "Employee@123", "Employee" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_leaveapplication_LeaveTypeId",
                table: "leaveapplication",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveapplication_UserId",
                table: "leaveapplication",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_leavebalance_LeaveTypeId",
                table: "leavebalance",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_leavebalance_UserId",
                table: "leavebalance",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_notification_UserId",
                table: "notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_DepartmentId",
                table: "user",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ManagerId",
                table: "user",
                column: "ManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaveapplication");

            migrationBuilder.DropTable(
                name: "leavebalance");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "leavetype");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
