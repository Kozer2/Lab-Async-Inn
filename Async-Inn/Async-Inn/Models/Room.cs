using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        public int Layout { get; set; }

        // NAVIGATION PROPERTIES
        public List<RoomAmenity>  RoomAmenities{ get; set; }



    }
}
