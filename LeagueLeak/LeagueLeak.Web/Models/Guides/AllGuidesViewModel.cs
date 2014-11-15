using AutoMapper;
using LeagueLeak.Models;
using LeagueLeak.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueLeak.Web.Models.Guides
{
    public class AllGuidesViewModel : IMapFrom<Guide>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string GuideTitle { get; set; }

        public string AuthorName { get; set; }

        public string ChampionName { get; set; }

        public string SpellName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Guide, AllGuidesViewModel>()
                .ForMember(m => m.GuideTitle, opt => opt.MapFrom(g => g.Title))
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(g => g.Author.UserName))
                .ForMember(m => m.ChampionName, opt => opt.MapFrom(g => g.Champion.Name))
                .ForMember(m => m.SpellName, opt => opt.MapFrom(g => g.Spell.Name))
                .ReverseMap();
        }
    }
}