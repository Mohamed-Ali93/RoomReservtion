using AutoMapper;
using RoomReservtion.Facilities;
using RoomReservtion.Reservations;
using RoomReservtion.Rooms;

namespace RoomReservtion
{
    public class RoomReservtionApplicationAutoMapperProfile : Profile
    {
        public RoomReservtionApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Room, CreateRoomDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Facility, FacilityDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
        }
    }
}
