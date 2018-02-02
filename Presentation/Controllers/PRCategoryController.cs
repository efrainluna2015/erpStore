using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRCategoryController : PRParentController
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    DACategory category = new DACategory(PUser);
                    ENResult result = category.search();
                    result.token = PCreateToken();
                    return Json(result);
                }
                else
                {
                    return PSecurityError();
                }
                
            }
            catch(Exception ex)
            {
                return PUnexpectedError(ex);
            }            
        }

        [HttpPost]
        public JsonResult insert(string name)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspGECategorySearch_Result data = new uspGECategorySearch_Result();
                    data.name = name;
                    DACategory category = new DACategory(PUser);
                    ENResult result = category.insert(data);
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
        public JsonResult update(int idCategory, string name)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspGECategorySearch_Result data = new uspGECategorySearch_Result();
                    data.idCategory = idCategory;
                    data.name = name;
                    DACategory category = new DACategory(PUser);
                    ENResult result = category.update(data);
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
        public JsonResult delete(int idCategory)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspGECategorySearch_Result data = new uspGECategorySearch_Result();
                    data.idCategory = idCategory;
                    DACategory category = new DACategory(PUser);
                    ENResult result = category.delete(data);
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