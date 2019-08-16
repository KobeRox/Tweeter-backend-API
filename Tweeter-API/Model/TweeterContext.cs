using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tweeter_API.Model
{
    public partial class TweeterContext : DbContext
    {
        public TweeterContext()
        {
        }

        public TweeterContext(DbContextOptions<TweeterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tweeter> Tweeter { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:nzmsap2.database.windows.net,1433;Initial Catalog=Tweeter;Persist Security Info=False;User ID=Kobe;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Tweeter>(entity =>
            {
                entity.HasKey(e => e.Postid)
                    .HasName("PK__Tweeter__DD017FD21F620582");

                entity.Property(e => e.Post).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Users__CBA1B25762ED5369");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Post).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });
        }
    }
}
