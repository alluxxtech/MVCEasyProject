using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCEasyProject.Models
{
    public class DbConnectionContext : DbContext
    {
        public DbConnectionContext() : base("DbConnectionContext")
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}