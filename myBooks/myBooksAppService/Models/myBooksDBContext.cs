using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace myBooksAppService.Models
{
    public partial class MyBooksDBContext : DbContext
    {
        public MyBooksDBContext()
        {
        }

        public MyBooksDBContext(DbContextOptions<MyBooksDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Livros> Livros { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-PQH5FD0\\SQLEXPRESS;Database=MyBooksDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Livros>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.BookImgName)
                    .IsRequired()
                    .HasColumnName("BookImg_Name")
                    .HasMaxLength(1000);

                entity.Property(e => e.BookImgVb)
                    .IsRequired()
                    .HasColumnName("BookImg_VB");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Livros_Usuarios");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserImgName)
                    .IsRequired()
                    .HasColumnName("UserImg_Name")
                    .HasMaxLength(1000);

                entity.Property(e => e.UserImgVb)
                    .IsRequired()
                    .HasColumnName("UserImg_VB");
            });
        }
    }
}
