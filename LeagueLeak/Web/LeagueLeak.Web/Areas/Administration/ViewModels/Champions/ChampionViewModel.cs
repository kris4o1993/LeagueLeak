namespace LeagueLeak.Web.Areas.Administration.ViewModels.Champions
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

    public class ChampionViewModel : AdministrationViewModel, IMapFrom<Champion>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Display(Name = "Champion name")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Display(Name = "Role")]
        [Required]
        public string Role { get; set; }

        [Display(Name = "Avatar")]
        public string ImagePath { get; set; }

        [Display(Name = "Defense")]
        [Required]
        [Range(1, 10)]
        public int Defense { get; set; }

        [Display(Name = "Magic")]
        [Required]
        [Range(1, 10)]
        public int Magic { get; set; }

        [Display(Name = "Difficulty")]
        [Required]
        [Range(1, 10)]
        public int Difficulty { get; set; }

        [Display(Name = "Attack")]
        [Required]
        [Range(1, 10)]
        public int Attack { get; set; }
    }
}