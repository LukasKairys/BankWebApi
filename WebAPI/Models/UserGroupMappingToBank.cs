using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity; 

namespace WebAPI.Models
{
    public class UserGroupMappingToBank
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserGroupMappingToBankId { get; set; }

        public int BankId { get; set; }
        public int UserGroupId { get; set; }

        [ForeignKey("BankId")]
        public virtual Bank Bank { get; set; }

        [ForeignKey("UserGroupId")]
        public virtual UserGroup UserGroup { get; set; }
    }
}