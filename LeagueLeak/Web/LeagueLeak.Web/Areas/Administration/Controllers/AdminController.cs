namespace LeagueLeak.Web.Areas.Administration.Controllers
{
    using LeagueLeak.Data;
    using LeagueLeak.Web.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    //[Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IApplicationData data)
            :base(data)
        {

        }
    }
}