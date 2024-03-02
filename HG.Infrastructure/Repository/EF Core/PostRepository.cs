using HG.Core;
using Microsoft.EntityFrameworkCore;

namespace HG.Infrastructure.Repository.EF_Core
{
    internal class PostRepository(HowlingGigglesContext howlingGigglesContext) : IPostRepository
    {
        private readonly HowlingGigglesContext howlingGigglesContext = howlingGigglesContext;

        public async Task<Post> AddAsync(Post post)
        {
            this.howlingGigglesContext.Posts.Add(post);
            await this.howlingGigglesContext.SaveChangesAsync();
            return post;
        }

        public async Task DeleteAsync(Post post)
        {
            this.howlingGigglesContext.Posts.Remove(post);
            await this.howlingGigglesContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await this.howlingGigglesContext.Posts.Where(p => !p.isDeleted).ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await this.howlingGigglesContext.Posts.FirstOrDefaultAsync(p => p.Id == id && !p.isDeleted);
        }

        public async Task<Post> UpdateAsync(Post post)
        {
            this.howlingGigglesContext.Posts.Update(post);
            await this.howlingGigglesContext.SaveChangesAsync();
            return post;
        }
    }
}
