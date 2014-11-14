using AutoMapper;
using LeagueLeak.Data;
using LeagueLeak.Web.ViewModels.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueLeak.Web.Controllers
{
    public class PlayersController : BaseController
    {
        public PlayersController(IApplicationData data)
            : base(data)
        {

        }

        [HttpPost]
        public ActionResult Display(string name)
        {
            var model = new PlayerViewModel();
            var player = this.Data.Players.All().Where(p => p.Name == name).FirstOrDefault();
            Mapper.Map(player, model);
            return View(model);
        }
    }
}