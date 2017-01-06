﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_Main.Models
{
    public class ForumThread
    {
        public int ID { get; set; }

        public int ForumSectionID { get; set; }

        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }

        public virtual ICollection<ForumPost> ForumPosts { get; set; }

    }
}