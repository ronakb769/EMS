using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model.ResponseModel
{
    public class SalaryResponse
    {
       
        public string empName { get; set; }

        public int salaryAmount { get; set; }

    }
}
