using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class DistributorUser
    {
            public string UserName { get; set; }
            public string UserAccount { get; set; }
            public string Password { get; set; }
            public string Description { get; set; }
            public Nullable<int> LoginType { get; set; }
            public Nullable<int> AccountIsDisabled { get; set; }
            public Nullable<int> AccountsIsLockedOut { get; set; }
            public Nullable<int> LoginState { get; set; }
            public Nullable<int> AuthenticationRequired { get; set; }
            public string Manager_RecordID { get; set; }
            public Nullable<int> Branch_RecordID { get; set; }
            public string Email { get; set; }
            public int RecordID { get; set; }
            public Nullable<System.DateTime> LastPasswordUpdate { get; set; }
            public Nullable<int> PasswordNeverExpires { get; set; }
            public Nullable<int> UserCannotChangePassword { get; set; }
            public Nullable<int> UserMustChangePasswordAtNextLogon { get; set; }
            public string Editor { get; set; }
            public Nullable<System.DateTime> Date { get; set; }
            public Nullable<byte> status { get; set; }
            public string PrintrName { get; set; }
            public string Serial_No { get; set; }
            public string android_id { get; set; }
            public Nullable<byte> Distributor_Group_ID { get; set; }
        
    }
}