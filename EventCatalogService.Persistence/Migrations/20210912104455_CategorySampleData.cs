using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogService.Persistence.Migrations
{
    public partial class CategorySampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { "category-b0788d2f-8003-43c1-92a4-edc76a7c5dde", "Concerts" },
                    { "category-6313179f-7837-473a-a4d5-a5571b43e6a6", "Musicals" },
                    { "category-bf3f3002-7e53-441e-8b76-f6280be284aa", "Plays" },
                    { "category-fe98f549-e790-4e9f-aa16-18c2292a2ee9", "Conferences" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValues: new object[] 
                {
                   "category-b0788d2f-8003-43c1-92a4-edc76a7c5dde",
                   "category-6313179f-7837-473a-a4d5-a5571b43e6a6",
                   "category-bf3f3002-7e53-441e-8b76-f6280be284aa",
                   "category-fe98f549-e790-4e9f-aa16-18c2292a2ee9"
                });
        }
    }
}
