using LeagueLeak.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using LeagueLeak.Web.Models.Guides;
using LeagueLeak.Web.Models.Home;

namespace LeagueLeak.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data)
            :base(data)
        {
        }

        public ActionResult Index()
        {
            var indexViewModel = this.Data.Articles.All()
                .Project().To<IndexArticlesViewModel>().ToList();

            return View(indexViewModel);
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}