using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.MVC.ViewModels
{
    public class GateDto
    {
        public string Password { get; set; }

        public string Error { get; set; } = "";
    }
}