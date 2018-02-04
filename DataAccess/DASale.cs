using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DASale:DAParent
    {
        public DASale(string userParameter) : base(userParameter)
        {

        }

        public ENResult search()
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspSASaleSearch_Result> result = db.uspSASaleSearch(PUser, PReturnCode, PReturnMessage).ToList();
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value), result);
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult insert(uspSASaleSearch_Result data, List<uspSASaleDetailSearch_Result> detail)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    ObjectParameter objIdSale = new ObjectParameter("idSale", 0);
                    db.uspSASaleInsert(data.documentType, data.documentNumber,data.date,data.ticket,
                                       data.status,data.userCreated, objIdSale,PReturnCode, PReturnMessage);
                    if (Convert.ToInt32(PReturnCode.Value) == 0)
                    {
                        int codeTemp = 0;
                        string messageTemp = "";
                        for (int i = 0; i < detail.Count; i++)
                        {
                            db.uspSASaleDetailInsert(Convert.ToInt32(objIdSale), detail[i].idProduct, detail[i].quantity, detail[i].unitPrice, detail[i].partSale, PUser, PReturnCode, PReturnMessage);
                            codeTemp = Convert.ToInt32(PReturnCode.Value);
                            messageTemp = Convert.ToString(PReturnMessage.Value);
                            if (codeTemp != 0)
                            {
                                break;
                            }
                        }
                        return new ENResult(codeTemp, messageTemp);
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

        public ENResult update(uspSASaleSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspSASaleUpdate(data.idSale, data.documentType, data.documentNumber, data.date, 
                                       data.status, data.userUpdated, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult delete(uspSASaleSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspSASaleDelete(data.idSale, PUser, PReturnCode, PReturnMessage);
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
