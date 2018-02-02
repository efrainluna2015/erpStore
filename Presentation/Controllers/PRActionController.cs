using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRActionController : PRParentController
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    DAAction action = new DAAction(PUser);
                    ENResult result = action.search();
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
        public JsonResult insert(string code, string name)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspSEActionSearch_Result data = new uspSEActionSearch_Result();
                    data.code = code;
                    data.name = name;
                    DAAction action = new DAAction(PUser);
                    ENResult result = action.insert(data);
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
        public JsonResult update(string codeOld, string codeNew, string name)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspSEActionSearch_Result data = new uspSEActionSearch_Result();
                    data.code = codeOld;
                    data.name = name;
                    DAAction action = new DAAction(PUser);
                    ENResult result = action.update(data, codeNew);
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
        public JsonResult delete(string code)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspSEActionSearch_Result data = new uspSEActionSearch_Result();
                    data.code = code;
                    DAAction action = new DAAction(PUser);
                    ENResult result = action.delete(data);
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