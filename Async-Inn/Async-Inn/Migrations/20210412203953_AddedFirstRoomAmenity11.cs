using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn.Migrations
{
    public partial class AddedFirstRoomAmenity11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "AmenityId", "RoomId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 1, 1 });
        }
    }
}
