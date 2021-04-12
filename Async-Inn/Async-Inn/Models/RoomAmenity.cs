using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class RoomAmenity
    {
       
        public int AmenityId { get; set; }

        public int RoomId { get; set; }

        // NAVIGATION PROPERTIES
        public Amentity Amenity { get; set; }
        public Room Room { get; set; }



    }
}
