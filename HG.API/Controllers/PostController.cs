using HG.Infrastructure.RequestModels;
using HG.Infrastructure.ResponseModel;
using HG.Infrastructure.Services.PostService;
using Microsoft.AspNetCore.Mvc;

namespace HG.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
             this.postService = postService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await this.postService.GetAllPosts();    
            return Ok(posts);
        }

        [HttpGet("get/{postId}")]
        public async Task<IActionResult> GetPost(int postId)
        {
            var post = await this.postService.GetPostById(postId);
            if(post is NoPostResponseModel)
            {
                return NotFound(post);
            }
            return Ok(post);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddPost([FromBody] PostRequestModel postRequest)
        {
            var newPost = await this.postService.AddPost(postRequest);
            return Ok(newPost);
        }
        [HttpPut("update/{postId}")]
        public async Task<IActionResult> UpdatePost(int postId, [FromBody] PostRequestModel postRequest)
        {
            return Ok(await this.postService.UpdatePost(postId,postRequest));
        }

        [HttpDelete("delete/{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            var result = await this.postService.DeletePost(postId);
            return Ok(result);
        }

    }
}
