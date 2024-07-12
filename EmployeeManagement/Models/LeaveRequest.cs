using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int LeaveTypeId { get; set; }

        public LeaveType LeaveType { get; set; }

        [Required]
        public double NoOfAvailable { get; set; }

        [Required]
        public double NoDays { get; set; }

        [Required]
        public double Balance { get; set; }
    }
}
