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
            public int ID { get; set; }

            public string Title { get; set; }

            public List<string> ForumSection { get; set; }
        }

        public class ForumSectionViewModel
        {
            public int ID { get; set; }

            public string Title { get; set; }
        }
    }
}