using LeagueLeak.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;

namespace LeagueLeak.Web.Controllers
{
    public class PlayersController : BaseController
    {
        public PlayersController(IApplicationData data)
            :base(data)
        {
            
        }

        //[HttpGet]
        //public ActionResult Details(int id)
        //{
        //    var champ = this.Data.Players.All().Where(a => a.Id == id).Project().To<>().FirstOrDefault();
        //
        //    return View(champ);
        //}
    }
}