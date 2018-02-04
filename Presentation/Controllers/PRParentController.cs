using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRParentController : Controller
    {
        public string PUser { get; set; }
        public JsonResult PUnexpectedError(Exception ex)
        {
            ENResult result = new ENResult(2, ex.Message);
            result.token = PCreateToken();
            return Json(result);
        }

        public JsonResult PSecurityError()
        {
            return Json(new ENResult(3,"No tiene acceso"));
        }

        public Boolean PValidateHeader(string headerParameter)
        {
            String[] temp = headerParameter.Split(' '); 
            if (temp.Length == 3 )
            {
                if (PValidateToken(temp[1]))
                {
                    PUser = temp[2];
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }       
        }

        public Boolean PValidateToken(string tokenParameter)
        {
            return true;
        }

        public string PCreateToken()
        {
            return "prueba";
        }
    }
}