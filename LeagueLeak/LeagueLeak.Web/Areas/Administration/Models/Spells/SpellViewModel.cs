using LeagueLeak.Models;
using LeagueLeak.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueLeak.Web.Areas.Administration.Models.Spells
{
    public class SpellViewModel : IMapFrom<Spell>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [MinLength(10)]
        public string Description { get; set; }
    }
}