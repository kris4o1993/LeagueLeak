using LeagueLeak.Data;
using LeagueLeak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueLeak.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController(IApplicationData data)
        {
            this.Data = data;
        }

        protected IApplicationData Data { get; set; }

        protected ApplicationUser CurrentUser { get; set; }
    }
}