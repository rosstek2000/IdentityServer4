using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("Accommodations")]
    public partial class Accommodation
    {
       

        public int Id { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string ConfirmationNumber { get; set; }
        public DateTime? ConfirmationSentDate { get; set; }
        public decimal? Cost { get; set; }
        public int HotelId { get; set; }
        public int? RoomNumber { get; set; }
        public string RoomTypeName { get; set; }
        public string Status { get; set; }

    }
}
