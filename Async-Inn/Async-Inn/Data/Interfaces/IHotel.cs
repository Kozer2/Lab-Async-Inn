using Async_Inn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data.Interfaces
{
    public interface IHotel
    {
        Task<IEnumerable<HotelDto>> GetHotels();
        Task<HotelDto> GetHotel(int id);
        Task<bool> DeleteHotel(int id);
        Task CreateHotel(HotelDto hotel);
        Task<bool> PutHotel( HotelDto hotel);

    }
}
