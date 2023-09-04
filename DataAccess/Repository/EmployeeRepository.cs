using DataAccess.context;
using DataAccess.IRepository;
using DataAccess.Model;
using DataAccess.Model.RequestModel;
using DataAccess.Model.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TaskDbContext _dbContext;
        public EmployeeRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Fetch All Active Employee
        public async Task<List<Employee>> getAllEmp()
        {
            List<Employee> emp = await _dbContext.employee.ToListAsync();
            List<Employee> lst = new List<Employee>();
            foreach (Employee item in emp)
            {
                if (item.isActive == true && item.isDelete == false)
                {
                    lst.Add(item);
                }
            }
            return lst;
        }
        //Get employee By Id 
        public async Task<Employee> FindEmpById(int empId)
        {
            Employee emp = (await _dbContext.employee.ToListAsync()).FindAll(emp => emp.empId == empId).FirstOrDefault();

            return emp;
        }

        public async Task<SalaryResponse> getEmployeeSalary(int empId)
        {
            Salary s = (await _dbContext.salary.ToListAsync()).FindAll(s => s.empId == empId).FirstOrDefault();
            Employee b = await _dbContext.employee.FindAsync(empId);
            if (b.isActive == true && b.isDelete == false)
            {
                SalaryResponse salaryrs = new SalaryResponse();
                salaryrs.salaryAmount = s.salaryAmount;
                salaryrs.empName = b.empName;
                return salaryrs;
            }
            return null;

        }

        //Add new Department
        public async Task<string> AddDepartment(Department dep)
        {


            await _dbContext.department.AddAsync(dep);

            int a = await _dbContext.SaveChangesAsync();
            if (a > 0)
            {
                return "Departement Added Successfully";
            }
            return "Soory!..Something went Wrong";
        }


        //Add Employee
        public async Task<string> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            Employee emp = new Employee();
            Employee check = (await _dbContext.employee.ToListAsync()).FindAll(e => e.empName == addEmployeeRequest.empName).FirstOrDefault();
            if (check != null)
            {
                return "Name Already Present ";
            }
            emp.empId = addEmployeeRequest.empId;
            emp.departmentId = addEmployeeRequest.departmentId;
            emp.empName = addEmployeeRequest.empName;
            emp.empEmail = addEmployeeRequest.empEmail;
            emp.DateOfBirth = addEmployeeRequest.DateOfBirth;
            emp.empAge = addEmployeeRequest.empAge;
            emp.joinedDate = addEmployeeRequest.joinedDate;
            emp.empPhone = addEmployeeRequest.empPhone;
            emp.isActive = addEmployeeRequest.isActive;
            emp.isDelete = addEmployeeRequest.isDelete;

            await _dbContext.employee.AddAsync(emp);
            int a = await _dbContext.SaveChangesAsync();

            Salary s;
            int b;
            foreach (SalaryRequest item in addEmployeeRequest.lstSalary)
            {
                s = new Salary();
                s.salaryId = item.salaryId;
                s.empId = emp.empId;
                s.salaryAmount = item.salaryAmount;
                s.isActive = item.isActive;
                s.isDelete = item.isDelete;

                await _dbContext.salary.AddAsync(s);

            }
            b = await _dbContext.SaveChangesAsync();
            if (a > 0 && b > 0)
            {
                return "Employee Added Successfully";
            }
            return "Soory!..Something went Wrong";
        }
        public async Task<List<Department>> getAllDep()
        {
            List<Department> emp = await _dbContext.department.ToListAsync();
            List<Department> lst = new List<Department>();
            foreach (Department item in emp)
            {
                if (item.isActive == true && item.isDelete == false)
                {
                    lst.Add(item);
                }
            }
            return lst;
        }

        public async Task<Department> FindDepById(int departmentId)
        {
            Department dep = (await _dbContext.department.ToListAsync()).FindAll(dep => dep.departmentId == departmentId).FirstOrDefault();

            return dep;
        }

        public async Task<string> deleteEmployeeByID(int empId)
        {
            Employee emp = await _dbContext.employee.FindAsync(empId);
            int a = 0;
            if (emp != null)
            {
                emp.isDelete = true;
                emp.isActive = false;

                Salary s = (await _dbContext.salary.ToListAsync()).FindAll(s => s.empId == empId).FirstOrDefault();

                if (s != null)
                {
                    s.isDelete = true;
                    s.isActive = false;
                }
                a = await _dbContext.SaveChangesAsync();
            }

            if (a > 0)
            {
                return "Delete Successfully";
            }
            return "Soory!..Something went Wrong";
        }
        public async Task<List<DepartmentResponseModel>> FindEmployeeByDepId(int depId)
        {
            List<Employee> emp = (await _dbContext.employee.ToListAsync()).FindAll(emp => emp.departmentId == depId).ToList();
            List<DepartmentResponseModel> result = new List<DepartmentResponseModel>();
            DepartmentResponseModel dep = new DepartmentResponseModel();
            if (emp != null)
            {
                foreach (Employee e in emp)
                {
                    dep = new DepartmentResponseModel();
                    dep.empId = e.empId;
                    dep.departmentId = depId;
                    dep.empName = e.empName;
                    dep.empEmail = e.empEmail;
                    dep.empPhone = e.empPhone;
                    dep.DateOfBirth = e.DateOfBirth;
                    dep.joinedDate = e.joinedDate;
                    dep.empAge = e.empAge;
                    dep.isActive = e.isActive;
                    dep.isDelete = e.isDelete;
                    dep.lstSalary = new List<SalaryResponseModel>();

                    List<Salary> lstSalary = (await _dbContext.salary.ToListAsync()).FindAll(s => s.empId == dep.empId).ToList();
                    if (lstSalary != null)
                    {
                        SalaryResponseModel sre = new SalaryResponseModel();
                        foreach (Salary s in lstSalary)
                        {
                            sre = new SalaryResponseModel();
                            sre.salaryId = s.salaryId;
                            sre.salaryAmount = s.salaryAmount;
                            sre.isActive = s.isActive;
                            sre.isDelete = s.isDelete;
                        }
                        dep.lstSalary.Add(sre);
                    }
                    result.Add(dep);
                }
            }
            return result;
        }

        public async Task<string> UpdateEmployeeByID(UpdateEmployeeRequest updateEmployeeRequest, [FromRoute] int id)
        {
            int a = 0;
            var v = (await _dbContext.employee.ToListAsync()).FindAll(emp => emp.empId == id).FirstOrDefault(); ;
            if (v != null)
            {
                v.empName = updateEmployeeRequest.empName;
                v.empEmail = updateEmployeeRequest.empEmail;
                v.DateOfBirth = updateEmployeeRequest.DateOfBirth;
                v.empAge = updateEmployeeRequest.empAge;
                v.empPhone = updateEmployeeRequest.empPhone;

                a = await _dbContext.SaveChangesAsync();
            }
            if (a > 0)
            {
                return "Update Successfully";
            }
            return "Soory!..Something went Wrong";


        }

        public async Task<string> deleteDepartment(int departmentId)
        {
            Department dep = await _dbContext.department.FindAsync(departmentId);
            if (dep != null)
            {

                Employee emp = (await _dbContext.employee.ToListAsync()).FindAll(emp => emp.departmentId == dep.departmentId).FirstOrDefault();
                if (emp == null)
                {
                    dep.isDelete = true;
                    dep.isActive = false;
                    await _dbContext.SaveChangesAsync();
                    return "department deleted";

                }
            }
            return "Sorry You Can not Delete this Department";

        }
        //-------------------------EmployeeJoin Controller------------------------
        public async Task<List<EpmloyeeJoinResponseModel>> getAllEmployeeById()
        {
            List<EpmloyeeJoinResponseModel> emp = (from e in _dbContext.employee
                                                   join s in _dbContext.salary
                                                   on e.empId equals s.empId
                                                   select new EpmloyeeJoinResponseModel
                                                   {
                                                       empId = e.empId,
                                                       departmentId = e.departmentId,
                                                       empName = e.empName,
                                                       empAge = e.empAge,
                                                       empPhone = e.empPhone,
                                                       empEmail = e.empEmail,
                                                       DateOfBirth = e.DateOfBirth,
                                                       joinedDate = e.joinedDate,
                                                       isActive = e.isActive,
                                                       isDelete = e.isDelete,
                                                       salaryId = s.salaryId,
                                                       salaryAmount = s.salaryAmount

                                                   }).ToList();

            return emp;
        }
    }
}

