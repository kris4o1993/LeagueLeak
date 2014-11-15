using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueLeak.Web.Controllers
{
    public class ArticlesController : Controller
    {

        // GET: Questions
        public ActionResult Display(int id, string url)
        {
            return Content(id + " " + url);
        }
    }
}