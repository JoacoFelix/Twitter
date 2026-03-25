using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Twitter.Models;

public partial class TwitterContext : DbContext
{
    public TwitterContext()
    {
    }

    public TwitterContext(DbContextOptions<TwitterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Interes> Interes { get; set; }

    public virtual DbSet<InteresUsuario> InteresUsuarios { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<Publicacion> Publicacions { get; set; }

    public virtual DbSet<Seguido> Seguidos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("SERVER=.;Database=Twitter;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.IdChat);

            entity.ToTable("Chat");

            entity.Property(e => e.IdChat)
                .ValueGeneratedNever()
                .HasColumnName("idChat");
            entity.Property(e => e.IsGroup).HasColumnName("isGroup");
        });

        modelBuilder.Entity<Interes>(entity =>
        {
            entity.HasKey(e => e.IdInteres);

            entity.Property(e => e.IdInteres)
                .ValueGeneratedNever()
                .HasColumnName("idInteres");
            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<InteresUsuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("InteresUsuario");

            entity.Property(e => e.IdInteres).HasColumnName("idInteres");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdInteresNavigation).WithMany()
                .HasForeignKey(d => d.IdInteres)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InteresUsuario_Interes");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InteresUsuario_Usuarios");
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Mensaje");

            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("fechaHora");
            entity.Property(e => e.IdChat).HasColumnName("idChat");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Texto).HasColumnName("texto");

            entity.HasOne(d => d.IdChatNavigation).WithMany()
                .HasForeignKey(d => d.IdChat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mensaje_Chat");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mensaje_Usuarios");
        });

        modelBuilder.Entity<Publicacion>(entity =>
        {
            entity.HasKey(e => e.IdPublicacion);

            entity.ToTable("Publicacion");

            entity.Property(e => e.IdPublicacion)
                .ValueGeneratedNever()
                .HasColumnName("idPublicacion");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Publicacions)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicacion_Usuarios");
        });

        modelBuilder.Entity<Seguido>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IdUserFollowed).HasColumnName("idUserFollowed");
            entity.Property(e => e.IdUserFollower).HasColumnName("idUserFollower");

            entity.HasOne(d => d.IdUserFollowedNavigation).WithMany()
                .HasForeignKey(d => d.IdUserFollowed)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguidos_Usuarios1");

            entity.HasOne(d => d.IdUserFollowerNavigation).WithMany()
                .HasForeignKey(d => d.IdUserFollower)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguidos_Usuarios");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC076CF435F0");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E48020D477").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
