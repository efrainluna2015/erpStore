using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAProduct:DAParent
    {
        public DAProduct(string userParameter) : base(userParameter)
        {

        }

        public ENResult search()
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspGEProductSearch_Result> result = db.uspGEProductSearch(PUser, PReturnCode, PReturnMessage).ToList();
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value),result);
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult insert(uspGEProductSearch_Result data, IList<ENProductProperty> listProperty)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    ObjectParameter objIdProduct = new ObjectParameter("idProduct", 0);
                    db.uspGEProductInsert(data.idCategory,data.idBrand, data.codeUnit, data.name, data.divisible,
                        data.divisibleCodeUnit,data.divisibleNumberParts,data.perishable,data.traceable,data.barcodeType,
                        PUser, objIdProduct, PReturnCode, PReturnMessage);
                    if (Convert.ToInt32(PReturnCode.Value) == 0)
                    {
                        for(int i = 0; i < listProperty.Count; i++)
                        {
                            ENProductProperty temp = listProperty[i];
                            db.uspGEProductPropertyInsert(Convert.ToInt32(objIdProduct.Value), temp.name, temp.abbreviation, temp.required, PUser, PReturnCode, PReturnMessage);
                            if (Convert.ToInt32(PReturnCode.Value) != 0)
                            {
                                break;
                            }
                        }
                        return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));   
                    }
                    else
                    {
                        return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                    }
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult update(uspGEProductSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspGEProductUpdate(data.idProduct, data.idCategory, data.idBrand, data.codeUnit, data.name, data.divisible,
                        data.divisibleCodeUnit, data.divisibleNumberParts, data.perishable, data.traceable, data.barcodeType,
                        PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult delete(uspGEProductSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspGEProductDelete(data.idProduct, PUser, PReturnCode, PReturnMessage);
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
