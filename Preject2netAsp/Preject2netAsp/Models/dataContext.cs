using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Preject2netAsp.Models
{
    public partial class dataContext : DbContext
    {
        public dataContext()
        {
        }

        public dataContext(DbContextOptions<dataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Friend> Friend { get; set; }
        public virtual DbSet<PlayList> PlayList { get; set; }
        public virtual DbSet<Toptraks> Toptraks { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=data;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>(entity =>
            {
                entity.ToTable("friend");
            });

            modelBuilder.Entity<PlayList>(entity =>
            {
                entity.ToTable("playList");

                entity.Property(e => e.DateToAdd).HasColumnType("datetime");

                entity.Property(e => e.TitleAudio).HasColumnName("titleAudio");
            });

            modelBuilder.Entity<Toptraks>(entity =>
            {
                entity.ToTable("toptraks");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AlbumId).HasColumnName("Album_id");

                entity.Property(e => e.AlbumName).HasColumnName("Album_name");

                entity.Property(e => e.ArtistId).HasColumnName("Artist_id");

                entity.Property(e => e.ArtistIdstr).HasColumnName("Artist_idstr");

                entity.Property(e => e.ArtistName).HasColumnName("Artist_name");

                entity.Property(e => e.LicenseCcurl).HasColumnName("License_ccurl");

                entity.Property(e => e.Releasedate).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Creation).HasColumnType("datetime");
            });
        }
    }
}
