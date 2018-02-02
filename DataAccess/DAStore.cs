using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAStore: DAParent
    {
        public DAStore(string userParameter) : base(userParameter)
        {

        }

        public ENResult search()
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspGEStoreSearch_Result> result = db.uspGEStoreSearch(PUser, PReturnCode, PReturnMessage).ToList();
                    return new ENResult(Convert.ToInt32(PReturnCode), Convert.ToString(PReturnMessage),result);
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult insert(uspGEStoreSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspGEStoreInsert(data.name, data.address, data.processSale, data.userCreated, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode), Convert.ToString(PReturnMessage));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult update(uspGEStoreSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspGEStoreUpdate(data.idStore, data.name,data.address,data.processSale, data.userUpdated, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode), Convert.ToString(PReturnMessage));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult delete(uspGEStoreSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspGEStoreDelete(data.idStore, PUser, PReturnCode, PReturnMessage);
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
