using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAUser:DAParent
    {
        public DAUser(string userParameter) : base(userParameter)
        {

        }

        public ENResult search()
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspSEUserSearch_Result> result = db.uspSEUserSearch(PUser, PReturnCode, PReturnMessage).ToList();
                    return new ENResult(Convert.ToInt32(PReturnCode), Convert.ToString(PReturnMessage), result);
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult insert(uspSEUserSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspSEUserInsert(data.userName,data.idProfile,data.idStore, data.name, data.lastname,data.password,
                        data.userCreated, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode), Convert.ToString(PReturnMessage));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult update(uspSEUserLogin_Result data, string usernameNew)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspSEUserUpdate(data.userName, usernameNew, data.idProfile, data.idStore,data.name,data.lastname,PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode), Convert.ToString(PReturnMessage));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult updatePassword(uspSEUserLogin_Result data, string passwordNew)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspSEUserUpdatePassword(data.userName,data.password,passwordNew, PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode), Convert.ToString(PReturnMessage));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult delete(uspSEUserSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspSEUserDelete(data.userName, PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode), Convert.ToString(PReturnMessage));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }
        public ENResult login(uspSEUserSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspSEUserLogin(data.userName, data.password, PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode), Convert.ToString(PReturnMessage));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

    }
}
