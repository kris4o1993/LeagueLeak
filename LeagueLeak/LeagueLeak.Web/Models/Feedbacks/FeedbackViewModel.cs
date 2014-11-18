namespace LeagueLeak.Web.Models.Feedbacks
{
    using LeagueLeak.Models;
    using LeagueLeak.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class FeedbackViewModel : IMapFrom<Feedback>
    {
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        [UIHint("SingleLineText")]
        [AllowHtml]
        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [MinLength(5)]
        [UIHint("MultiLineText")]
        [AllowHtml]
        public string Content { get; set; }
    }
}