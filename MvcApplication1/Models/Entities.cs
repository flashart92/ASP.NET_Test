using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public partial class Entities : DbContext
    {
        public Entities()
            : base("DataBase1")
        {
            
        }
    }
}