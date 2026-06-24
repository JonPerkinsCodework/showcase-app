using Microsoft.EntityFrameworkCore;
using Utopia.Domain.Entities;
using Utopia.Infrastructure.Persistence.Configurations;

namespace Utopia.Infrastructure.Data
{

    public class UtopiaDbContext : DbContext
    {
        public UtopiaDbContext(DbContextOptions<UtopiaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects => Set<Project>();
        
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        
        public DbSet<Client> Clients => Set<Client>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Title).IsRequired().HasMaxLength(200);

                entity.HasOne(t => t.Project)
                      .WithMany(p => p.Tasks)
                      .HasForeignKey(t => t.ProjectId);
            });

            modelBuilder.ApplyConfiguration(new ClientConfiguration());

        }
    }
}
