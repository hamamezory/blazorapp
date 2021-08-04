using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apptest.shared.Responses
{
    public class ApiResponse
    {
        public string Messgae { get; set; }
        public string IsSuccess { get; set; }

    }

    public class ApiResponse<T> : ApiResponse
    {
        public T value { get; set; }
    }

}
