using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journals.Web.IoC
{
    public class ImplementedByAttribute : Attribute
    {
        public string FullName { get; set; }
    }
}