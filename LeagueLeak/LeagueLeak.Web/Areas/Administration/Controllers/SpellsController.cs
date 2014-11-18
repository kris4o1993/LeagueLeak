namespace LeagueLeak.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using LeagueLeak.Data;
    using Kendo.Mvc.UI;
    using Model = LeagueLeak.Models.Spell;
    using ViewModel = LeagueLeak.Web.Areas.Administration.Models.Spells.SpellViewModel;

    public class SpellsController : KendoGridAdministrationController
    {
        public SpellsController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var databaseModel = base.Create<Model>(model);
            if (databaseModel != null)
            {
                model.Id = databaseModel.Id;
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null)
            {
                var spell = this.Data.Spells.Find(model.Id);

                this.Data.SaveChanges();

                this.Data.Spells.Delete(spell);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            var spells = this.Data.Spells.All().Project().To<ViewModel>();
            return spells;
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Spells.Find(id) as T;
        }
    }
}