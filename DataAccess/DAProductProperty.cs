using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAProductProperty:DAParent    
    {
        public DAProductProperty(string userParameter) : base(userParameter)
        {

        }

        public ENResult search(int idProduct)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspGEProductPropertySearch_Result> result = db.uspGEProductPropertySearch(idProduct, PUser, PReturnCode, PReturnMessage).ToList();
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value), result);
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult insert(uspGEProductPropertySearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspGEProductPropertyInsert(data.idProduct, data.name, data.abbreviation, data.required,PUser,PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult update(uspGEProductPropertySearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspGEProductPropertyUpdate(data.idProperty, data.idProduct, data.name, data.abbreviation,
                        data.required,PUser,PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult delete(uspGEProductPropertySearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspGEProductPropertyDelete(data.idProduct,data.idProperty,PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }
    }
}
