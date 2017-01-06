using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identity_Sample.Models
{
    public class ViewModelForum
    {
        public class IndexViewModel
        {
            public ForumThread MyThread { get; set; }
            public string Title { get; set; }
        }
    }
}