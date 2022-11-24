using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersControl.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Cpf", "Email", "Name", "Password" },
                values: new object[] { 1L, "123.123.123-11", "viola@gmail.com", "Viola", "10000.VwgxMW/tpkhUXj9LWHacJg==.JBuvDY8Lm5bQT/nxd+IsSdrdx9Gk2GRvQ5XdtivMqXs=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
