using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetCoreApp.Web.Models;

namespace AspNetCoreApp.Web.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<AspNetCoreApp.Web.Models.Category> Category { get; set; }
    }
}
