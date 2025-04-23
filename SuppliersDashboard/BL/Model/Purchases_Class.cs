using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class Purchases_Class
    {
        public class Result
        {
            public int Record_ID { get; set; }
            public string uuid { get; set; }
            public string submissionUUID { get; set; }
            public string longId { get; set; }
            public string internalId { get; set; }
            public string typeName { get; set; }
            public string documentTypeNamePrimaryLang { get; set; }
            public string documentTypeNameSecondaryLang { get; set; }
            public string typeVersionName { get; set; }
            public string issuerId { get; set; }
            public string issuerName { get; set; }
            public string receiverId { get; set; }
            public string _dateTimeIssued { get; set; }
            public string receiverName { get; set; }
            public Nullable<System.DateTime> dateTimeIssued { get; set; }
            public Nullable<System.DateTime> dateTimeReceived { get; set; }
            public string totalSales { get; set; }
            public string totalDiscount { get; set; }
            public string netAmount { get; set; }
            public string total { get; set; }
            public string maxPercision { get; set; }
            public string invoiceLineItemCodes { get; set; }
            public string cancelRequestDate { get; set; }
            public string rejectRequestDate { get; set; }
            public string cancelRequestDelayedDate { get; set; }
            public string rejectRequestDelayedDate { get; set; }
            public string declineCancelRequestDate { get; set; }
            public string declineRejectRequestDate { get; set; }
            public string documentStatusReason { get; set; }
            public string status { get; set; }
            public string createdByUserId { get; set; }
            public string RejectReason { get; set; }
            public Nullable<int> ComID { get; set; }
            public Nullable<int> sendToeta { get; set; }
            public string Response { get; set; }
            public string Editor { get; set; }
            public Nullable<System.DateTime> RejectDate { get; set; }
        }

        public class Metadata
        {
            public int totalPages { get; set; }
            public int totalCount { get; set; }
        }

        public class Root
        {
            public List<Result> result { get; set; }
            public Metadata metadata { get; set; }
        }
    }
}