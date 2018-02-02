using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRStoreController : PRParentController
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    DAStore store = new DAStore(PUser);
                    ENResult result = store.search();
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
        public JsonResult insert(string name, string address, string processSale)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspGEStoreSearch_Result data = new uspGEStoreSearch_Result();
                    data.name = name;
                    data.address = address;
                    data.processSale = processSale;
                    DAStore store = new DAStore(PUser);
                    ENResult result = store.insert(data);
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
        public JsonResult update( int id, string name, string address, string processSale)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspGEStoreSearch_Result data = new uspGEStoreSearch_Result();
                    data.idStore = id;
                    data.name = name;
                    data.address = address;
                    data.processSale = processSale;
                    DAStore store = new DAStore(PUser);
                    ENResult result = store.update(data);
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
        public JsonResult delete(int id)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspGEStoreSearch_Result data = new uspGEStoreSearch_Result();
                    data.idStore = id;
                    DAStore store = new DAStore(PUser);
                    ENResult result = store.delete(data);
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