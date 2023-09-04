using BusinessLogic.IBusinessLogic;
using DataAccess.Model.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Task2WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeControllerJoin:Controller
    {
        private readonly IEmployeeBusiness _emp;

        public EmployeeControllerJoin(IEmployeeBusiness emp)
        {
            _emp = emp;
        }
        [HttpGet("Get/All/Employee")]
        [Authorize]
        public async Task<IActionResult> GetAllEmplmoyeeById()
        {
            List<EpmloyeeJoinResponseModel> emp = await _emp.getAllEmployeeById();
            return Ok(emp);
        }
    }
}
