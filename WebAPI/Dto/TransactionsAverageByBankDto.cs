﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Dto
{
    public class TransactionsAverageByBankDto
    {
        public int BankId { get; set; }
        public long AmountOfMoneyAverage  { get; set; }
    }
}