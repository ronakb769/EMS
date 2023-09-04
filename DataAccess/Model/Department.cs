using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public  class Department
    {
        [Key]
        public int departmentId { get; set; }
        [Required] 
        public  string departmentName { get; set; }
        [Required]
        public  string departmentHead { get; set;}
        
        public bool isActive { get; set;}
        public bool isDelete { get; set;}
    }
}
