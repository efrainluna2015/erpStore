using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAEntry:DAParent
    {
        public DAEntry(string userParameter) : base(userParameter)
        {

        }

        public ENResult search()
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspWAEntrySearch_Result> result = db.uspWAEntrySearch(PUser, PReturnCode, PReturnMessage).ToList();
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value), result);
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult insert(uspWAEntrySearch_Result data, List<uspWAEntryDetailSearch_Result> detail, List<uspWAEntryDetailPropertySearch_Result> property)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    ObjectParameter objIdEntry = new ObjectParameter("idEntry", 0);
                    db.uspWAEntryInsert(data.idSource,data.entryType,data.date, PUser, objIdEntry, PReturnCode, PReturnMessage);
                    if (Convert.ToInt32(PReturnCode.Value) == 0){
                        int codeTemp = 0;
                        string messageTemp = "";
                        for (int i=0; i< detail.Count; i++) {
                            db.uspWAEntryDetailInsert(Convert.ToInt32(objIdEntry), detail[i].idProduct, detail[i].quantity, detail[i].purchasePrice, detail[i].dueDate, PUser, PReturnCode, PReturnMessage);
                            codeTemp = Convert.ToInt32(PReturnCode.Value);
                            messageTemp = Convert.ToString(PReturnMessage.Value);
                            for (int j = 0; j < property.Count; j++)
                            {
                                db.uspWAEntryDetailPropertyInsert(Convert.ToInt32(objIdEntry), detail[i].idProduct, property[j].idProperty, property[j].value, PUser, PReturnCode, PReturnMessage);
                                if (Convert.ToInt32(PReturnCode.Value) != 0)
                                {
                                    break;
                                }
                            }
                            if (codeTemp != 0){
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

        public ENResult update(uspWAEntrySearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspWAEntryUpdate(data.idEntry, data.idSource, data.entryType, data.date, PUser, PReturnCode, PReturnMessage);
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult delete(uspWAEntrySearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspWAEntryDelete(data.idEntry, PUser, PReturnCode, PReturnMessage);
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