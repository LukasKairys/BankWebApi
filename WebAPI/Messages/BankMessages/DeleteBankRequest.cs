using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Messages.BankMessages
{
    [DataContract]
    public class DeleteBankRequest
    {
        [DataMember]
        public int BankId { get; set; }

    }
}