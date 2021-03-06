﻿namespace LeagueLeak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Article
    {
        private ICollection<Comment> comments;

        public Article()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MinLength(100)]
        public string Content { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
