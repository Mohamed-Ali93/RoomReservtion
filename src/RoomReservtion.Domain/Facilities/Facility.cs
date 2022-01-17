using RoomReservtion.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace RoomReservtion.Facilities
{
    public class Facility : AuditedAggregateRoot<int>
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

    }
}
