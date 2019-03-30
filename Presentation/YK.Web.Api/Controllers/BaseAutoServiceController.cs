using YK.Core;
using YK.Core.Data;
using YK.Web.Api.Extensions;
using YK.Web.Framework.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using YK.Web.Framework.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Routing;

namespace YK.Web.Api.Controllers
{
    public partial class BaseAutoServiceController<TEntity, TModel, TService> : BaseController
        where TEntity : BaseEntity
        where TModel : BaseAppEntityModel
        where TService : IServiceBase<TEntity>
    {
        private readonly TService _service;

        public BaseAutoServiceController(TService service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual TModel GetById(int id)
        {
            var entity = _service.GetById(id);
            var entityModel = entity.ToModel<TEntity, TModel>();
            return entityModel;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            var languages = _service.GetAll();
            var languagesModel = languages.Select(x => x.ToModel<TEntity, TModel>()).ToList();
            return View(languagesModel);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(TModel model)
        {
            var entity = model.ToEntity<TEntity, TModel>();
           _service.Insert(entity);
  

            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual ActionResult Update(int id)
        {
            var entity = _service.GetById(id);
            var entityModel = entity.ToModel<TEntity, TModel>();
            return View(entityModel);
        }

        [HttpPost]
        public virtual ActionResult Update(TModel model)
        {
            var entity = _service.GetById(model.Id);
            if (entity == null)
                return View(model);

            entity = model.ToEntity(entity);
            _service.Update(entity);
            return View(model);
        }

        public virtual ActionResult Delete(int id)
        {
            var entity = _service.GetById(id);
            if (entity == null)
                return View(id);

            _service.Delete(entity);

            return RedirectToAction("Index");
        }

    }
}
