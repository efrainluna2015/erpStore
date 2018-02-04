using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRSaleController : PRParentController
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    DASale sale = new DASale(PUser);
                    ENResult result = sale.search();
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
        public JsonResult insert(string documentType, string documentNumber, DateTime date, string status,Array detail)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspSASaleSearch_Result data = new uspSASaleSearch_Result();
                    data.documentType = documentType;
                    data.documentNumber = documentNumber;
                    data.date = date;
                    data.status = status;
                    List<uspSASaleDetailSearch_Result> saleDetail = new List<uspSASaleDetailSearch_Result>();
                    for (int i = 0; i < detail.Length; i++)
                    {
                        if (detail != null)
                        {
                       
                            saleDetail[i].idSale = data.idSale;
                            saleDetail[i].idProduct = Convert.ToInt32(detail);
                            saleDetail[i].quantity = Convert.ToInt32(detail);
                            saleDetail[i].unitPrice = Convert.ToDecimal(detail);
                            saleDetail[i].partSale = Convert.ToBoolean(detail);
                        }
                    }
                    DASale sale = new DASale(PUser);
                    ENResult result = sale.insert(data, saleDetail);
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
        public JsonResult update(int idSale, string documentType, string documentNumber, DateTime date, string status)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspSASaleSearch_Result data = new uspSASaleSearch_Result();
                    data.idSale = idSale;
                    data.documentType = documentType;
                    data.documentNumber = documentNumber;                                       
                    data.date = date;
                    data.status = status;
                    DASale sale = new DASale(PUser);
                    ENResult result = sale.update(data);
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
                    uspSASaleSearch_Result data = new uspSASaleSearch_Result();
                    data.idSale = id;
                    DASale sale = new DASale(PUser);
                    ENResult result = sale.delete(data);
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