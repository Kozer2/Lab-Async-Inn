using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Async_Inn.Models;
using Async_Inn.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
             base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HotelDto>().HasData(
              new HotelDto { Id = 1, Name = "Cedar Rapids Blast from the Past Super Fun Time Hotel", 
                  StreetAddress = "124 Hoover St.", 
                  City = "Cedar Rapids",
                  State = "Iowa", 
                  Country = "USA", 
                  Phone = "319-333-6666"},
              new HotelDto { Id = 2, Name = "Orlando Florida \"You won't be mugged here!\" Super Fun time Hotel",
                  StreetAddress = "124 Florida St.",
                  City = "Orlando",
                  State = "Florida",
                  Country = "USA",
                  Phone = "407-333-6666"
              },
              new HotelDto { Id = 3, Name = "Ninja Warriors Eat Free NOT Super Fun Time Hotel.",
                  StreetAddress = "100 Ninja Blvd.",
                  City = "Ninja Land",
                  State = "Maine",
                  Country = "USA",
                  Phone = "555-333-6666"
              }
            );

            modelBuilder.Entity<Room>().HasData(
              new Room
              {
                  Id = 1,
                  Name = "Squishy Squish This Mattress is Mushy!",
                  Layout = 2
              },
              new Room
              {
                  Id = 2,
                  Name = "Plain Hotel Room",
                  Layout = 1
              },
              new Room
              {
                  Id = 3,
                  Name = "Murder Tenderizer Room",
                  Layout = 3
              }
            );


            modelBuilder.Entity<Amentity>().HasData(
              new Amentity
              {
                  Id = 1,
                  Name = "Room Service",
                  
              },
              new Amentity
              {
                  Id = 2,
                  Name = "Buffet",
                  
              },
              new Amentity
              {
                  Id = 3,
                  Name = "Room Service and Buffet",
                  
              }
            );



            modelBuilder.Entity<RoomAmenity>()
                .HasKey(roomAmenity => new // anonymous type, similar to JS {}
                {
                    roomAmenity.RoomId,
                    roomAmenity.AmenityId,
                });

            modelBuilder.Entity<RoomAmenity>()
                .HasData(
                    new RoomAmenity { RoomId = 1, AmenityId = 1 },
                    new RoomAmenity { RoomId = 1, AmenityId = 2 },
                    new RoomAmenity { RoomId = 1, AmenityId = 3 },
                    new RoomAmenity { RoomId = 2, AmenityId = 1 },
                    new RoomAmenity { RoomId = 2, AmenityId = 2 },
                    new RoomAmenity { RoomId = 2, AmenityId = 3 },
                    new RoomAmenity { RoomId = 3, AmenityId = 1 },
                    new RoomAmenity { RoomId = 3, AmenityId = 2 },
                    new RoomAmenity { RoomId = 3, AmenityId = 3 }
                    

                );


            modelBuilder.Entity<HotelRoom>()
               .HasKey(hotelRoom => new // anonymous type, similar to JS {}
                {
                  
                   hotelRoom.HotelId,
                   hotelRoom.RoomID,

               });

            modelBuilder.Entity<HotelRoom>()
                .HasData(
                    new HotelRoom { HotelId = 1, RoomID = 1, RoomNumber = 201, Rate = 150, PetFriendly = true  },
                    new HotelRoom { HotelId = 1, RoomID = 2, RoomNumber = 101, Rate = 50, PetFriendly = true },
                    new HotelRoom { HotelId = 3, RoomID = 3, RoomNumber = 301, Rate = 1000, PetFriendly = false },
                    new HotelRoom { HotelId = 2, RoomID = 1, RoomNumber = 201, Rate = 200, PetFriendly = true },
                    new HotelRoom { HotelId = 2, RoomID = 3, RoomNumber = 401, Rate = 225, PetFriendly = false }
                    );

        }





        public DbSet<HotelDto> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amentity> Amenities { get; set; }



        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }


    }
}
