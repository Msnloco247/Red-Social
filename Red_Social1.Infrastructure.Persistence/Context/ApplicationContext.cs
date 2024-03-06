
using Microsoft.EntityFrameworkCore;
using Red_Social1.Core.Domain.Common;
using Red_Social1.Core.Domain.Entities;

namespace Red_Social1.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


        public DbSet<Comentary> Comentaries { get; set; }

        public DbSet<Publication> Publications { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBasePublicationEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region tables


            modelBuilder.Entity<Publication>()
                .ToTable("Publications");


            modelBuilder.Entity<Comentary>()
                .ToTable("Comentaries");
            #endregion

            #region "primary keys"

            modelBuilder.Entity<Publication>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Comentary>()
                .HasKey(c => c.Id);

            #endregion

            #region "Relationships"


            modelBuilder.Entity<Publication>().
                HasMany<Comentary>(p => p.Comentaries)
                .WithOne(c => c.Publication)
                .HasForeignKey(p => p.PublicationId)
                .OnDelete(DeleteBehavior.Cascade);


            #endregion

            #region "Property configurations"

            #region Publication

            modelBuilder.Entity<Publication>().
              Property(p => p.Content)
              .IsRequired();

            #endregion

            #region comentary

            modelBuilder.Entity<Comentary>().
              Property(c => c.Content)
              .IsRequired();
            #endregion

            #endregion

        }
    }


}
