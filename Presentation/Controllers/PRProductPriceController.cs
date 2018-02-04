using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRProductPriceController : PRParentController
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    DAProductPrice productPrice = new DAProductPrice(PUser);
                    ENResult result = productPrice.search();
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
        public JsonResult insert(int idProduct, decimal purchasePrice, decimal wholesalePrice, decimal wholesaleMinPrice,
                        decimal retailPrice, decimal retailMinPrice, decimal partPrice)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspGEProductPriceSearch_Result data = new uspGEProductPriceSearch_Result();
                    data.idProduct = idProduct;
                    data.purchasePrice = purchasePrice;
                    data.wholesalePrice = wholesalePrice;
                    data.wholesaleMinPrice = wholesaleMinPrice;
                    data.retailPrice = retailPrice;
                    data.retailMinPrice = retailMinPrice;
                    data.partPrice = partPrice;
                    DAProductPrice productPrice = new DAProductPrice(PUser);
                    ENResult result = productPrice.insert(data);
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
        public JsonResult update(int idProduct, decimal purchasePrice, decimal wholesalePrice, decimal wholesaleMinPrice,
                        decimal retailPrice, decimal retailMinPrice, decimal partPrice)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspGEProductPriceSearch_Result data = new uspGEProductPriceSearch_Result();
                    data.idProduct = idProduct;
                    data.purchasePrice = purchasePrice;
                    data.wholesalePrice = wholesalePrice;
                    data.wholesaleMinPrice = wholesaleMinPrice;
                    data.retailPrice = retailPrice;
                    data.retailMinPrice = retailMinPrice;
                    data.partPrice = partPrice;
                    DAProductPrice productPrice = new DAProductPrice(PUser);
                    ENResult result = productPrice.update(data);
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
                    uspGEProductPriceSearch_Result data = new uspGEProductPriceSearch_Result();
                    data.idProduct = id;
                    DAProductPrice productPrice = new DAProductPrice(PUser);
                    ENResult result = productPrice.delete(data);
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