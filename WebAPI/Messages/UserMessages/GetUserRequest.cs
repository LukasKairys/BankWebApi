using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Messages.UserMessages
{
    [DataContract]
    public class GetUserRequest
    {
        [DataMember]
        public int UserId { get; set; }

    }
}