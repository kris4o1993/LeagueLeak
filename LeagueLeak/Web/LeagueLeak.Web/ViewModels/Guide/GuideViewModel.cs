using LeagueLeak.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeagueLeak.Models;

namespace LeagueLeak.Web.ViewModels.Guides
{
    public class GuideViewModel : IMapFrom<Guide>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string SelectedSpellName { get; set; }

        public string SelectedChampionName { get; set; }

        public IEnumerable<Spell> AllSpells { get; set; }

        public IEnumerable<Champion> AllChampions { get; set; }
    }
}