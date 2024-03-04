using HG.Infrastructure.RequestModels;
using HG.Infrastructure.ResponseModel;

namespace HG.Infrastructure.Services.PostService
{
    public interface IPostService
    {
        Task<IEnumerable<PostResponseModel>> GetAllPosts();
        Task<object> GetPostById(int postId);
        Task<PostResponseModel> AddPost(PostRequestModel post);
        Task<PostResponseModel> UpdatePost(int postId, PostRequestModel post);
        Task<SuccessResponseModel> DeletePost(int postId);
    }
}
