using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreApp.API.Data;

public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; } = null!;

    public virtual DbSet<Book> Books { get; set; } = null!;

    public virtual DbSet<CodeFirstTable> CodeFirstTables { get; set; } = null!; 


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC07DC02CFE0");

            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC072A228E72");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA98DD455E").IsUnique();

            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "138e1648-6573-433a-a28f-1cf287baa2cd"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "2d1b2801-af80-4424-a6ad-d67f84892b1f"
            }
        );

        var hasher = new PasswordHasher<ApiUser>();

        modelBuilder.Entity<ApiUser>().HasData(
            new ApiUser
            {
                Id = "29390fa2-3c81-431f-9758-a3f56379826b",
                Email = "admin@bookstore.com",
                NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                UserName = "admin@bookstore.com",
                NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            },
            new ApiUser
            {
                Id = "52468a51-5f9b-4b66-93f1-7f374dfad875",
                Email = "user@bookstore.com",
                NormalizedEmail = "USER@BOOKSTORE.COM",
                UserName = "user@bookstore.com",
                NormalizedUserName = "USER@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "138e1648-6573-433a-a28f-1cf287baa2cd",
                UserId = "29390fa2-3c81-431f-9758-a3f56379826b"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2d1b2801-af80-4424-a6ad-d67f84892b1f",
                UserId = "52468a51-5f9b-4b66-93f1-7f374dfad875"
            }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
