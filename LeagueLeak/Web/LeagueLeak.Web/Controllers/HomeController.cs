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

    public class HomeController : Controller
    {
        private IRepository<Article> news;

        public HomeController(IRepository<Article> news)
        {
            this.news = news;
        }

        public ActionResult Index()
        {
            var news = this.news.All().Project().To<IndexNewsViewModel>();
            return View(news);
        }
    }
}