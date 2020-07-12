using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyeStoreProject.Models
{
    public class ApiResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ApiResultData<T> : ApiResult
    {
        public T Data { get; set; }
    }
}
