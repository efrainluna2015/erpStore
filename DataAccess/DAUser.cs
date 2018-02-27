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
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value), result);
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
                        PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult update(uspSEUserLogin_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspSEUserUpdate(data.userName, data.idProfile, data.idStore,data.name,data.lastname,PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
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
                    db.uspSEUserUpdatePassword(data.userName,passwordNew, PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
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
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }
        public ENResult login(string userName, string password)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspSEUserLogin_Result> result = db.uspSEUserLogin(userName, password, PUser, PReturnCode, PReturnMessage).ToList();
                    if ( result.Count > 0 && Convert.ToInt32(PReturnCode.Value)==0)  
                    {
                        ENUser user = new ENUser();
                        user.userName = result[0].userName;
                        user.idProfile = result[0].idProfile;
                        user.idStore = result[0].idStore;
                        user.name = result[0].name;
                        user.lastname = result[0].lastname;
                        user.profileName = result[0].profileName;
                        user.storeName = result[0].storeName;
                        user.actions = new List<ENUserAction>();
                        List<uspSEUserProfileActionSearch_Result> actions =  db.uspSEUserProfileActionSearch(userName, PUser, PReturnCode, PReturnMessage).ToList();

                        for (int i =0; i< actions.Count; i++)
                        {
                            user.actions.Add(new ENUserAction(actions[i].code, actions[i].name));
                        }
                        
                        return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value), user);
                    }
                    else
                    {
                        return new ENResult(3, "Usuario o clave incorrecta");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

    }
}
