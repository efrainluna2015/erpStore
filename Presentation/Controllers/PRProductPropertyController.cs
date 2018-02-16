using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRProductPropertyController : PRParentController
    {

        [HttpPost]
        public JsonResult search(int idProduct)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    DAProductProperty property = new DAProductProperty(PUser);
                    ENResult result = property.search(idProduct);
                    result.token = PCreateToken();
                    return Json(result);
                }
                else
                {
                    return PSecurityError();
                }

            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        [HttpPost]
        public JsonResult insert(int idProduct, string name, string abbreviation, bool required)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspGEProductPropertySearch_Result data = new uspGEProductPropertySearch_Result();
                    data.idProduct = idProduct;
                    data.name = name;
                    data.abbreviation = abbreviation;
                    data.required = required;
                    DAProductProperty property = new DAProductProperty(PUser);
                    ENResult result = property.insert(data);
                    result.token = PCreateToken();
                    return Json(result);
                }
                else
                {
                    return PSecurityError();
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        [HttpPost]
        public JsonResult update(int id, int idProduct, string name, string abbreviation, bool required)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspGEProductPropertySearch_Result data = new uspGEProductPropertySearch_Result();
                    data.idProperty = id;
                    data.idProduct = idProduct;
                    data.name = name;
                    data.abbreviation = abbreviation;
                    data.required = required;
                    DAProductProperty property = new DAProductProperty(PUser);
                    ENResult result = property.update(data);
                    result.token = PCreateToken();
                    return Json(result);
                }
                else
                {
                    return PSecurityError();
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        [HttpPost]
        public JsonResult delete(int idProperty, int idProduct)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspGEProductPropertySearch_Result data = new uspGEProductPropertySearch_Result();
                    data.idProperty = idProperty;
                    data.idProduct = idProduct;
                    DAProductProperty property = new DAProductProperty(PUser);
                    ENResult result = property.delete(data);
                    result.token = PCreateToken();
                    return Json(result);
                }
                else
                {
                    return PSecurityError();
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }
    }
}