using LeagueLeak.Models;
using LeagueLeak.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeagueLeak.Web.Models.Players
{
    public class PlayerDetailsViewModel : IMapFrom<Player>
    {
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public int Assists { get; set; }

        public int Rating { get; set; }

        public double SkillScore { get; set; }
    }
}