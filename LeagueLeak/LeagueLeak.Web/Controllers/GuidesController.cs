using LeagueLeak.Data;
using LeagueLeak.Web.Models.Guides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using LeagueLeak.Web.Models;

namespace LeagueLeak.Web.Controllers
{
    public class GuidesController : BaseController
    {
        public GuidesController(IApplicationData data)
            : base(data)
        {

        }

        [HttpGet]
        public ActionResult All()
        {
            var allGuidesViewModel = this.Data.Guides.All()
                .Project().To<AllGuidesViewModel>().ToList();

            return View(allGuidesViewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var guide = this.Data.Guides.All().Where(g => g.Id == id).Project().To<GuideDetailsViewModel>().FirstOrDefault();
            var commentsForGuide = this.Data.Comments.All().Where(c => c.GuideId == id).Project().To<CommentsViewModel>().ToList();
            guide.Comments = commentsForGuide;

            return View(guide);
        }

        [Authorize(Roles = "Administrator, Premium")]
        public ActionResult Add()
        {
            var champions = this.Data.Champions.All();
            var championNames = new List<string>();

            foreach (var champion in champions)
            {
                championNames.Add(champion.Name);
            }

            var spells = this.Data.Spells.All();
            var spellNames = new List<string>();

            foreach (var spell in spells)
            {
                spellNames.Add(spell.Name);
            }

            var addGuideViewModel = new AddGuideViewModel()
            {
                ChampionNames = championNames,
                SpellNames = spellNames
            };

            return View(addGuideViewModel);
        }
    }
}