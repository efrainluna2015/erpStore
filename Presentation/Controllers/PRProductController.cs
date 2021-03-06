﻿using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRProductController : PRParentController
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    DAProduct product = new DAProduct(PUser);
                    ENResult result = product.search();
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
        public JsonResult searchProductById(int idProduct)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    DAProduct product = new DAProduct(PUser);
                    ENResult result = product.searchProductById(idProduct);
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
        public JsonResult searchCategory(int idCategory)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    DAProduct product = new DAProduct(PUser);
                    ENResult result = product.searchCategory(idCategory);
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
        public JsonResult insert(int idCategory, int idBrand, string codeUnit, string name, bool divisible,
                        string divisibleCodeUnit, int divisibleNumberParts, bool perishable, bool traceable, 
                        string barcodeType, IList<ENProductProperty> listProperty)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspGEProductSearch_Result data = new uspGEProductSearch_Result();
                    data.idCategory = idCategory;
                    data.idBrand = idBrand;
                    data.codeUnit = codeUnit;
                    data.name = name;
                    data.divisible = divisible;
                    if(divisibleCodeUnit == "")
                    {
                        data.divisibleCodeUnit = null;
                    }
                    else
                    {
                        data.divisibleCodeUnit = divisibleCodeUnit;
                    }
                    if (divisibleNumberParts == 0)
                    {
                        data.divisibleNumberParts = null;
                    }
                    else
                    {
                        data.divisibleNumberParts = divisibleNumberParts;
                    }
                    data.perishable = perishable;
                    data.traceable = traceable;
                    data.barcodeType = barcodeType;
                    DAProduct product = new DAProduct(PUser);
                    ENResult result = product.insert(data, listProperty);
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
        public JsonResult update(int id, int idCategory, int idBrand, string codeUnit, string name, bool divisible,
                        string divisibleCodeUnit, int divisibleNumberParts, bool perishable, bool traceable,
                        string barcodeType, IList<ENProductProperty> listProperty, IList<ENProductProperty> listPropertyDelete)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspGEProductSearch_Result data = new uspGEProductSearch_Result();
                    data.idProduct = id; 
                    data.idCategory = idCategory;
                    data.idBrand = idBrand;
                    data.codeUnit = codeUnit;
                    data.name = name;
                    data.divisible = divisible;
                    data.divisibleCodeUnit = divisibleCodeUnit;
                    data.divisibleNumberParts = divisibleNumberParts;
                    data.perishable = perishable;
                    data.traceable = traceable;
                    data.barcodeType = barcodeType;
                    DAProduct product = new DAProduct(PUser);
                    ENResult result = product.update(data, listProperty, listPropertyDelete);
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
                    uspGEProductSearch_Result data = new uspGEProductSearch_Result();
                    data.idProduct = id;
                    DAProduct product = new DAProduct(PUser);
                    ENResult result = product.delete(data);
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