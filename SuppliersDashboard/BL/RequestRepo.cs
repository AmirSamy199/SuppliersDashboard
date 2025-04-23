using ScoposERB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.BL
{
    public class RequestRepo : BrotherServicesValidators
    {
        DeepHelper db = new DeepHelper();
        public bool CompletePendingRequest(int RequestId)
        {
            try
            {
                db.fire($"update BRO_Request_TBL set status = 1 where RecordID = {RequestId}");
                return true;
            }
            catch { return false; }
        } 
        public bool PendingCompleteRequest(int RequestId)
        {
            try
            {
                db.fire($"update BRO_Request_TBL set status = 0 where RecordID = {RequestId}");
                return true;
            }
            catch { return false; }
        }
    }
}