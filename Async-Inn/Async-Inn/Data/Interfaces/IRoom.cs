using Async_Inn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data.Interfaces
{
   public interface IRoom
    {
        Task<IEnumerable<Room>> GetRooms();
        Task<Room> GetRoom(int id);
        Task<bool> DeleteRoom(int id);
        Task CreateRoom(Room room);
        Task<bool> PutRoom(Room room);

    }
}
