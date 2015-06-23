using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public partial class Entities
    {
        public DbSet<Department> Departments { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public int Floor{ get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}