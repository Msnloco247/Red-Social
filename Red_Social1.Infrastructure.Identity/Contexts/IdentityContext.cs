using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Red_Social1.Core.Domain.Entities;
using Red_Social1.Infrastructure.Identity.Entities;

namespace Red_Social1.Infrastructure.Persistence.Contexts
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<PublicationUser> Publications { get; set; }
        public DbSet<ComentaryUser> Comentary { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)


        {
            //FLUENT API
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Identity");




            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
            });



            modelBuilder.Entity<PublicationUser>()
           .HasKey(p => p.Id);

            modelBuilder.Entity<ComentaryUser>()
        .HasKey(p => p.Id);


            #region "Relationships"

            modelBuilder.Entity<ApplicationUser>().
                HasMany<PublicationUser>(p => p.Publications)
                .WithOne(c => c.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>().
              HasMany<ComentaryUser>(p => p.Comentaries)
              .WithOne(c => c.User)
              .HasForeignKey(p => p.UserId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PublicationUser>().
            HasMany<ComentaryUser>(p => p.Comentaries)
            .WithOne(c => c.Publication)
            .HasForeignKey(p => p.PublicationId)
            .OnDelete(DeleteBehavior.Cascade);


            #endregion
        }

    }
}
