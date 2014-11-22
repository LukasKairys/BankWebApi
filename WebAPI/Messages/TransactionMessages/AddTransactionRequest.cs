using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Messages.TransactionMessages
{
    [DataContract]
    public class AddTransactionRequest
    {
        [DataMember]
        public Transaction Transaction { get; set; }

    }
}