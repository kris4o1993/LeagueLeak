using LeagueLeak.Models;
using LeagueLeak.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueLeak.Web.Areas.Administration.Models.Guides
{
    public class GuideViewModel : IMapFrom<Guide>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [UIHint("SingleLineText")]
        [Display(Name = "Title")]
        [AllowHtml]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        [UIHint("MultiLineText")]
        [Display(Name = "Content")]
        [AllowHtml]
        public string Content { get; set; }

        [Display(Name = "Champion")]
        [UIHint("DropDownList")]
        public int ChampionId { get; set; }

        public IEnumerable<SelectListItem> ChampionNames { get; set; }

        [Display(Name = "Spell")]
        [UIHint("DropDownList")]
        public int SpellId { get; set; }

        public IEnumerable<SelectListItem> SpellNames { get; set; }
    }
}