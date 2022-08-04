using Task4_userAPI.Models;

namespace Task4_userAPI.Contex
{
    public class MVCContext : DbContext
    {
        public MVCContext(DbContextOptions<MVCContext> options) : base(options)
        {
        }
        public DbSet<user> users { set; get; } = null!;
        public DbSet<post> posts { set; get; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /*base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<post>()
    .HasMany<post>(g => g.posts)
    .WithRequired(s => s)
    .HasForeignKey<int>(s => s.CurrentGradeId);*/

        }

       
    }
   
}
