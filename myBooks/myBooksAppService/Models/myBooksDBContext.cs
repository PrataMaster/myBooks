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
                optionsBuilder.UseSqlServer("Server=DESKTOP-PQH5FD0;Database=myBooksDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Livros>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.ToTable("livros");

                entity.Property(e => e.BookId).ValueGeneratedOnAdd();

                entity.Property(e => e.BookImgName)
                    .IsRequired()
                    .HasColumnName("BookImg_Name")
                    .HasMaxLength(1000);

                entity.Property(e => e.BookImgVb)
                    .IsRequired()
                    .HasColumnName("BookImg_VB");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Book)
                    .WithOne(p => p.Livros)
                    .HasForeignKey<Livros>(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_livros_usuarios");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("usuarios");

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
