using Microsoft.EntityFrameworkCore;

namespace HG.Infrastructure;

public class HowlingGigglesContext(DbContextOptions options) : DbContext(options)
{

}
