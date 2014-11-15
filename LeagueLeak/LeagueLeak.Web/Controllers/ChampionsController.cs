using LeagueLeak.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using LeagueLeak.Web.Models.Champions;

namespace LeagueLeak.Web.Controllers
{
    public class ChampionsController : BaseController
    {
        public ChampionsController(IApplicationData data)
            :base(data)
        {
            
        }

        [HttpGet]
        public ActionResult All()
        {
            var allChampionsModel = this.Data.Champions.All()
                .Project().To<ChampionViewModel>().ToList();

            return View(allChampionsModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var champ = this.Data.Champions.All().Where(c => c.Id == id).Project().To<ChampionViewModel>().FirstOrDefault();
            return View(champ);
        }
    }
}