using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DecoupleUsersFromIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "CompanyEmployees");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "CompanyEmployees");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "CompanyEmployees");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "CompanyEmployees");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "CompanyEmployees");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "CompanyEmployees");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "CompanyEmployees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CompanyEmployees");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "CompanyEmployees");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "CompanyEmployees");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "CompanyEmployees");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "CompanyEmployees");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Admins");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "1",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELPq+hY9Z71CyxxHiZeGangJypuVg6nZnxVJIqkXnngZVdpMq9sOeTt0cQxl3L2AeA==");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "2",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP/KL4fCXUwayqMRuQvV5vsbnZKls+Gi0aM6/hJQdURNc7XnW62io1z3effu/gLXdQ==");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { "rodrigovalladares1@gmail.com", "AQAAAAIAAYagAAAAELPq+hY9Z71CyxxHiZeGangJypuVg6nZnxVJIqkXnngZVdpMq9sOeTt0cQxl3L2AeA==" });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: "2",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP/KL4fCXUwayqMRuQvV5vsbnZKls+Gi0aM6/hJQdURNc7XnW62io1z3effu/gLXdQ==");

            migrationBuilder.UpdateData(
                table: "CompanyEmployees",
                keyColumn: "Id",
                keyValue: "1",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELPq+hY9Z71CyxxHiZeGangJypuVg6nZnxVJIqkXnngZVdpMq9sOeTt0cQxl3L2AeA==");

            migrationBuilder.UpdateData(
                table: "CompanyEmployees",
                keyColumn: "Id",
                keyValue: "2",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP/KL4fCXUwayqMRuQvV5vsbnZKls+Gi0aM6/hJQdURNc7XnW62io1z3effu/gLXdQ==");

            migrationBuilder.UpdateData(
                table: "CompanyEmployees",
                keyColumn: "Id",
                keyValue: "3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEE+uB2FjxI7+/OZp7o9GIGii89uNWlL9uAUCSn2etz4vL3HYNNbQ3qVNylFfur4Y1A==");

            migrationBuilder.UpdateData(
                table: "CompanyEmployees",
                keyColumn: "Id",
                keyValue: "4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPfcs6EROgM0MdKcRpvnizut39TBlMOZ2sOcWnhYCX4TrBkKvt3bGhV/ptyM6xz7pw==");

            migrationBuilder.UpdateData(
                table: "Openings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateExpiration" },
                values: new object[] { new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Openings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateExpiration" },
                values: new object[] { new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "CompanyEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "CompanyEmployees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "CompanyEmployees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "CompanyEmployees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "CompanyEmployees",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "CompanyEmployees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "CompanyEmployees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CompanyEmployees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "CompanyEmployees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "CompanyEmployees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "CompanyEmployees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "CompanyEmployees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Candidates",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Admins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Admins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Admins",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Admins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Admins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "3ad6dc80-5a57-4dbb-bd4a-ace2950d6ea7", false, false, null, null, null, "AQAAAAEAACcQAAAAEESpbwMJnE3MgeJLiNAr+a4+9Y/mOUZct4hsAeISiZvTQNBjO+uBQrEqkBdf2ZMkHA==", null, false, "8d20d7b9-2ede-41b0-a305-c877052214e8", false, null });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "f7ab29ec-1f2b-4695-a3c6-28ac27375902", false, false, null, null, null, "AQAAAAEAACcQAAAAEGFggnwh1al3lICNhF/S2y7x3nWmRa0/K+0ZqE9F4x83QaQDVvOZ/F+IdMfFC3lqYQ==", null, false, "11aa3d4e-535f-443e-9326-909cf5ef8a10", false, null });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "c213e679-0fcf-48a4-9ccb-0d01b0b5f799", "rodrigovalladare1@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEFJJBn9noHpkIiAMyk7Zgaw5vM8MlZvW30jFKbexsosA30AF8opOk+mt1Z/tbJbgcg==", null, false, "874f8260-20df-44e2-aada-5e5f3343ef74", false, null });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "c745fc44-37b0-457f-9680-578123478ff9", false, false, null, null, null, "AQAAAAEAACcQAAAAEB4sLr0KjXX1K/N56Fgf64PxPi9jyPk2xnRCO5UGQygyxC0zS8V/6I+ldN3WigYxPg==", null, false, "321ff1f6-a6d9-4d22-b6d4-12e1417583fc", false, null });

            migrationBuilder.UpdateData(
                table: "CompanyEmployees",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "ab5ea0c9-c79b-40be-967e-59f7cbb666a9", false, false, null, null, null, "AQAAAAEAACcQAAAAEIskeea3rhyHOx3rD1dcvkZ/1/yumTpraGsX6JYz98kAqFpJFd/K7XcaqxSsEkrvQw==", null, false, "c380c42a-b5c2-478d-b730-b44709aaa17f", false, null });

            migrationBuilder.UpdateData(
                table: "CompanyEmployees",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "18f5ab04-1c23-4e6c-ab45-8b258188b7ad", false, false, null, null, null, "AQAAAAEAACcQAAAAENe4+rJGEcVdlbldyN5umnXLGBHEmfN8BZ46gZiZ3pYZIVfuS0nvXocEWLV2e1qw4g==", null, false, "a7c28d61-4c39-41bb-8d9b-59417be575be", false, null });

            migrationBuilder.UpdateData(
                table: "CompanyEmployees",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "87d0e968-e8df-4361-ab64-71cae6f2a5f4", false, false, null, null, null, "AQAAAAEAACcQAAAAEFHbJP87ldu7PFDIJhzDGit1/oYLS0nHlAk26z7wsLnJWqyX43QX22hBFWI0jS77xg==", null, false, "8e237d02-a9b5-4280-aab9-3921c0cce11e", false, null });

            migrationBuilder.UpdateData(
                table: "CompanyEmployees",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "53552135-5a67-4fe6-8a0f-f704a6f511d4", false, false, null, null, null, "AQAAAAEAACcQAAAAEEy/1azTnM727xJxVv2GqKKCMlm3jLMJDwC1P03+jsqOU53nOvz+k9Vty+rr2q9OQA==", null, false, "ceea3ff2-56d3-4e94-92ee-800f9d8323bb", false, null });

            migrationBuilder.UpdateData(
                table: "Openings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateExpiration" },
                values: new object[] { new DateTime(2022, 9, 10, 16, 37, 4, 494, DateTimeKind.Local).AddTicks(6865), new DateTime(2022, 9, 20, 16, 37, 4, 494, DateTimeKind.Local).AddTicks(6878) });

            migrationBuilder.UpdateData(
                table: "Openings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateExpiration" },
                values: new object[] { new DateTime(2022, 9, 10, 16, 37, 4, 494, DateTimeKind.Local).AddTicks(6890), new DateTime(2022, 10, 5, 16, 37, 4, 494, DateTimeKind.Local).AddTicks(6890) });
        }
    }
}
