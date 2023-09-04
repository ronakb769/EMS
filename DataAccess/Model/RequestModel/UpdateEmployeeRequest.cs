using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model.RequestModel
{
    public class UpdateEmployeeRequest
    {

        [Required]
        public string empName { get; set; }
        [Required]
        public string empEmail { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int empAge { get; set; }
        [Required]
       
        public string empPhone { get; set; }

    }
}
