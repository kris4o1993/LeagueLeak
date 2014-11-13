namespace LeagueLeak.Web.Areas.Administration.ViewModels.Articles
{
    using LeagueLeak.Infrastructure.Mapping;
    using LeagueLeak.Models;
    using LeagueLeak.Web.Areas.Administration.ViewModels.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ArticleViewModel : AdministrationViewModel, IMapFrom<Article>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [MaxLength(100)]
        [DataType(DataType.MultilineText)]
        public string Title { get; set; }

        [MinLength(100)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Editable(false)]
        public DateTime DateCreated { get; set; }
    }
}