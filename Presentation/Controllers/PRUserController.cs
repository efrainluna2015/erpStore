using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRUserController : PRParentController
    {

        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    DAUser user = new DAUser(PUser);
                    ENResult result = user.search();
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
        public JsonResult insert(string userName, int idProfile, int idStore, string name, string lastname, Byte[] password)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspSEUserSearch_Result data = new uspSEUserSearch_Result();
                    data.userName = userName;
                    data.idProfile = idProfile;
                    data.idStore = idStore;
                    data.name = name;
                    data.lastname = lastname;
                    data.password = password;
                    DAUser user = new DAUser(PUser);
                    ENResult result = user.insert(data);
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
        public JsonResult update(string userName, int idProfile, int idStore, string name, string lastname, string usernameNew)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspSEUserLogin_Result data = new uspSEUserLogin_Result();
                    data.userName = userName;
                    data.idProfile = idProfile;
                    data.idStore = idStore;
                    data.name = name;
                    data.lastname = lastname;
                    DAUser user = new DAUser(PUser);
                    ENResult result = user.update(data, usernameNew);
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
        public JsonResult updatePassword(string userName, Byte[] password, string passNew)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspSEUserLogin_Result data = new uspSEUserLogin_Result();
                    data.userName = userName;
                    data.password = password;
                    DAUser user = new DAUser(PUser);
                    ENResult result = user.update(data, passNew);
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
        public JsonResult delete(string userName)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspSEUserSearch_Result data = new uspSEUserSearch_Result();
                    data.userName = userName;
                    DAUser user = new DAUser(PUser);
                    ENResult result = user.delete(data);
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
        public JsonResult login(string userName, Byte[] password)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspSEUserSearch_Result data = new uspSEUserSearch_Result();
                    data.userName = userName;
                    data.password = password;
                    DAUser user = new DAUser(PUser);
                    ENResult result = user.login(data);
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