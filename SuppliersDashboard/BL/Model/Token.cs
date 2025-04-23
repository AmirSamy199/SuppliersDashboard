using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace ScoposERB.Models
{
    public class Token
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public string error { get; set; }
        public Token() { }
        public Token(string access_token_, string expires_in_, string token_type_, string scope_, string error_)
        {
            this.access_token = access_token_;
            this.expires_in = expires_in_;
            this.token_type = token_type_;
            this.scope = scope_;
            this.error = error_;
        }
        public override string ToString()
        {
            string result = JsonConvert.SerializeObject(this);
            return result;
        }
    }
}