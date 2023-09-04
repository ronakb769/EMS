using BusinessLogic.IBusinessLogic;
using DataAccess.Model;
using DataAccess.Model.RequestModel;
using DataAccess.Model.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Task2WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController:Controller
    {
        private readonly IEmployeeBusiness _emp;
        public EmployeeController(IEmployeeBusiness emp)
        {
            _emp = emp;
        }
        //All Active Employee
        [HttpGet("GetAllEmployee")]
        [Authorize]
        public async Task<IActionResult> GetAllEmp() 
        {
            List<Employee> emp = await _emp.GetAllEmp();
            if(emp!=null && emp.Any())
            {
                return Ok(emp);
            }
            return Ok("Not Found");
        }
        //Find Employee By ID
        [HttpGet("Employee/Id")]
        [Authorize]
        public async Task<IActionResult> GetEmpById(int empId)
        {
            Employee emp = await _emp.getEmpById(empId);
            if (emp != null )
            {
                return Ok(emp);
            }
            return Ok("Not Found");
        }

        [HttpGet("Get/Slaray")]
        [Authorize]
        public async Task<IActionResult> GetEmployeeSalary(int empId)
        {
            SalaryResponse sr = await _emp.getEmployeeSalary(empId);
            if (sr!=null)
            {
                return Ok(sr);
            }
            return Ok("Employee is Deleted");
        }

        //Add new Department 
        [HttpPost("ADD/Department")]
        [Authorize]
        public async Task<IActionResult> AddDepartment(AddDepartmentRequest addDepartmentRequest)
        {
          return Ok(await _emp.AddDepartment(addDepartmentRequest));
        }

        //Add new Employee
        [HttpPost("ADD/Employee")]
        [Authorize]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        { 
            return Ok(await _emp.AddEmployee(addEmployeeRequest));
        }


        [HttpPut("Edit/Employee")]
        [Authorize]
        public async Task<IActionResult> UpdateEmployeeByID(UpdateEmployeeRequest updateEmployeeRequest, int id)
        { 
            string emp = await _emp.updateEmployeeById(updateEmployeeRequest, id);
           return Ok(emp);
        }

        [HttpPut("Delete/Employee")]
        [Authorize]
        public async Task<IActionResult> DeleteEmployeeByID(int empId)
        {
            string emp = await _emp.deleteEmployeeByID(empId);
            return Ok(emp);
        }
    }
}
