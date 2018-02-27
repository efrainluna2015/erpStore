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

        public ENResult searchDetail(int idEntry)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspWAEntryDetailSearch_Result> detail = db.uspWAEntryDetailSearch(idEntry,PUser, PReturnCode, PReturnMessage).ToList();
                    ENResult propertyResult = searchDetailProperty(idEntry);
                    List<uspWAEntryDetailPropertySearch_Result> listProperty = (List<uspWAEntryDetailPropertySearch_Result>)propertyResult.result;
                    List<ENEntryDetail> listProduct = new List<ENEntryDetail>();
                    for (int i=0; i<detail.Count; i++)
                    {
                        ENEntryDetail temp = new ENEntryDetail();
                        temp.idEntry = detail[i].idEntry;
                        temp.idProduct = (int)detail[i].idProduct;
                        temp.idEntryDetail = detail[i].idEntryDetail;
                        temp.name = detail[i].name;
                        temp.perishable =(bool)detail[i].perishable;
                        temp.quantity = detail[i].quantity;
                        temp.purchasePrice = detail[i].purchasePrice;
                        if (detail[i].dueDate != null)
                        {
                            temp.dueDate = (DateTime)detail[i].dueDate;
                        }
                        List<ENEntryDetailProperty> tempListProperty = new List<ENEntryDetailProperty>();
                        List<uspWAEntryDetailPropertySearch_Result> tempListPropertySelect = listProperty.Where(row => row.idEntry == temp.idEntry && row.idEntryDetail == temp.idEntryDetail).ToList();
                        for (int j=0; j< tempListPropertySelect.Count; j++)
                        {
                            ENEntryDetailProperty tempProperty = new ENEntryDetailProperty();
                            tempProperty.idEntry = tempListPropertySelect[j].idEntry;
                            tempProperty.idEntryDetail = tempListPropertySelect[j].idEntryDetail;
                            tempProperty.idProduct = tempListPropertySelect[j].idProduct;
                            tempProperty.idProperty = tempListPropertySelect[j].idProperty;
                            tempProperty.value = tempListPropertySelect[j].value;
                            tempProperty.name = tempListPropertySelect[j].name;
                            tempListProperty.Add(tempProperty);
                        }
                        temp.listDetailProperty = tempListProperty;
                        listProduct.Add(temp);
                    }
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value), listProduct);
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult searchDetailProperty(int idEntry)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspWAEntryDetailPropertySearch_Result> result = db.uspWAEntryDetailPropertySearch(idEntry, PUser, PReturnCode, PReturnMessage).ToList();
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value), result);
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        public ENResult insert(uspWAEntrySearch_Result data, IList<ENEntryDetail> listDetail)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    ObjectParameter objIdEntry = new ObjectParameter("idEntry", 0);
                    db.uspWAEntryInsert(data.idStore, data.idSupplier, data.entryType,data.date, PUser, objIdEntry, PReturnCode, PReturnMessage);
                    if (Convert.ToInt32(PReturnCode.Value) == 0)
                    {
                        if (listDetail != null)
                        {
                            for (int i = 0; i < listDetail.Count; i++)
                            {
                                ENEntryDetail temp = listDetail[i];
                                string due = "";
                                if(temp.dueDate.Year != 1)
                                {
                                    due = temp.dueDate.ToString("yyyy-MM-dd");
                                }
                                // objIdEntryDetail out put * faltaa
                                ObjectParameter objIdEntryDetail = new ObjectParameter("idEntryDetail", 0);
                                db.uspWAEntryDetailInsert(Convert.ToInt32(objIdEntry.Value), temp.idProduct, temp.quantity, temp.purchasePrice, due, PUser, objIdEntryDetail, PReturnCode, PReturnMessage);
                                int codeTemp = Convert.ToInt32(PReturnCode.Value);
                                string messageTemp = Convert.ToString(PReturnMessage.Value);
                                if (listDetail[i].listDetailProperty != null)
                                {
                                    for (int j = 0; j < listDetail[i].listDetailProperty.Count; j++)
                                    {
                                        ENEntryDetailProperty tempProperty = listDetail[i].listDetailProperty[j];
                                        db.uspWAEntryDetailPropertyInsert(Convert.ToInt32(objIdEntry.Value), Convert.ToInt32(objIdEntryDetail.Value),  tempProperty.idProduct, tempProperty.idProperty, tempProperty.value, PUser, PReturnCode, PReturnMessage);
       
                                        if (Convert.ToInt32(PReturnCode.Value) != 0)
                                        {
                                            break;
                                        }
                                    }
                                }
                                if (Convert.ToInt32(PReturnCode.Value) != 0)
                                {
                                    break;
                                }
                            }
                            return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value));
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

        public ENResult update(uspWAEntrySearch_Result data, IList<ENEntryDetail> listDetail, IList<ENEntryDetail> listDetailDelete)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspWAEntryUpdate(data.idEntry, data.idStore, data.idSupplier, data.entryType, data.date, PUser, PReturnCode, PReturnMessage);
                    if (Convert.ToInt32(PReturnCode.Value) == 0)
                    {
                        if (listDetail != null)
                        {
                            for (int i = 0; i < listDetail.Count; i++)
                            {
                                ENEntryDetail temp = listDetail[i];
                                string due = "";
                                if (temp.dueDate.Year != 1)
                                {
                                    due = temp.dueDate.ToString("yyyy-MM-dd");
                                }
                                if(temp.idEntryDetail == 0)
                                {
                                    ObjectParameter objIdEntryDetail = new ObjectParameter("idEntryDetail", 0);
                                    db.uspWAEntryDetailInsert(data.idEntry, temp.idProduct, temp.quantity, temp.purchasePrice, due, PUser, objIdEntryDetail, PReturnCode, PReturnMessage);
                                    int codeTemp = Convert.ToInt32(PReturnCode.Value);
                                    string messageTemp = Convert.ToString(PReturnMessage.Value);
                                    if (listDetail[i].listDetailProperty != null)
                                    {
                                        for (int j = 0; j < listDetail[i].listDetailProperty.Count; j++)
                                        {
                                            ENEntryDetailProperty tempProperty = listDetail[i].listDetailProperty[j];
                                            db.uspWAEntryDetailPropertyInsert(data.idEntry, Convert.ToInt32(objIdEntryDetail.Value), tempProperty.idProduct, tempProperty.idProperty, tempProperty.value, PUser, PReturnCode, PReturnMessage);
                                 
                                            if (Convert.ToInt32(PReturnCode.Value) != 0)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    if (Convert.ToInt32(PReturnCode.Value) != 0)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    db.uspWAEntryDetailUpdate(data.idEntry, temp.idEntryDetail, temp.quantity, temp.purchasePrice, due , PUser, PReturnCode, PReturnMessage);
                                    
                                    if (listDetail[i].listDetailProperty != null)
                                    {
                                        for (int j = 0; j < listDetail[i].listDetailProperty.Count; j++)
                                        {
                                            ENEntryDetailProperty tempProperty = listDetail[i].listDetailProperty[j];
                                            db.uspWAEntryDetailPropertyUpdate(data.idEntry, temp.idEntryDetail, tempProperty.idProduct, tempProperty.idProperty, tempProperty.value, PUser, PReturnCode, PReturnMessage);

                                            if (Convert.ToInt32(PReturnCode.Value) != 0)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    if (Convert.ToInt32(PReturnCode.Value) != 0)
                                    {
                                        break;
                                    }
                                }
                                if (Convert.ToInt32(PReturnCode.Value) != 0)
                                {
                                    break;
                                }
                            }
                        }
                        if (listDetailDelete != null)
                        {
                            for (int i = 0; i < listDetailDelete.Count; i++)
                            {
                                ENEntryDetail temp = listDetailDelete[i];
                                db.uspWAEntryDetailDelete(temp.idEntryDetail, data.idEntry, PUser, PReturnCode, PReturnMessage);
                                db.uspWAEntryDetailPropertyDelete(temp.idEntryDetail, data.idEntry, PUser, PReturnCode, PReturnMessage);
                                if (Convert.ToInt32(PReturnCode.Value) != 0)
                                {
                                    break;
                                }
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