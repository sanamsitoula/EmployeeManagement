using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string CitizenshipNo { get; set; }

        public string Document { get; set; }
      //  [(ErrorMessage = "Please select a department")]
        public int DepartmentId { get; set; }
     
        public Department? Department { get; set; }

        [Required]
        public string Gender { get; set; }

        // Navigation property
      //  [NotMapped]
        public ICollection<LeaveRequest>? LeaveRequests { get; set; }
    }
}
