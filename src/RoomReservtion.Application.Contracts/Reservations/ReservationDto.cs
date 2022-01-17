using RoomReservtion.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoomReservtion.Reservations
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
     //   public RoomDto Room { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
