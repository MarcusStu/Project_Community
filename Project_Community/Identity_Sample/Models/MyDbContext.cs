using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Identity_Sample.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DefaultConnection")
        { }


        public static MyDbContext Create()
        {
            return new MyDbContext();
        }


        public DbSet<Person> People { get; set; }
    }
}