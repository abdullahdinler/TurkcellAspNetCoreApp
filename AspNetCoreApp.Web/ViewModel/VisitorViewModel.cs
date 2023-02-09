using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApp.Web.ViewModel
{
    public class VisitorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
