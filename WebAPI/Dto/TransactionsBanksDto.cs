using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Dto
{
    public class TransactionsBanksDto
    {
        public int BankId { get; set; }
        public string Name { get; set; }
        public List<int> ReceiversIds  { get; set; }
    }
}