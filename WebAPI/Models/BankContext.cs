using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAPI.Models
{
    public class BankContext : DbContext
    {

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Transaction> Transactions { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserGroupMappingToBank> UserGroupMappingToBanks { get; set; }
        public DbSet<UserGroupMappingToUser> UserGroupMappingToUsers { get; set; } 

    }
}