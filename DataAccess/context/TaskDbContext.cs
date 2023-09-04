using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.context
{
    public class TaskDbContext:DbContext
    {
        public TaskDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> employee { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<User>  user { get; set; }
        public DbSet<Salary> salary { get; set;}
   
    }
}
