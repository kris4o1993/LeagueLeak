using LeagueLeak.Models;
using LeagueLeak.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueLeak.Web.Models.Players
{
    public class LeaderboardsViewModel : IMapFrom<Player>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string PlayerName { get; set; }

        public int PlayerRating { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public int Assists { get; set; }

        public double SkillScore { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Player, LeaderboardsViewModel>()
                .ForMember(m => m.PlayerName, opt => opt.MapFrom(g => g.Name))
                .ForMember(m => m.PlayerRating, opt => opt.MapFrom(g => g.Rating))
                .ReverseMap();
        }
    }
}