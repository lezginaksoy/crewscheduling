using CrewScheduling.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrewScheduling.Models
{
    public class ApiResponse: BaseAPIResponse
    {
        public Object Result { get; set; }
        public int StatusCode { get; set; } = 200;

        public ApiResponse() : base()
        {
        }
        public ApiResponse(Errors code, int statusCode = 400)
        {           
            Code = (int)code;
            Message = "Error";
            StatusCode = statusCode;
        }
    }

    public class BaseAPIResponse
    {
        public int Code { get; set; } = 0;
        public string Message { get; set; } = "Success";
    }
}
