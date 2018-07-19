using System;
using System.Collections.Generic;
using System.Text;

namespace ISYS.Model
{
    public class Result
    {
        public int StatusCode { get; set; }
        public bool HasError { get; set; } = true;
        public string Message { get; set; }
    }
}
