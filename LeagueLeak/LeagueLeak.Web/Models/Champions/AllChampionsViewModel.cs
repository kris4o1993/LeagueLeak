using AutoMapper;
using LeagueLeak.Models;
using LeagueLeak.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueLeak.Web.Models.Champions
{
    public class ChampionViewModel : IMapFrom<Champion>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ChampionName { get; set; }

        public string Role { get; set; }

        public int Defense { get; set; }

        public int Magic { get; set; }

        public int Difficulty { get; set; }

        public int Attack { get; set; }

        public string ImagePath { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Champion, ChampionViewModel>()
                .ForMember(m => m.ChampionName, opt => opt.MapFrom(c => c.Name))
                .ForMember(m => m.Role, opt => opt.MapFrom(c => c.Role))
                .ForMember(m => m.Defense, opt => opt.MapFrom(c => c.Defense))
                .ForMember(m => m.Magic, opt => opt.MapFrom(c => c.Magic))
                .ForMember(m => m.Difficulty, opt => opt.MapFrom(c => c.Difficulty))
                .ForMember(m => m.Attack, opt => opt.MapFrom(c => c.Attack))
                .ForMember(m => m.ImagePath, opt => opt.MapFrom(c => c.ImagePath))
                .ReverseMap();
        }
    }
}