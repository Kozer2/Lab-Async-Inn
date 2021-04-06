using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { Id = 1, Name = "Cedar Rapids Blast from the Past Super Fun Time Hotel", 
                  StreetAddress = "124 Hoover St.", 
                  City = "Cedar Rapids",
                  State = "Iowa", 
                  Country = "USA", 
                  Phone = "319-333-6666"},
              new Hotel { Id = 2, Name = "Orlando Florida \"You won't be mugged here!\" Super Fun time Hotel",
                  StreetAddress = "124 Florida St.",
                  City = "Orlando",
                  State = "Florida",
                  Country = "USA",
                  Phone = "407-333-6666"
              },
              new Hotel { Id = 3, Name = "Ninja Warriors Eat Free NOT Super Fun Time Hotel.",
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


        }





        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amentity> Amenities { get; set; }

        /*        

                public DbSet<HotelRoom> HotelRooms { get; set; }



                public DbSet<RoomAmenity> RoomAmenities { get; set; }*/

    }
}
