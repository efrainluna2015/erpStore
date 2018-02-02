using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRProfileActionController : PRParentController
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    DAProfileAction profileAction = new DAProfileAction(PUser);
                    ENResult result = profileAction.search();
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
        public JsonResult insert(int idProfile, string code)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspSEProfileActionSearch_Result data = new uspSEProfileActionSearch_Result();
                    data.idProfile = idProfile;
                    data.code = code;                    
                    DAProfileAction profileAction = new DAProfileAction(PUser);
                    ENResult result = profileAction.insert(data);
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
        public JsonResult delete(int idProfile, string code)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspSEProfileActionSearch_Result data = new uspSEProfileActionSearch_Result();
                    data.idProfile = idProfile;
                    data.code = code;
                    DAProfileAction profileAction = new DAProfileAction(PUser);
                    ENResult result = profileAction.delete(data);
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