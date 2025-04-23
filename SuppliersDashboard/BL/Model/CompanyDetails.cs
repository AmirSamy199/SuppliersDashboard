using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class CompanyDetails
    {
        //Company
        public Nullable<int> TaxNum { get; set; }
        public string RegistrationNum { get; set; }
        public string type { get; set; }
        public string Name { get; set; }
        public string ArabName { get; set; }
        public string country { get; set; }
        public string governate { get; set; }
        public string regionCity { get; set; }
        public string street { get; set; }
        public string buildingNumber { get; set; }
        public string postalCode { get; set; }
        public string taxpayerActivityCode { get; set; }
        public Nullable<int> ComID { get; set; }
        public int ComRecordID { get; set; }
        public string TokenPin { get; set; }
        public string TokenCompny { get; set; }
        public Nullable<byte> Companystatus { get; set; }
        public byte PriceIncludesTax { get; set; }
        public byte SalesModule { get; set; }
        public byte SupplierModule { get; set; }
        public byte DepartmentModule { get; set; }
        public byte CategoryModule { get; set; }
        public byte SubCategoryModule { get; set; }
        public byte InvConfirmation { get; set; }
        public byte AutoInvoiceVAT { get; set; }
        public int NoGroups { get; set; }
        public string ScopocOrUno { get; set; }
        public Nullable<int> branchID { get; set; }

        //UAT
        public Nullable<int> UATEnvironment_ID { get; set; }
        public string UATEnvironment { get; set; }
        public string UATdocumentTypeVersion { get; set; }
        public string UATdocumentType { get; set; }
        public string UATLogin_URL { get; set; }
        public string UATclient_id { get; set; }
        public string UATclient_secret { get; set; }
        public string UATclient_secret_2 { get; set; }
        public string UATDocumentSubmissions_URL { get; set; }
        public int UATEnviromentRecordID { get; set; }
        public Nullable<byte> UATstatus { get; set; }

        //Production
        public Nullable<int> ProductionEnvironment_ID { get; set; }
        public string ProductionEnvironment { get; set; }
        public string ProductiondocumentTypeVersion { get; set; }
        public string ProductiondocumentType { get; set; }
        public string ProductionLogin_URL { get; set; }
        public string Productionclient_id { get; set; }
        public string Productionclient_secret { get; set; }
        public string Productionclient_secret_2 { get; set; }
        public string ProductionDocumentSubmissions_URL { get; set; }
        public int ProductionEnviromentRecordID { get; set; }
        public Nullable<byte> Productionstatus { get; set; }

        //Currency
        public List<Nullable<int>> CurrencyList { get; set; }

        //Unit
        public List<Nullable<int>> UnitList { get; set; }

    }
}