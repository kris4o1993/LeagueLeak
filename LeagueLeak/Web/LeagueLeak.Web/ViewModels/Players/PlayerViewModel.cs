namespace LeagueLeak.Web.ViewModels.Players
{
    using LeagueLeak.Infrastructure.Mapping;
    using LeagueLeak.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class PlayerViewModel : IMapFrom<Player>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public int Assists { get; set; }

        public int Rating { get; set; }
    }
}