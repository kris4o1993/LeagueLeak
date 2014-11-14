using LeagueLeak.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueLeak.Web.Controllers
{
    public class GuidesController : BaseController
    {
        public GuidesController(IApplicationData data)
            : base(data)
        {

        }

        // GET: Guides
        public ActionResult All()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}