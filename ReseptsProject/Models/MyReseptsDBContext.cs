using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ReseptsProject.Models
{
    public partial class MyReseptsDBContext : DbContext
    {
        public MyReseptsDBContext()
        {
        }

        public MyReseptsDBContext(DbContextOptions<MyReseptsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Resept> Resepts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-R65AU0F\\SQLEXPRESS;Database=MyReseptsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .HasColumnName("categoryName");

                entity.Property(e => e.Deleted).HasColumnName("deleted");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.CommentId).HasColumnName("commentId");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Comment1)
                    .HasMaxLength(250)
                    .HasColumnName("comment");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                

                entity.Property(e => e.ReseptId).HasColumnName("reseptId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.ReseptNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ReseptId)
                    .HasConstraintName("FK__comments__resept__2F10007B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__comments__userId__300424B4");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menus");

                entity.Property(e => e.MenuId).HasColumnName("menuId");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Row).HasColumnName("row");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.TopId).HasColumnName("topId");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("pages");

                entity.Property(e => e.PageId).HasColumnName("pageId");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Resept>(entity =>
            {
                entity.ToTable("resepts");

                entity.Property(e => e.ReseptId).HasColumnName("reseptId");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.EatName)
                    .HasMaxLength(250)
                    .HasColumnName("eatName");

                entity.Property(e => e.Resept1)
                    .HasColumnType("ntext")
                    .HasColumnName("resept");

                entity.Property(e => e.Row).HasColumnName("row");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Resepts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__resepts__categor__2A4B4B5E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Authority).HasColumnName("authority");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .HasColumnName("userEmail");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .HasColumnName("userName");

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(15)
                    .HasColumnName("userPhone");

                entity.Property(e => e.UserSurename)
                    .HasMaxLength(100)
                    .HasColumnName("userSurename");

                entity.Property(e => e.Userpassword)
                    .HasMaxLength(25)
                    .HasColumnName("userpassword");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
