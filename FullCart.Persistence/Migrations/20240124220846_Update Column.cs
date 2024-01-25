using FullCart.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullCart.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Brand>("CreatedBy", "Brands", nullable: true);
            migrationBuilder.AlterColumn<Brand>("LastModifiedBy", "Brands", nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
