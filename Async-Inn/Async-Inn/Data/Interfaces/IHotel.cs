﻿using Async_Inn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data.Interfaces
{
    public interface IHotel
    {
        Task<IEnumerable<Hotel>> GetHotels();
        Task<Hotel> GetHotel(int id);
        Task DeleteHotel(Hotel hotel);
        Task CreateHotel(Hotel hotel);
        Task<bool> PutHotel( Hotel hotel);

    }
}