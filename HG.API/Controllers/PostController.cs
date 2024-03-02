using HG.Infrastructure.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace HG.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok();
        }

        [HttpGet("get/{postId}")]
        public async Task<IActionResult> GetPost(int postId)
        {
            return Ok();
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddPost([FromBody] PostRequestModel postRequest)
        {
            return Ok();
        }
        [HttpPut("update/{postId}")]
        public async Task<IActionResult> UpdatePost(int postId, [FromBody] PostRequestModel postRequest)
        {
            return Ok();
        }

        [HttpDelete("delete/{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            return Ok();
        }

    }
}
