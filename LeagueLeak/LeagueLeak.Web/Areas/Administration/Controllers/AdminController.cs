using LeagueLeak.Data;
using LeagueLeak.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueLeak.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IApplicationData data)
            : base(data)
        {
        }

    }
}