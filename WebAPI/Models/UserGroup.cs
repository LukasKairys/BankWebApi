using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UserGroup
    {
        private int userGroupId;
        private string name;
        private long transactionPrice;

        public int UserGroupId { get; set; }
        public string Name { get; set; }
        public long TransactionPrice { get; set; }
    }
}