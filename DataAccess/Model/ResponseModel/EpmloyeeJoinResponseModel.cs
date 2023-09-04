using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model.ResponseModel
{
    public  class EpmloyeeJoinResponseModel
    {
        public int empId { get; set; }
        public int salaryId { get; set; }   
        public int salaryAmount { get; set; } 
        public int departmentId { get; set; }
        [Required]
        public string empName { get; set; }
        [Required]
        public string empEmail { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int empAge { get; set; }
        [Required]
        public DateTime joinedDate { get; set; }
        [Required]
        public string empPhone { get; set; }

        public bool isActive { get; set; }
        public bool isDelete { get; set; }

     
    }
}
