using HG.Infrastructure.Factories;
using HG.Infrastructure.Repository;
using HG.Infrastructure.RequestModels;
using HG.Infrastructure.ResponseModel;


namespace HG.Infrastructure.Services.PostService
{
    public class PostService(IPostRepository postRepository) : IPostService
    {
        private readonly IPostRepository PostRepository = postRepository;

        public async Task<PostResponseModel> AddPost(PostRequestModel post)
        {
            var newPost = PostFactory.CreatePost(post);
            await this.PostRepository.AddAsync(newPost);
            var response = PostFactory.CreateResponse(newPost);
            return response;
        }

        public async Task<SuccessResponseModel> DeletePost(int postId)
        {
           var selectedPost = await this.PostRepository.GetByIdAsync(postId);
           if(selectedPost is not null)
           {
                selectedPost.isDeleted = true;
                await this.PostRepository.UpdateAsync(selectedPost);
                return new SuccessResponseModel() { Success = selectedPost.isDeleted };
           }
           return new SuccessResponseModel() { Success = false };
        }

        public async Task<IEnumerable<PostResponseModel>> GetAllPosts()
        {
            var allPosts = await this.PostRepository.GetAllAsync();
            var responsePostModel = allPosts.Select(p => PostFactory.CreateResponse(p));
            return responsePostModel;
        }

        public async Task<PostResponseModel> GetPostById(int postId)
        {
            var post = await this.PostRepository.GetByIdAsync(postId);
            var response = PostFactory.CreateResponse(post);
            return response;
        }

        public async Task<PostResponseModel> UpdatePost(int postId, PostRequestModel post)
        {
            var selectedPost = await this.PostRepository.GetByIdAsync(postId);
            if(selectedPost is not null)
            {
                selectedPost.Username = post.Username;
                selectedPost.PostContent = post.PostContent;

                await this.PostRepository.UpdateAsync(selectedPost);
                var response = PostFactory.CreateResponse(selectedPost);
                return response;
            }
            return new PostResponseModel();
        }
    }
}
