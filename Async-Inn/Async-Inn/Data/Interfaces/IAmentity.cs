using Async_Inn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data.Interfaces
{
    public interface IAmentity
    {
        
        Task<IEnumerable<Amentity>> GetAmentities();
        Task<Amentity> GetAmentity(int id);
        Task DeleteAmentity(Amentity amentity);
        Task CreateAmentity(Amentity amentity);
        Task<bool> PutAmentity(Amentity amentity);

    }

}
