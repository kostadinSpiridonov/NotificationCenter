using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class NotificationCenterContext : DbContext
    {
        public NotificationCenterContext()
        {
        }

        public NotificationCenterContext(DbContextOptions<NotificationCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationChannel> NotificationChannels { get; set; }
        public virtual DbSet<NotificationEvent> NotificationEvents { get; set; }
        public virtual DbSet<NotificationEventChannel> NotificationEventChannels { get; set; }
        public virtual DbSet<NotificationsCriteria> NotificationsCriterias { get; set; }
        public virtual DbSet<NotificationsGroup> NotificationsGroups { get; set; }
        public virtual DbSet<Request> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER14;Database=NotificationCenter;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Certifica__Clien__48CFD27E");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Logins__ClientId__45F365D3");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Content).IsRequired();
            });

            modelBuilder.Entity<NotificationChannel>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<NotificationEvent>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Criteria)
                    .WithMany(p => p.NotificationEvents)
                    .HasForeignKey(d => d.CriteriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Crite__6E01572D");

                entity.HasOne(d => d.NotificationGroup)
                    .WithMany(p => p.NotificationEvents)
                    .HasForeignKey(d => d.NotificationGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Notif__6EF57B66");
            });

            modelBuilder.Entity<NotificationEventChannel>(entity =>
            {
                entity.HasKey(e => new { e.NotificationChannelId, e.NotificationEventId })
                    .HasName("PK__Notifica__3DE74F34B7499039");

                entity.HasOne(d => d.NotificationChannel)
                    .WithMany(p => p.NotificationEventChannels)
                    .HasForeignKey(d => d.NotificationChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Notif__02084FDA");

                entity.HasOne(d => d.NotificationEvent)
                    .WithMany(p => p.NotificationEventChannels)
                    .HasForeignKey(d => d.NotificationEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Notif__02FC7413");
            });

            modelBuilder.Entity<NotificationsCriteria>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Template).IsRequired();
            });

            modelBuilder.Entity<NotificationsGroup>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Status).IsRequired();

                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Requests__Client__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
