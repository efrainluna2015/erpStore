using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PREntryController : PRParentController
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    DAEntry entry = new DAEntry(PUser);
                    ENResult result = entry.search();
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
        public JsonResult searchDetail(int idEntry)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    DAEntry entry = new DAEntry(PUser);
                    ENResult result = entry.searchDetail(idEntry);
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
        public JsonResult searchDetailProperty(int idEntry)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    DAEntry entry = new DAEntry(PUser);
                    ENResult result = entry.searchDetailProperty(idEntry);
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
        public JsonResult insert(int idStore, int idSupplier, string entryType, DateTime date, IList<ENEntryDetail> listDetail)        
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspWAEntrySearch_Result data = new uspWAEntrySearch_Result();
                    data.idStore = idStore;
                    data.idSupplier = idSupplier;
                    data.entryType = entryType;
                    data.date = date;
                    DAEntry entry = new DAEntry(PUser);
                    ENResult result = entry.insert(data, listDetail);
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
        public JsonResult update(int id, int idStore, int idSupplier, string entryType, DateTime date, IList<ENEntryDetail> listDetail, IList<ENEntryDetail> listDetailDelete)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspWAEntrySearch_Result data = new uspWAEntrySearch_Result();
                    data.idEntry = id;
                    data.idStore = idStore;
                    data.idSupplier = idSupplier;
                    data.entryType = entryType;
                    data.date = date;
                    DAEntry entry = new DAEntry(PUser);
                    ENResult result = entry.update(data, listDetail, listDetailDelete);
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
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspWAEntrySearch_Result data = new uspWAEntrySearch_Result();
                    data.idEntry = id;
                    DAEntry entry = new DAEntry(PUser);
                    ENResult result = entry.delete(data);
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