using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRProductBarcodeController : PRParentController
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    DAProductBarcode barcode = new DAProductBarcode(PUser);
                    ENResult result = barcode.search();
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
        public JsonResult insert(int idProduct, string productBarcode)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspGEProductBarcodeSearch_Result data = new uspGEProductBarcodeSearch_Result();
                    data.idProduct = idProduct;  
                    data.barcode = productBarcode;
                    DAProductBarcode barcode = new DAProductBarcode(PUser);
                    ENResult result = barcode.insert(data);
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
        public JsonResult delete(int idProduct, string productBarcode)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspGEProductBarcodeSearch_Result data = new uspGEProductBarcodeSearch_Result();
                    data.idProduct = idProduct;
                    data.barcode = productBarcode;
                    DAProductBarcode barcode = new DAProductBarcode(PUser);
                    ENResult result = barcode.delete(data);
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