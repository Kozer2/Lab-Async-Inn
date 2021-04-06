using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class RoomAmenity
    {
        [Required]
        
        public int AmenityId { get; set; }

        [Required]
        public int RoomId { get; set; }


    }
}
