using RoomReservtion.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomReservtion.Rooms
{
    public class RoomFilter
    {
        public int? Number { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinPrice { get; set; }
        public RoomTypes? RoomType { get; set; }
        public string ContainsFacility { get; set; }
    }
}
