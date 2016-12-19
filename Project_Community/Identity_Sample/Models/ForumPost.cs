using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Identity_Sample.Models
{
    public class ForumPost
    {
        public int ID { get; set; }

        public int ForumThreadID { get; set; }

        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }
    }
}