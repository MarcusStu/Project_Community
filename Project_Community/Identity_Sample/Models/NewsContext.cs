using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Identity_Sample.Models
{
    public class NewsContext : DbContext
    {
        public NewsContext() : base("DefaultConnection")
        { }


        public static NewsContext Create()
        {
            return new NewsContext();
        }


        public DbSet<NewsPost> NewsPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}