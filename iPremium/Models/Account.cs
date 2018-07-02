using iPremium.Models.ApiModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace iPremium.Models
{
    public class Account : ApiResult
    {
        public MemberType MemberType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
