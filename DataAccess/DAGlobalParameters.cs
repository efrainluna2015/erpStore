using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAGlobalParameters:DAParent
    {
        public DAGlobalParameters(string userParameter) : base(userParameter)
        {

        }

        public ENResult search()
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    List<uspGEGlobalParametersSearch_Result> result = db.uspGEGlobalParametersSearch(PUser, PReturnCode, PReturnMessage).ToList();
                    return new ENResult(Convert.ToInt32(PReturnCode.Value), Convert.ToString(PReturnMessage.Value),result);
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }


        public ENResult update(uspGEGlobalParametersSearch_Result data)
        {
            try
            {
                using (erpStoreEntities db = new erpStoreEntities())
                {
                    db.uspGEGlobalParametersUpdate(data.IGV, data.percentageMinWholesalePrice,data.percentageMinRetailPrice,
                        data.userUpdated, PReturnCode, PReturnMessage);
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
