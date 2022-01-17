using Microsoft.AspNetCore.Authorization;
using RoomReservtion.Facilities;
using RoomReservtion.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Validation;

namespace RoomReservtion.Rooms
{
    [RemoteService(false)]
    public class RoomAppService : RoomReservtionAppService, IRoomAppService
    {
        private readonly IRepository<Room, int> _roomRepository;
        private readonly IRepository<Reservation, int> _reservationRepository;
        private readonly IRepository<Facility, int> _FacilityRepository;

        public RoomAppService(IRepository<Room, int> roomRepository, IRepository<Facility, int> FacilityRepository,
            IRepository<Reservation, int> reservationRepository)
        {
            _roomRepository = roomRepository;
            _FacilityRepository = FacilityRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task AddRoom(CreateRoomDto dto)
        {
            if (IsRoomNumberExists(dto.Number))
                throw new AbpValidationException("You should enter unique Room Number ");

            if (dto.FacilitiesIds.Count == 0)
                throw new AbpValidationException("You should enter Room Facility ");

            var query = await _FacilityRepository.GetQueryableAsync();

            var room = ObjectMapper.Map<CreateRoomDto, Room>(dto);
            room.Facilities = query.Where(a => dto.FacilitiesIds.Contains(a.Id)).ToList();
            await _roomRepository.InsertAsync(room);

        }
        public async Task EditRoom(CreateRoomDto dto)
        {
            var dbRoom = await _roomRepository.FindAsync(dto.Id);
            if (dbRoom == null)
                throw new AbpValidationException("Invalid object ");

            // we need to remove deleted facilites and add new ones to DB but for Sinmplicity i did not do this now  
            var room = ObjectMapper.Map(dto, dbRoom);
            await _roomRepository.UpdateAsync(room);
        }
        public async Task DeleteRoom(int id)
        {
            var room = await _roomRepository.FindAsync(id);
            if (room == null)
                throw new AbpValidationException($"Invalid id :{id}");

            await _roomRepository.DeleteAsync(room);
        }
        public async Task<RoomDto> GetRoom(int id)
        {
            var room = await _roomRepository.FindAsync(id);
            if (room == null)
                throw new AbpValidationException($"Invalid id :{id}");

            return ObjectMapper.Map<Room, RoomDto>(room);
        }
        public async Task<List<RoomDto>> GetAllRooms()
        {
            var rooms = await _roomRepository.WithDetailsAsync(a => a.Facilities);
            return ObjectMapper.Map<List<Room>, List<RoomDto>>(rooms.ToList());
        }
        public async Task<List<RoomDto>> Search(RoomFilter filter)
        {
            var query = await _roomRepository.WithDetailsAsync(a => a.Facilities);
            var rooms = query
                .WhereIf(filter.MaxPrice != null, a => a.Price <= filter.MaxPrice)
                .WhereIf(filter.MinPrice != null, a => a.Price >= filter.MinPrice)
                .WhereIf(filter.RoomType != null, a => a.Roomtype == filter.RoomType)
                .WhereIf(filter.Number != null, a => a.Number == filter.Number)
                .WhereIf(!string.IsNullOrEmpty(filter.ContainsFacility), a => a.Facilities.Any(a =>
                a.Name.ToLower().Contains(filter.ContainsFacility.ToLower()))
                ).ToList();
            return ObjectMapper.Map<List<Room>, List<RoomDto>>(rooms);
        }
        private bool IsRoomNumberExists(int num)
        {
            return _roomRepository.Any(a => a.Number == num);
        }

        public async Task<bool> ReserveRoomAsync(ReservationDto dto)
        {
            if (dto.StartDate >= dto.EndDate)
                throw new AbpValidationException("Invalid dates"); //these can take all details of error but for simplicity i pass message only 
            // check if room resered i the same days 
            var isReserved = await _reservationRepository.AnyAsync(
                a => a.RoomId == dto.RoomId &&
                ((a.StartDate <= dto.StartDate && dto.StartDate <= dto.EndDate) ||
                (a.StartDate >= dto.EndDate && dto.EndDate <= dto.EndDate)));
            if (isReserved)
                throw new BusinessException("Room Not Available","Room not available at this dates","Room Reservied at this period");

            var result = await _reservationRepository.InsertAsync(ObjectMapper.Map<ReservationDto, Reservation>(dto));
            if (result == null)
                return false;
            return true;
        }

    }
}
