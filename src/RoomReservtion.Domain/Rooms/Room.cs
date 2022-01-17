using RoomReservtion.Enums;
using RoomReservtion.Facilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace RoomReservtion.Rooms
{
    public class Room : AuditedAggregateRoot<int>
    {
        // Room number can be string if we name it like (A-12) but now I use int value to be simple 
        [Range(0, int.MaxValue)]
        public int Number { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        public RoomTypes Roomtype { get; set; }
        public List<Facility> Facilities { get; set; }
    }
}
