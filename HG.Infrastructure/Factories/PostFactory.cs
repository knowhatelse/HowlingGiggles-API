using HG.Core;
using HG.Infrastructure.RequestModels;
using HG.Infrastructure.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HG.Infrastructure.Factories
{
    public class PostFactory
    {
        public static Post CreatePost(PostRequestModel model)
        {
            return new Post()
            {
                Username = model.Username,
                PostContent = model.PostContent,
                LikeCount = 0,
            };
        }

        public static PostResponseModel CreateResponse(Post model)
        {
            return new PostResponseModel()
            {
                Id = model.Id,
                Username = model.Username,
                PostContent = model.PostContent,
                LikeCount = model.LikeCount,
            };
        }
    }
}
