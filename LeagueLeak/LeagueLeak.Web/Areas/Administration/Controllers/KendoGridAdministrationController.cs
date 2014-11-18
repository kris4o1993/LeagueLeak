namespace LeagueLeak.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Data.Entity;
    using System.Web.Mvc;

    using AutoMapper;
    using LeagueLeak.Data;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using System.Linq;

    public abstract class KendoGridAdministrationController : AdminController
    {
        public KendoGridAdministrationController(IApplicationData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.GetData().ToDataSourceResult(request);
            return this.Json(data);
        }

        [NonAction]
        protected virtual T Create<T>(object model) where T : class
        {
            //for debug purposes
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (model != null && ModelState.IsValid)
            {
                var databaseModel = Mapper.Map<T>(model);
                this.ChangeEntityStateAndSave(databaseModel, EntityState.Added);
                return databaseModel;
            }

            return null;
        }

        [NonAction]
        protected virtual void Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : class
            where TViewModel : class
        {
            if (model != null && ModelState.IsValid)
            {
                var databaseModel = this.GetById<TModel>(id);
                Mapper.Map<TViewModel, TModel>(model, databaseModel);
                this.ChangeEntityStateAndSave(databaseModel, EntityState.Modified);
            }
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        protected abstract IEnumerable GetData();

        protected abstract T GetById<T>(object id) where T : class;

        private void ChangeEntityStateAndSave(object databaseModel, EntityState state)
        {
            var entry = this.Data.Context.Entry(databaseModel);
            entry.State = state;
            this.Data.SaveChanges();
        }
    }
}