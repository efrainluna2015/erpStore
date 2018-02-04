using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRGlobalParametersController : PRParentController
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    DAGlobalParameters globalParameters = new DAGlobalParameters(PUser);
                    ENResult result = globalParameters.search();
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
        public JsonResult update(decimal IGV, decimal percentageMinWholesalePrice, decimal percentageMinRetailPrice, string name)
        {
            try
            {
                if (PValidateHeader(Request.Headers["Authorization"].ToString()))
                {
                    uspGEGlobalParametersSearch_Result data = new uspGEGlobalParametersSearch_Result();
                    data.IGV = IGV;
                    data.percentageMinWholesalePrice = percentageMinWholesalePrice;
                    data.percentageMinRetailPrice = percentageMinRetailPrice;
                    DAGlobalParameters globalParameters = new DAGlobalParameters(PUser);
                    ENResult result = globalParameters.update(data);
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