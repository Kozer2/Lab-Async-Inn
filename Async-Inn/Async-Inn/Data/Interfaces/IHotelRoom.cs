
﻿using Async_Inn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data.Interfaces
{

    public interface IHotelRoom
    {
        Task<List<HotelRoom>> GetHotelRooms();
        Task<HotelRoom> GetHotelRoom(int hotelId, int roomId);
        Task<bool> DeleteHotelRoom(int hotelId, int roomId);
        Task CreateHotelRoom(HotelRoom hotelRoom);
        Task<bool> PutHotelRoom(HotelRoom hotelRoom);

    }
}
