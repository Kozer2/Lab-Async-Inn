using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn.Migrations
{
    public partial class AddedHotelRoomsrateandstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { true, 150m, 201 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { true, 50m, 101 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { true, 200m, 201 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "Rate", "RoomNumber" },
                values: new object[] { 225m, 401 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "Rate", "RoomNumber" },
                values: new object[] { 1000m, 301 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { false, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { false, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { false, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "Rate", "RoomNumber" },
                values: new object[] { 0m, 0 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomID" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "Rate", "RoomNumber" },
                values: new object[] { 0m, 0 });
        }
    }
}
