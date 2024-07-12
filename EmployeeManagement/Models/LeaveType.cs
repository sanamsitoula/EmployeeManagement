using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class LeaveType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsCarryOver { get; set; }

        [Required]
        public string FiscalYear { get; set; }

        public string Details { get; set; }

        public bool IsHalfLeave { get; set; }

        public bool IsOpening { get; set; }

        public double NoOfDays { get; set; }

        // Navigation property
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
