using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer.Models
{
    public class ResultMessage
    {
        public StatusType Status { get; set; }

        public string Message { get; set; }
    }

    public enum StatusType
    {
        OK,
        Error
    }

}
