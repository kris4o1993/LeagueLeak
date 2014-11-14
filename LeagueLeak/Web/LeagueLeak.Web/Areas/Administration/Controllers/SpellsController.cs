using AutoMapper;
using Kendo.Mvc.UI;
using LeagueLeak.Data;
using LeagueLeak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using LeagueLeak.Web.Areas.Administration.ViewModels.Spells;

namespace LeagueLeak.Web.Areas.Administration.Controllers
{
    public class SpellsController : AdminController
    {
        public SpellsController(IApplicationData data)
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
            var spells = this.Data.
                Spells
                .All()
                .ToDataSourceResult(request); 

            return this.Json(spells);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, SpellViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<Spell>(model);
                this.Data.Spells.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, SpellViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var spell = this.Data.Spells.Find(model.Id.Value);
                Mapper.Map(model, spell);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, SpellViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Spells.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}