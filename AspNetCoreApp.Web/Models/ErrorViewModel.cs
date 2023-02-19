using System;
using System.Collections.Generic;

namespace AspNetCoreApp.Web.Models
{
    public class ErrorViewModel
    {
        public List<string> ErrorMessages { get; set; }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
