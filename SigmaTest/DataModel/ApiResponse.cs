using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; } = false;
        public object DataSet { get; set; }
        public int StatusCode { get; set; }
    }
}
