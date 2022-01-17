using RoomReservtion.Enums;
using RoomReservtion.Facilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoomReservtion.Rooms
{
    public class RoomDto
    {
        public int Id { get; set; }
        [Range(0, int.MaxValue)]
        public int Number { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        public RoomTypes Roomtype { get; set; }
        public List<FacilityDto> Facilities { get; set; }
    }
}
