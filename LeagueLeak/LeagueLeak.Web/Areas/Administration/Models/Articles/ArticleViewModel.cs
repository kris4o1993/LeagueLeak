using LeagueLeak.Models;
using LeagueLeak.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueLeak.Web.Areas.Administration.Models.Articles
{
    public class ArticleViewModel : IMapFrom<Article>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MinLength(100)]
        public string Content { get; set; }
    }
}