namespace LeagueLeak.Web.Areas.Administration.Models.Champions
{
    using LeagueLeak.Models;
    using LeagueLeak.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ChampionViewModel : IMapFrom<Champion>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [AllowHtml]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        public string Role { get; set; }


        [Required]
        [Range(1, 10)]
        public int Defense { get; set; }

        [Required]
        [Range(1, 10)]
        public int Magic { get; set; }

        [Required]
        [Range(1, 10)]
        public int Difficulty { get; set; }

        [Required]
        [Range(1, 10)]
        public int Attack { get; set; }
    }
}