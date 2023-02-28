using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApp.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime DateTime { get; set; }
        public string ImagePath { get; set; }



        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
