using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HG.Infrastructure.ResponseModel
{
    public class NoPostResponseModel
    {
        public string Message { get; set; }
        public NoPostResponseModel(string message)
        {
            Message = message;
        }
    }
}
