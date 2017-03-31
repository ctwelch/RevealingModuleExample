using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcWebApiRevealingModuleExample.Models
{
    public class ExampleDb : DbContext
    {
        public DbSet<Example> Examples { get; set; }
    }
}