using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddRawCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tb_Category VALUES('Cat 1')");
            migrationBuilder.Sql("INSERT INTO tb_Category VALUES('Cat 2')");
            migrationBuilder.Sql("INSERT INTO tb_Category VALUES('Cat 3')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
