using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomersList.Module.BusinessObjects;
using CustomersList.Module.Utils;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web.Editors.ASPx;

namespace CustomersList.Module.Controllers
{
    public class AddressVC : ObjectViewController<DetailView, Address>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            
            RemoveNAFromCity();
        }
        /// <summary>
        /// Убирает первый элемент N/A из списка городов
        /// </summary>
        private void RemoveNAFromCity()
        {
            var lkpCity = View.FindItem("City") as ASPxLookupPropertyEditor;
            if (lkpCity != null)
            {
                XafUtils.RemoveFirstLookupElement(lkpCity);
            }
        }
    }
}
