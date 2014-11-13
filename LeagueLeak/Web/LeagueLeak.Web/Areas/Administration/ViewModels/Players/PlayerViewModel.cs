using LeagueLeak.Infrastructure.Mapping;
using LeagueLeak.Models;
using LeagueLeak.Web.Areas.Administration.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueLeak.Web.Areas.Administration.ViewModels.Players
{
    public class PlayerViewModel : AdministrationViewModel, IMapFrom<Player>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        public string Name { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public int Assists { get; set; }

        public int Rating { get; set; }
    }
}