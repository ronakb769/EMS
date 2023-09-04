using BusinessLogic.IBusinessLogic;
using DataAccess.IRepository;
using DataAccess.Model;
using DataAccess.Model.RequestModel;
using DataAccess.Model.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessLogic
{
    public class EmployeeBusiness:IEmployeeBusiness
    {
        private readonly IEmployeeRepository _Emp;
        public EmployeeBusiness(IEmployeeRepository emp)
        {
            _Emp = emp;
        }

        //-----------------------------------------------EmployeeControler-----------------------------
        //All Active Employee
        public async Task<List<Employee>> GetAllEmp()
        {
            List<Employee> emp = await _Emp.getAllEmp();
            return emp;
        }


        //Get by Id
        public async Task<Employee> getEmpById(int empId)
        {
            Employee obj = await _Emp.FindEmpById(empId);
            return obj;
        }

        public async Task<SalaryResponse> getEmployeeSalary(int empId)
        {
            SalaryResponse sr = await _Emp.getEmployeeSalary(empId);
            return sr;
        }

        //Add New Department
        public async Task<string> AddDepartment(AddDepartmentRequest addDepartmentRequest)
        {
            Department dep = new Department();

            dep.departmentId = addDepartmentRequest.departmentId;
            dep.departmentName = addDepartmentRequest.departmentName;
            dep.departmentHead = addDepartmentRequest.departmentHead;
            dep.isActive = addDepartmentRequest.isActive;
            dep.isDelete = addDepartmentRequest.isDelete;

            string str = await _Emp.AddDepartment(dep);
            return str;
        }

        //Add New Employee
        public async Task<string> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            string str1 = await _Emp.AddEmployee(addEmployeeRequest);
            return str1;
        }

        public async Task<string> updateEmployeeById(UpdateEmployeeRequest updateEmployeeRequest, [FromRoute] int id)
        {
            string str = await _Emp.UpdateEmployeeByID(updateEmployeeRequest, id);
            return str;
        }

        public async Task<string> deleteEmployeeByID(int empId)
        {
            string str = await _Emp.deleteEmployeeByID(empId);
            return str;
        }

        //----------------------------------------Department Controller----------------------------------
        public async Task<List<Department>> GetAllDep()
        {
            List<Department> dep = await _Emp.getAllDep();
            return dep;
        }

        public async Task<Department> getDepById(int departmentId)
        {
            Department obj = await _Emp.FindDepById(departmentId);
            return obj;
        }

        public async Task<List<DepartmentResponseModel>> GetEmployeeByDepId(int depId)
        {
            List<DepartmentResponseModel> obj = await _Emp.FindEmployeeByDepId(depId);
            
            return obj;
        }
        public async Task<string> deleteDepartment(int departmentId)
        {
            string str = await _Emp.deleteDepartment(departmentId);
            return str;
        }
        //-------------------------------------EmployeeJoinController-------------------------------------
        public async Task<List<EpmloyeeJoinResponseModel>> getAllEmployeeById( )
        {
            List<EpmloyeeJoinResponseModel> obj = await _Emp.getAllEmployeeById();
            return obj;
        }

    }
}
