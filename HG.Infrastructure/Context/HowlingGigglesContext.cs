using HG.Core;
using Microsoft.EntityFrameworkCore;

namespace HG.Infrastructure;

public class HowlingGigglesContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Post> Posts { get; set; }
}
