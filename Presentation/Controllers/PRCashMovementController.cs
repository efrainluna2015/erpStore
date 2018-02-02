using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PRCashMovementController : PRParentController 
    {
        [HttpPost]
        public JsonResult search()
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    DACashMovement movement = new DACashMovement(PUser);
                    ENResult result = movement.search();
                    result.token = PCreateToken();
                    return Json(result);
                }
                else
                {
                    return PSecurityError();
                }

            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        [HttpPost]
        public JsonResult insert(int idMovement,int idCash, int idSale, DateTime date,  string movementType,
                        decimal amount, decimal amountOpening, decimal amountClosing, string concept)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspTRCashMovementSearch_Result data = new uspTRCashMovementSearch_Result();
                    data.idMovement = idMovement;
                    data.idCash = idCash;
                    data.idSale = idSale;
                    data.date = date;
                    data.movementType = movementType;
                    data.amount = amount;
                    data.amountOpening = amountOpening;
                    data.amountClosing = amountClosing;
                    data.concept = concept;
                    DACashMovement movement = new DACashMovement(PUser);
                    ENResult result = movement.insert(data);
                    result.token = PCreateToken();
                    return Json(result);
                }
                else
                {
                    return PSecurityError();
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }

        [HttpPost]
        public JsonResult update(int idMovement, int idCash, int idSale, DateTime date, string movementType,
                        decimal amount, decimal amountOpening, decimal amountClosing, string concept)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspTRCashMovementSearch_Result data = new uspTRCashMovementSearch_Result();
                    data.idMovement = idMovement;
                    data.idCash = idCash;
                    data.idSale = idSale;
                    data.date = date;
                    data.movementType = movementType;
                    data.amount = amount;
                    data.amountOpening = amountOpening;
                    data.amountClosing = amountClosing;
                    data.concept = concept;
                    DACashMovement movement = new DACashMovement(PUser);
                    ENResult result = movement.update(data);
                    result.token = PCreateToken();
                    return Json(result);
                }
                else
                {
                    return PSecurityError();
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }
        [HttpPost]
        public JsonResult delete(int idMovement, int idCash)
        {
            try
            {
                if (PValidateToken(Request.Headers["Authorization"].ToString()))
                {
                    uspTRCashMovementSearch_Result data = new uspTRCashMovementSearch_Result();
                    data.idMovement = idMovement;
                    data.idCash = idCash;
                    DACashMovement movement = new DACashMovement(PUser);
                    ENResult result = movement.delete(data);
                    result.token = PCreateToken();
                    return Json(result);
                }
                else
                {
                    return PSecurityError();
                }
            }
            catch (Exception ex)
            {
                return PUnexpectedError(ex);
            }
        }
    }
}