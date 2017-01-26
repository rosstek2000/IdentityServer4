using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Core
{
    [Table("UserTypes")]
    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
