using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRUnitController : PRParentController
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    DAUnit unit = new DAUnit(PUser);
                    ENResult result = unit.search();
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
                    uspGEUnitSearch_Result data = new uspGEUnitSearch_Result();
                    data.codeUnit = code;
                    data.name = name;
                    DAUnit unit = new DAUnit(PUser);
                    ENResult result = unit.insert(data);
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
                    uspGEUnitSearch_Result data = new uspGEUnitSearch_Result();
                    data.codeUnit = codeOld;
                    data.name = name;
                    DAUnit unit = new DAUnit(PUser);
                    ENResult result = unit.update(data, codeNew);
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
                    uspGEUnitSearch_Result data = new uspGEUnitSearch_Result();
                    data.codeUnit = code;
                    DAUnit unit = new DAUnit(PUser);
                    ENResult result = unit.delete(data);
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