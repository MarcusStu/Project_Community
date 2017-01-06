using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project_Main.Models
{
    public class ForumContext : DbContext
    {
        public ForumContext() : base("DefaultConnection")
        { }


        public static ForumContext Create()
        {
            return new ForumContext();
        }


        public DbSet<ForumSection> ForumSections { get; set; }
        public DbSet<ForumThread> ForumThreads { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
    }
}