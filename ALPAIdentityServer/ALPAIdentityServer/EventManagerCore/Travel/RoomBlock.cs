using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("RoomBlocks")]
    public partial class RoomBlock
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int Number { get; set; }
        public string RoomTypeName { get; set; }

    }
}
