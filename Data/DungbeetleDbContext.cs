namespace ProjectDungbeetle.Data;
using Microsoft.EntityFrameworkCore;

public class DungbeetleDbContext : DbContext
{
    public DungbeetleDbContext(DbContextOptions<DungbeetleDbContext> options) : base(options)
    {

    }
}
