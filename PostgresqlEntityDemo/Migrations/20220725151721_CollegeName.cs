using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresqlEntityDemo.Migrations
{
    public partial class CollegeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Colleges",
                type: "text",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Colleges");
        }
    }
}
