using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public  class Salary
    {
        [Key]
        public int salaryId { get; set; }
        [Required]
        public int empId { get; set; }
        [Required]
        public int salaryAmount { get; set; }
        
        public bool isActive { get; set; }
        public bool isDelete { get; set; }
    }
}
