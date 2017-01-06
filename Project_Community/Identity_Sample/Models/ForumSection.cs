using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_Main.Models
{
    public class ForumSection
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string addedBy { get; set; }

        public virtual ICollection<ForumThread> ForumThreads { get; set; }
    }
}