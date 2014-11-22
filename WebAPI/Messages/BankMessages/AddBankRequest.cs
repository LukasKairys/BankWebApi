using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Messages.BankMessages
{
    [DataContract]
    public class AddBankRequest
    {
        [DataMember]
        public Bank Bank { get; set; }

    }
}