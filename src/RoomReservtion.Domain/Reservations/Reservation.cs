using RoomReservtion.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace RoomReservtion.Reservations
{
    public class Reservation : AuditedAggregateRoot<int>
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
