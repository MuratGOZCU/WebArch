using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YK.Web.Framework.Mvc.Models
{
    public class BaseAppModel
    {
        #region Ctor

        public BaseAppModel()
        {
            CustomProperties = new Dictionary<string, object>();
            PostInitialize();
        }

        #endregion

        #region Methods

        public void BindModel(ModelBindingContext bindingContext)
        {
        }

        protected void PostInitialize()
        {
        }

        #endregion

        #region Properties

        public Dictionary<string, object> CustomProperties { get; set; }

        #endregion

    }

    public class BaseAppEntityModel : BaseAppModel
    {
        public int Id { get; set; }
    }
}
