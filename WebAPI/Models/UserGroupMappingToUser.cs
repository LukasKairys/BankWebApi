using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity; 

namespace WebAPI.Models
{
    public class UserGroupMappingToUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserGroupMappingToUserId { get; set; }

        public int UserId { get; set; }
        public int UserGroupId { get; set; }

        [ForeignKey("UserGroupId")]
        public virtual UserGroup UserGroup { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}