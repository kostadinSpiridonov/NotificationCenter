using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<ClientType> ClientTypes { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationChannel> NotificationChannels { get; set; }
        public virtual DbSet<NotificationEvent> NotificationEvents { get; set; }
        public virtual DbSet<NotificationEventChannel> NotificationEventChannels { get; set; }
        public virtual DbSet<NotificationsCriteria> NotificationsCriterias { get; set; }
        public virtual DbSet<NotificationsEventClientType> NotificationsEventClientTypes { get; set; }
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
                    .HasConstraintName("FK__Certifica__Clien__3E1D39E1");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.ClientType)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ClientTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clients__ClientT__3864608B");
            });

            modelBuilder.Entity<ClientType>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Logins__ClientId__3B40CD36");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Clien__43D61337");
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
                    .HasConstraintName("FK__Notificat__Crite__2BFE89A6");
            });

            modelBuilder.Entity<NotificationEventChannel>(entity =>
            {
                entity.HasKey(e => new { e.NotificationChannelId, e.NotificationEventId })
                    .HasName("PK__Notifica__3DE74F34C8C90F1C");

                entity.HasOne(d => d.NotificationChannel)
                    .WithMany(p => p.NotificationEventChannels)
                    .HasForeignKey(d => d.NotificationChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Notif__2EDAF651");

                entity.HasOne(d => d.NotificationEvent)
                    .WithMany(p => p.NotificationEventChannels)
                    .HasForeignKey(d => d.NotificationEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Notif__2FCF1A8A");
            });

            modelBuilder.Entity<NotificationsCriteria>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Template).IsRequired();
            });

            modelBuilder.Entity<NotificationsEventClientType>(entity =>
            {
                entity.HasKey(e => new { e.ClientTypeId, e.NotificationEventId })
                    .HasName("PK__Notifica__BBB0B4F58AD854E4");

                entity.HasOne(d => d.ClientType)
                    .WithMany(p => p.NotificationsEventClientTypes)
                    .HasForeignKey(d => d.ClientTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Clien__3493CFA7");

                entity.HasOne(d => d.NotificationEvent)
                    .WithMany(p => p.NotificationsEventClientTypes)
                    .HasForeignKey(d => d.NotificationEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Notif__3587F3E0");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Status).IsRequired();

                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Requests__Client__40F9A68C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
