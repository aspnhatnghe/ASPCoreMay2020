using Microsoft.EntityFrameworkCore;

namespace Buoi14_EFCore.Models
{
    public class MyDbContext : DbContext
    {
        //Định nghĩa các thuộc tính (table)
        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
