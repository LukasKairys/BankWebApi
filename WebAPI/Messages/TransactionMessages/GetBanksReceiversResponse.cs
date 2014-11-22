﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Messages.TransactionMessages
{
    [DataContract]
    public class GetBanksReceiversResponse
    {
        [DataMember]
        public List<TransactionsBanksDto> BanksReceivers { get; set; }

        [DataMember]
        public List<ErrorDto> Errors  { get; set; }
    }
}