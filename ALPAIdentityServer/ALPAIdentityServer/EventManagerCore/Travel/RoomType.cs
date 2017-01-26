using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    public partial class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
