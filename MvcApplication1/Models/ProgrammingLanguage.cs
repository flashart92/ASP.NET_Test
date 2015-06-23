using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public partial class Entities
    {
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }

    public class ProgrammingLanguage
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}