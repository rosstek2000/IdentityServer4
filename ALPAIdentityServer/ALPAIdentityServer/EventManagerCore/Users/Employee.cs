using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Core
{
    [Table("Employees")]
    public class Employee
    {
        public decimal Number { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public decimal DepartmentNumber { get; set; }
        public decimal TitleNumber { get; set; }
        public string Email { get; set; }
        public string DepartmentId { get; set; }
    }

}
