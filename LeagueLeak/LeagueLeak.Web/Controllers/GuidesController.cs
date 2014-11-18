using LeagueLeak.Data;
using LeagueLeak.Web.Models.Guides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using LeagueLeak.Web.Models;
using AutoMapper;
using LeagueLeak.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

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
            var allGuides = this.Data.Guides.All()
                    .Project().To<AllGuidesViewModel>().ToList();

            return View(allGuides);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var guide = this.Data.Guides.All().Where(g => g.Id == id).Project().To<GuideDetailsViewModel>().FirstOrDefault();
            var commentsForGuide = this.Data.Comments.All().Where(c => c.GuideId == id).Project().To<CommentsViewModel>().ToList();
            guide.Comments = commentsForGuide;

            return View(guide);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Premium")]
        public ActionResult Add()
        {
            var championNames = ChampionPopulator();
            var spellNames = SpellPopulator();

            var model = new AddGuideViewModel()
            {
                ChampionNames = championNames,
                SpellNames = spellNames
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Premium")]
        public ActionResult Add(AddGuideViewModel guide)
        {
            if (guide != null && ModelState.IsValid)
            {
                var dbGuide = Mapper.Map<Guide>(guide);
                dbGuide.Author = this.UserProfile;
                dbGuide.AuthorId = this.UserProfile.Id;
                this.Data.Guides.Add(dbGuide);
                this.Data.SaveChanges();
                this.UserProfile.Points++;

                return RedirectToAction("All", "Guides");
            }

            var championNames = ChampionPopulator();
            var spellNames = SpellPopulator();

            guide.ChampionNames = championNames;
            guide.SpellNames = spellNames;

            return View(guide);
        }

        private IEnumerable<SelectListItem> ChampionPopulator()
        {
            var championNames = this.Data.Champions.All().OrderBy(o => o.Name).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return championNames;
        }

        private IEnumerable<SelectListItem> SpellPopulator()
        {
            var spellNames = this.Data.Spells.All().OrderBy(o => o.Name).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return spellNames;
        }
    }
}