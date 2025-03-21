﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Blog : IEntity
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }

        // Category
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        // Yorumlar
        public List<Comment> Comments { get; set; }

        // Yazar
        public int WriterID { get; set; }
        public AppUser Writer { get; set; }
    }
}
