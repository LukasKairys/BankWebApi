using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UserGroupMappingToBank
    {
        private int userGroupMappingToBankId;
        private int bankId;
        private int userGroupId;

        public int UserGroupMappingToBankrId { get; set; }
        public int BankId { get; set; }
        public int UserGroupId { get; set; }
    }
}