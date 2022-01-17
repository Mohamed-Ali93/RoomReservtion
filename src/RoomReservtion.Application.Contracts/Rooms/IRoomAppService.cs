using RoomReservtion.Reservations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservtion.Rooms
{
    public interface IRoomAppService
    {
        Task AddRoom(CreateRoomDto dto);
        Task EditRoom(CreateRoomDto dto);
        Task DeleteRoom(int id);
        Task<RoomDto> GetRoom(int id);
        Task<List<RoomDto>> GetAllRooms();
        Task<List<RoomDto>> Search(RoomFilter filter);
        Task<bool> ReserveRoomAsync(ReservationDto dto);
    }
}
