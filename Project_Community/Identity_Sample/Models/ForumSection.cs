using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identity_Sample.Models
{
    public class ForumSection
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string addedBy { get; set; }

        public virtual ICollection<ForumThread> ForumThreads { get; set; }

    }
}