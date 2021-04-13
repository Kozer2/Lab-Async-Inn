using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class HotelRoom
    {
        public int HotelId { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public int RoomID { get; set; }

        [Required, Column(TypeName = "decimal(18,4)")]
        public decimal Rate { get; set; }

        [Required]
        public bool PetFriendly { get; set; }

        // NAVIGATION PROPERTIES
        public Hotel hotel { get; set; }
        public Room Room { get; set; }
    }
}

