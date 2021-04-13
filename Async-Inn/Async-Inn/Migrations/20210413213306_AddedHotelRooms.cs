using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn.Migrations
{
    public partial class AddedHotelRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelId", "RoomID", "PetFriendly", "Rate", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 1, false, 0m, 0 },
                    { 1, 2, false, 0m, 0 },
                    { 3, 3, false, 0m, 0 },
                    { 2, 1, false, 0m, 0 },
                    { 2, 3, false, 0m, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 3, 3 });
        }
    }
}
