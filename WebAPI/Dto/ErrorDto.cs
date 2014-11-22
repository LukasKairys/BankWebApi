using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Dto
{
    public class ErrorDto
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}