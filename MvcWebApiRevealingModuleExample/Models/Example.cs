using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebApiRevealingModuleExample.Models
{
    public class Example
    {
        public virtual int Id { get; set; }
        public virtual string TheWord { get; set; }
        public virtual int Length { get; set; }
    }
}