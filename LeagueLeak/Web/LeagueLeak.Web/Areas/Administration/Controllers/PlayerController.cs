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
    using LeagueLeak.Web.Areas.Administration.ViewModels.Players;
    using LeagueLeak.Models;
    using AutoMapper;

    public class PlayerController : AdminController
    {
        public PlayerController(IApplicationData data)
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
            var players = this.Data.
                Players
                .All()
                .ToDataSourceResult(request);

            return this.Json(players);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, PlayerViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<Player>(model);
                this.Data.Players.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, PlayerViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var player = this.Data.Players.Find(model.Id.Value);
                Mapper.Map(model, player);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, PlayerViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Players.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}