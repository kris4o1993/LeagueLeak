namespace LeagueLeak.Web.Controllers
{
    using LeagueLeak.Data;
    using LeagueLeak.Data.Repositories;
    using LeagueLeak.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using LeagueLeak.Web.ViewModels.Home;
    using AutoMapper;

    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data)
            :base(data)
        {
            
        }

        public ActionResult Index()
        {
            var articles = this.Data.Articles.All();
            // var news = this.news.All().Project().To<IndexArticlesViewModel>();
            return View(articles);
        }
    }
}