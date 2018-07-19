using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISYS.Model
{
    public class Comment
    {
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}