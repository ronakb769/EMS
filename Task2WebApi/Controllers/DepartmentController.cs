using BusinessLogic.IBusinessLogic;
using DataAccess.Model;
using DataAccess.Model.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Task2WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IEmployeeBusiness _emp;
        public DepartmentController(IEmployeeBusiness emp)
        {
            _emp = emp;
        }


        [HttpGet("GetAllDepartment")]
        [Authorize]
        public async Task<IActionResult> GetAllDepartment()
        {
            List<Department> emp = await _emp.GetAllDep();
            if (emp != null && emp.Any())
            {
                return Ok(emp);
            }
            return Ok("Not Found");
        }


        [HttpGet("Department/Id")]
        [Authorize]
        public async Task<IActionResult> GetDepartmentById(int departmentId)
        {
            Department dep = await _emp.getDepById(departmentId);
            if (dep != null)
            {
                return Ok(dep);
            }
            return Ok("Not Found");
        }

        [HttpGet("EmployeeByDepartmentId")]
        [Authorize]
        public async Task<IActionResult> GetEmployeeByDepId(int depId)
        {
            List<DepartmentResponseModel> dep = await _emp.GetEmployeeByDepId(depId);
            if (dep != null)
            {
                return Ok(dep);
            }
            return Ok("Not Found");
        }

        [HttpPut("Delete Department")]
        [Authorize]

        public async Task<IActionResult> DeleteDepartment(int departmentId)
        {
            string str  = await _emp.deleteDepartment(departmentId);
            return Ok(str);
        }
    }
}


    

