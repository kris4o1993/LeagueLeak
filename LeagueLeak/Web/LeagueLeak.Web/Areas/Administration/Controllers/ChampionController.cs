namespace LeagueLeak.Web.Areas.Administration.Controllers
{
    using Kendo.Mvc.UI;
    using LeagueLeak.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Kendo.Mvc.Extensions;
    using System.Web.Mvc;
    using LeagueLeak.Web.Areas.Administration.ViewModels.Champions;
    using AutoMapper;
    using LeagueLeak.Models;

    public class ChampionController : AdminController
    {
        public ChampionController(IApplicationData data)
            : base(data)
        {

        }

        // GET: Administration/Champion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var champions = this.Data.
                Champions
                .All()
                .ToDataSourceResult(request);

            return this.Json(champions);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ChampionViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<Champion>(model);
                this.Data.Champions.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ChampionViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var champ = this.Data.Champions.Find(model.Id.Value);
                Mapper.Map(model, champ);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ChampionViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Champions.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}