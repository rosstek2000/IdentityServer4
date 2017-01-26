using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.ViewModels
{
    public class UserDetailsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ALPANumber { get; set; }
        public int UserId { get; set; }
        public int UserTypeId { get; set; }        
        public bool Active { get; set; }
        public bool Verified { get; set; }
    }
}
