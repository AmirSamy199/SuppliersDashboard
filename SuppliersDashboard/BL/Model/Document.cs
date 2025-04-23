using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class Document
    {
        public class SubmittedDocument
        {

            public string document { get; set; }
            public string transformationStatus { get; set; }
            public ValidationResults validationResults;
            public string maxPercision { get; set; }

            public List<InvoiceLineItemCodes> invoiceLineItemCodes;
            public string uuid { get; set; }
            public string submissionUUID { get; set; }
            public string longId { get; set; }
            public string internalId { get; set; }
            public string typeName { get; set; }
            public string typeVersionName { get; set; }
            public string issuerId { get; set; }
            public string issuerName { get; set; }
            public string receiverId { get; set; }
            public string receiverName { get; set; }
            public string dateTimeIssued { get; set; }
            public string dateTimeReceived { get; set; }
            public string totalSales { get; set; }
            public string totalDiscount { get; set; }
            public string netAmount { get; set; }
            public string total { get; set; }
            public string status { get; set; }

        }

        public class ValidationResults
        {
            public string status { get; set; }
            public List<ValidationSteps> validationSteps { get; set; }

        }
        public class ValidationSteps
        {
            public string name { get; set; }

            public string status { get; set; }

            public ValidationError error;
        }

        public class InvoiceLineItemCodes
        {
            public string codeTypeId { get; set; }
            public string codeTypeNamePrimaryLang { get; set; }
            public string codeTypeNameSecondaryLang { get; set; }
            public string itemCode { get; set; }
            public string codeNamePrimaryLang { get; set; }
            public string codeNameSecondaryLang { get; set; }
        }


        public class ValidationError
        {
            public string propertyName { get; set; }
            public string propertyPath { get; set; }
            public string errorCode { get; set; }
            public string error { get; set; }
            public List<InnerError> innerError { get; set; }
        }

        public class InnerError
        {
            public string propertyName { get; set; }
            public string propertyPath { get; set; }
            public string errorCode { get; set; }
            public string error { get; set; }
            public List<InnerError> details { get; set; }


            public InnerError(string propertyName_, string propertyPath_, string errorCode_, string error_, List<InnerError> details_)
            {
                this.propertyName = propertyName_;
                this.propertyPath = propertyPath_;
                this.errorCode = errorCode_;
                this.error = error_;
                this.details = details_;
            }
        }
    }
}