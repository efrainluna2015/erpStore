using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAProfile:DAParent
    {
        public DAProfile(string userParameter) : base(userParameter)
        {

        }

        public ENResult search()
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspSEProfileSearch_Result> result = db.uspSEProfileSearch(PUser, PReturnCode, PReturnMessage).ToList();
                    return new ENResult(Convert.ToInt32(PReturnCode), Convert.ToString(PReturnMessage),result);
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult insert(uspSEProfileSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspSEProfileInsert(data.name, PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode), Convert.ToString(PReturnMessage));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }
        public ENResult update(uspSEProfileSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspSEProfileUpdate(data.idProfile,data.name,PUser,PReturnCode,PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode), Convert.ToString(PReturnMessage));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }
        public ENResult delete(uspSEProfileSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspSEProfileDelete(data.idProfile,PUser, PReturnCode, PReturnMessage);
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
