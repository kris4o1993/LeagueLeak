using LeagueLeak.Models;
using LeagueLeak.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueLeak.Web.Models.Guides
{
    public class AddGuideViewModel : IMapFrom<Guide>, IHaveCustomMappings
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string GuideTitle { get; set; }

        [Required]
        [MinLength(10)]
        public string GuideContent { get; set; }

        public int ChampionId { get; set; }

        public ICollection<string> ChampionNames { get; set; }

        public int SpellId { get; set; }

        public ICollection<string> SpellNames { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Guide, AddGuideViewModel>()
                .ForMember(m => m.GuideTitle, opt => opt.MapFrom(g => g.Title))
                .ForMember(m => m.GuideContent, opt => opt.MapFrom(g => g.Content))
                .ReverseMap();
        }
    }
}