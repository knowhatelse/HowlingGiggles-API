using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HG.Infrastructure.ResponseModel
{
    public class PostResponseModel
    {
        public string Username { get; set; }
        public string PostContent { get; set; }
        public int LikeCount { get; set; }
    }
}
