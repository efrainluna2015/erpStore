using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DASupplier:DAParent
    {
        public DASupplier(string userParameter) : base(userParameter)
        {

        }

        public ENResult search()
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspPUSupplierSearch_Result> result = db.uspPUSupplierSearch(PUser, PReturnCode, PReturnMessage).ToList();
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value), result);
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult insert(uspPUSupplierSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspPUSupplierInsert(data.name, data.documentType, data.documentNumber, data.address, 
                            data.phoneNumber, data.email, data.contactPerson, PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult update(uspPUSupplierSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspPUSupplierUpdate(data.idSupplier, data.name, data.documentType, data.documentNumber, data.address,
                            data.phoneNumber, data.email, data.contactPerson, PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult delete(uspPUSupplierSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspPUSupplierDelete(data.idSupplier, PUser, PReturnCode, PReturnMessage);
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
