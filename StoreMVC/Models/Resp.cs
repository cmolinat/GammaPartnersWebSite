using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreMVC.Models
{
    public class Resp
    {
        public string ReturnUrl { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}