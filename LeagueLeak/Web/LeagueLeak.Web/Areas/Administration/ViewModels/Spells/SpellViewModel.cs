namespace LeagueLeak.Web.Areas.Administration.ViewModels.Spells
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class SpellViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}