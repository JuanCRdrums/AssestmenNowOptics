using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssestmenNowOptics.Migrations
{
    /// <inheritdoc />
    public partial class SetPrimaryKeyMappingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MappingId", table: "ProductMappings");

            migrationBuilder.AddColumn<int>(
                name: "MappingId",
                table: "ProductMappings",
                nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);



            migrationBuilder.DropPrimaryKey(
            name: "PK_ProductMappings",
            table: "ProductMappings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMappings",
                table: "ProductMappings",
                column: "MappingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
            name: "PK_ProductMappings",
            table: "ProductMappings");

            migrationBuilder.AlterColumn<int>(
                name: "MappingId",
                table: "ProductMappings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: false)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
