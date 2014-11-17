namespace LeagueLeak.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using LeagueLeak.Data;
    using Kendo.Mvc.UI;
    using Model = LeagueLeak.Models.Champion;
    using ViewModel = LeagueLeak.Web.Areas.Administration.Models.Champions.ChampionViewModel;

    public class ChampionsController : KendoGridAdministrationController
    {
        public ChampionsController(IApplicationData data)
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
                var champion = this.Data.Champions.Find(model.Id);

                this.Data.SaveChanges();

                this.Data.Champions.Delete(champion);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            var champions = this.Data.Champions.All().Project().To<ViewModel>();
            return champions;
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Champions.Find(id) as T;
        }
    }
}