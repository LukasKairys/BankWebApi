using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Messages.UserMessages
{
    [DataContract]
    public class AddUserRequest
    {
        [DataMember]
        public User User { get; set; }

    }
}