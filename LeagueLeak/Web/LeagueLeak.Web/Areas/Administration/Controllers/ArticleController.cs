namespace LeagueLeak.Web.Areas.Administration.Controllers
{
    using Kendo.Mvc.UI;
    using LeagueLeak.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using LeagueLeak.Web.Areas.Administration.ViewModels.Articles;
    using AutoMapper;
    using LeagueLeak.Models;

    public class ArticleController : AdminController
    {
        public ArticleController(IApplicationData data)
            : base(data)
        {

        }

        // GET: Administration/Article
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var articles = this.Data.Articles.All().ToDataSourceResult(request);
            return this.Json(articles);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ArticleViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<Article>(model);
                this.Data.Articles.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ArticleViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var article = this.Data.Articles.Find(model.Id.Value);
                Mapper.Map(model, article);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ArticleViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Articles.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}