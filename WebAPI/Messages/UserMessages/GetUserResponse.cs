﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Messages.UserMessages
{
    [DataContract]
    public class GetUserResponse
    {
        [DataMember]
        public User UserFound { get; set; }

        [DataMember]
        public List<ErrorDto> Errors  { get; set; }
    }
}