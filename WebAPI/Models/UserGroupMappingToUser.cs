using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UserGroupMappingToUser
    {
        private int userGroupMappingToUserId;
        private int userId;
        private int userGroupId;

        public int UserGroupMappingToUserId { get; set; }
        public int UserId { get; set; }
        public int UserGroupId { get; set; }

    }
}