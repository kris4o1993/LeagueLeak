using Kendo.Mvc.UI;
using LeagueLeak.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.Mvc.Extensions;
using System.Web.Mvc;

namespace LeagueLeak.Web.Areas.Administration.Controllers
{
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
    }
}