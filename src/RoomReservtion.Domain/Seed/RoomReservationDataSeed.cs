using RoomReservtion.Enums;
using RoomReservtion.Facilities;
using RoomReservtion.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace RoomReservtion.Seed
{
    public class RoomReservationDataSeed : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Room, int> _roomRepository;
        private readonly IRepository<Facility, int> _facilityRepository;

        public RoomReservationDataSeed(IRepository<Room, int> roomRepository, IRepository<Facility, int> facilityRepository)
        {
            _roomRepository = roomRepository;
            _facilityRepository = facilityRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            await SeedFacilites();
            await SeedRooms();
        }
        // we here can pass tenant id if we use multitenant but now we use only the host tenant 
        private async Task SeedFacilites()
        {
            if (await _facilityRepository.GetCountAsync() == 0)
            {
                var facilites = new List<Facility>();
                facilites.Add(new Facility()
                {
                    Name = "TV",
                    CreationTime = DateTime.UtcNow
                });
                facilites.Add(new Facility()
                {
                    Name = "Tea and coffee making facilities",
                    CreationTime = DateTime.UtcNow
                });
                facilites.Add(new Facility()
                {
                    Name = "Minibar",
                    CreationTime = DateTime.UtcNow
                });
                facilites.Add(new Facility()
                {
                    Name = "Air conditioning",
                    CreationTime = DateTime.UtcNow
                });
                facilites.Add(new Facility()
                {
                    Name = "Fan cooling",
                    CreationTime = DateTime.UtcNow
                });
                await _facilityRepository.InsertManyAsync(facilites);
            }
        }

        private async Task SeedRooms()
        {
            if (await _roomRepository.GetCountAsync() == 0)
            {
                // get Facilites to add to rooms
                var facilites = await _facilityRepository.GetListAsync();
                var rooms = new List<Room>();
                for (int i = 0; i < 5; i++)
                {
                    var room = new Room();
                    room.Price = (i + 1) * 500;
                    room.Number = (i + 1);
                    room.CreationTime = DateTime.UtcNow;
                    room.Roomtype = (RoomTypes)((i % 3) + 1);
                    rooms.Add(room);
                }
                await _roomRepository.InsertManyAsync(rooms);
            }
        }
    }
}
