using LeagueLeak.Data;
using LeagueLeak.Models;
using LeagueLeak.Web.ViewModels.Guides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueLeak.Web.Controllers
{
    public class GuidesController : BaseController
    {
        public GuidesController(IApplicationData data)
            : base(data)
        {

        }

        // GET: Guides
        public ActionResult All()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new GuideViewModel();
            var spells = this.Data.Spells.All().ToList();
            var champions = this.Data.Champions.All().ToList();

            model.AllChampions = champions;
            model.AllSpells = spells;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guide guide)
        {
            return View();
        }
    }
}