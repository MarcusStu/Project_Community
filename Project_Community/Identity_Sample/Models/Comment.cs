using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Main.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public int NewsPostID { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }
    }
}