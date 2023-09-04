
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Model;
using System.Threading.Tasks;
using DataAccess.Model.RequestModel;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Model.ResponseModel;

namespace BusinessLogic.IBusinessLogic
{
    public interface IEmployeeBusiness

    {
        public Task<List<Employee>> GetAllEmp();

        public Task<Employee> getEmpById(int empId);

        public Task<SalaryResponse> getEmployeeSalary(int empId);
        public Task<string> AddDepartment(AddDepartmentRequest addDepartmentRequest);

        public Task<string> AddEmployee(AddEmployeeRequest addEmployeeRequest);

        public Task<string> updateEmployeeById(UpdateEmployeeRequest updateEmployeeRequest, [FromRoute] int id);

        public Task<string> deleteEmployeeByID(int empId);

        public Task<List<Department>> GetAllDep();

        public Task<Department> getDepById(int departmentId);

        public Task<List<DepartmentResponseModel>> GetEmployeeByDepId(int depId);

        public  Task<string> deleteDepartment(int departmentId);

        public Task<List<EpmloyeeJoinResponseModel>> getAllEmployeeById( );
    }
}
