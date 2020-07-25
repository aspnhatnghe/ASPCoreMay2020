using Microsoft.EntityFrameworkCore;

namespace MyProject.DataModels
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Hinh> Hinhs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HangHoa>()
                .Property(p => p.Hinh)
                .HasMaxLength(150);
            modelBuilder.Entity<HangHoa>()
                .HasIndex(p => p.MaHH)
                .IsUnique();
        }
    }
}
