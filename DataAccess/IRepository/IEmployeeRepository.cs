using DataAccess.Model;
using DataAccess.Model.RequestModel;
using DataAccess.Model.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public  interface IEmployeeRepository
    {
        //-------------------------Employee Controller------------------------
        public Task<List<Employee>> getAllEmp();
        public Task<Employee> FindEmpById(int empId);

        public Task<SalaryResponse> getEmployeeSalary(int empId);
        public Task<string> deleteEmployeeByID(int empId);
        public Task<string> AddDepartment(Department dep);

        public Task<string> AddEmployee(AddEmployeeRequest addEmployeeRequest);

        public Task<string> UpdateEmployeeByID(UpdateEmployeeRequest updateEmployeeRequest, [FromRoute] int id);

        //-------------------------Department Controller------------------------
        public Task<List<Department>> getAllDep();

        public Task<Department> FindDepById(int departmentId);

        public Task<List<DepartmentResponseModel>> FindEmployeeByDepId(int depId);

        public Task<string> deleteDepartment(int departmentId);

        //-------------------------EmployeeJoin Controller------------------------
        public Task<List<EpmloyeeJoinResponseModel>> getAllEmployeeById();
    }
}
