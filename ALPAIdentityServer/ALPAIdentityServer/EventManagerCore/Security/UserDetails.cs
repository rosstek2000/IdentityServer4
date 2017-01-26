using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("UserDetails")]
    public class UserDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ALPANumber { get; set; }
        public bool Active { get; set; }
        public bool Verified  { get; set; }

    }
}
