using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRSupplierController : PRParentController
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    DASupplier supplier = new DASupplier(PUser);
                    ENResult result = supplier.search();
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
        public JsonResult insert(string name, string documentType, string documentNumber, string address,
                          string phoneNumber, string email, string contactPerson)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspPUSupplierSearch_Result data = new uspPUSupplierSearch_Result();
                    data.name = name;
                    data.documentType = documentType;
                    data.documentNumber = documentNumber;
                    data.address = address;
                    data.phoneNumber = phoneNumber;
                    data.email = email;
                    data.contactPerson = contactPerson;
                    DASupplier supplier = new DASupplier(PUser);
                    ENResult result = supplier.insert(data);
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
        public JsonResult update(int id, string name, string documentType, string documentNumber, string address,
                          string phoneNumber, string email, string contactPerson)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspPUSupplierSearch_Result data = new uspPUSupplierSearch_Result();
                    data.idSupplier = id;
                    data.name = name;
                    data.documentType = documentType;
                    data.documentNumber = documentNumber;
                    data.address = address;
                    data.phoneNumber = phoneNumber;
                    data.email = email;
                    data.contactPerson = contactPerson;
                    DASupplier supplier = new DASupplier(PUser);
                    ENResult result = supplier.update(data);
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
                    uspPUSupplierSearch_Result data = new uspPUSupplierSearch_Result();
                    data.idSupplier = id;
                    DASupplier supplier = new DASupplier(PUser);
                    ENResult result = supplier.delete(data);
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