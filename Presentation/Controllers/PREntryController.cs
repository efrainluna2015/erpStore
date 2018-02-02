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
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
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
        public JsonResult insert(int idSource, string entryType, DateTime date, Array detail)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspWAEntrySearch_Result data = new uspWAEntrySearch_Result();
                    data.idSource = idSource;
                    data.entryType = entryType;
                    List<uspWAEntryDetailSearch_Result> entryDetail = new List<uspWAEntryDetailSearch_Result>();
                    List<uspWAEntryDetailPropertySearch_Result> entryDetailProperty = new List<uspWAEntryDetailPropertySearch_Result>();

                    for (int i = 0; i < detail.Length; i++)
                    {
                        if (detail != null)
                        {
                            entryDetail[i].idProduct = Convert.ToInt32(detail);
                            entryDetail[i].quantity = Convert.ToInt32(detail);
                            entryDetail[i].purchasePrice = Convert.ToDecimal(detail);
                            entryDetail[i].dueDate = Convert.ToDateTime(detail);
                        }
                    }
                    DAEntry entry = new DAEntry(PUser);
                    ENResult result = entry.insert(data, entryDetail, entryDetailProperty);
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
        public JsonResult update(int idEntry, int idSource, string entryType, DateTime date)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspWAEntrySearch_Result data = new uspWAEntrySearch_Result();
                    data.idEntry = idEntry;
                    data.idSource = idSource;
                    data.entryType = entryType;
                    data.date = date;
                    DAEntry entry = new DAEntry(PUser);
                    ENResult result = entry.update(data);
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