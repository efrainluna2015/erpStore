using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAProductPrice:DAParent
    {
        public DAProductPrice(string userParameter) : base(userParameter)
        {

        }

        public ENResult search()
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspGEProductPriceSearch_Result> result = db.uspGEProductPriceSearch(PUser, PReturnCode, PReturnMessage).ToList();
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value), result);
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult insert(uspGEProductPriceSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspGEProductPriceInsert(data.idProduct,data.purchasePrice,data.wholesalePrice,data.wholesaleMinPrice,
                        data.retailPrice,data.retailMinPrice,data.partPrice,data.userCreated, PReturnCode, PReturnMessage);
                    db.uspGEProductPriceAuditInsert(data.idProduct, data.purchasePrice, data.wholesalePrice, data.wholesaleMinPrice,
                        data.retailPrice, data.retailMinPrice, data.partPrice, data.userCreated, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult update(uspGEProductPriceSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspGEProductPriceUpdate(data.idProduct, data.purchasePrice, data.wholesalePrice, data.wholesaleMinPrice,
                        data.retailPrice, data.retailMinPrice, data.partPrice, data.userUpdated, PReturnCode, PReturnMessage);
                    db.uspGEProductPriceAuditInsert(data.idProduct, data.purchasePrice, data.wholesalePrice, data.wholesaleMinPrice,
                        data.retailPrice, data.retailMinPrice, data.partPrice, data.userUpdated, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult delete(uspGEProductPriceSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspGEProductPriceDelete(data.idProduct, PUser, PReturnCode, PReturnMessage);
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
