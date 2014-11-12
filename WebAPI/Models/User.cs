using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class User
    {
        private int userId;
        private string name;
        private int bankId;
        private long balance;

        public int UserId { get; set; }
        public string Name { get; set; }
        public int BankId { get; set; }
        public long Balance { get; set; }
    }
}