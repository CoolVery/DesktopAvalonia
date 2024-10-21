using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestRepeat.Models;

public partial class _41pKyklevContext : DbContext
{
    public _41pKyklevContext()
    {
    }

    public _41pKyklevContext(DbContextOptions<_41pKyklevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Logined> Logineds { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=edu.pg.ngknn.local;Port=5432;Database=41P_Kyklev;Username=31P;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.IdGender).HasName("genders_pk");

            entity.ToTable("genders");

            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.Gender1)
                .HasColumnType("character varying")
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Logined>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("logined_pk");

            entity.ToTable("logined");

            entity.HasIndex(e => e.IdRole, "IX_logined_id_role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Logineds)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("logined_roles_fk");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("roles_pk");

            entity.ToTable("roles");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.RoleName)
                .HasColumnType("character varying")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("users_pk");

            entity.ToTable("users");

            entity.HasIndex(e => e.IdGender, "IX_users_id_gender");

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("id_user");
            entity.Property(e => e.BirthDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birth_date");
            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.ImgUser).HasColumnName("img_user");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdGender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_genders_fk");

            entity.HasOne(d => d.IdUserNavigation).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.IdUser)
                .HasConstraintName("users_logined_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
