using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public class WorkspacesDbContext : DbContext
    {
        public WorkspacesDbContext(DbContextOptions<WorkspacesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Workspaces> Workspaces { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация для таблицы WORKSPACES
            modelBuilder.Entity<Workspaces>()
                .ToTable("WORKSPACES");

            modelBuilder.Entity<Workspaces>()
                .HasKey(w => w.WorkspaceId);

            modelBuilder.Entity<Workspaces>()
                .Property(w => w.WorkspaceId)
                .HasColumnName("ID_WORKSPACE")
                .IsRequired();

            modelBuilder.Entity<Workspaces>()
                .Property(w => w.WorkspaceName)
                .HasColumnName("NAME")
                .IsRequired();

            modelBuilder.Entity<Workspaces>()
                .Property(w => w.WorkspaceAddress)
                .HasColumnName("ADDRESS")
                .IsRequired();

            modelBuilder.Entity<Workspaces>()
                .Property(w => w.WorkspaceDescription)
                .HasColumnName("DESCRIPTION")
                .IsRequired(false);

            // Конфигурация для таблицы ROOMS
            modelBuilder.Entity<Rooms>()
                .ToTable("ROOMS");

            modelBuilder.Entity<Rooms>()
                .HasKey(r => r.RoomId);

            modelBuilder.Entity<Rooms>()
                .Property(r => r.RoomId)
                .HasColumnName("ID_ROOM")
                .IsRequired();

            modelBuilder.Entity<Rooms>()
                .Property(r => r.WorkspaceId)
                .HasColumnName("ID_WORKSPACE")
                .IsRequired();

            modelBuilder.Entity<Rooms>()
                .Property(r => r.RoomName)
                .HasColumnName("NAME")
                .IsRequired();

            modelBuilder.Entity<Rooms>()
                .Property(r => r.Capacity)
                .HasColumnName("CAPACITY")
                .IsRequired();

            modelBuilder.Entity<Rooms>()
                .Property(r => r.HasScreen)
                .HasColumnName("SCREEN")
                .IsRequired();

            // Конфигурация для таблицы BOOKINGS
            modelBuilder.Entity<Bookings>()
                .ToTable("BOOKINGS");

            modelBuilder.Entity<Bookings>()
                .HasKey(b => b.BookingId);

            modelBuilder.Entity<Bookings>()
                .Property(b => b.BookingId)
                .HasColumnName("ID_BOOKING")
                .IsRequired();

            modelBuilder.Entity<Bookings>()
                .Property(b => b.UserId)
                .HasColumnName("ID_USER")
                .IsRequired();

            modelBuilder.Entity<Bookings>()
                .Property(b => b.RoomId)
                .HasColumnName("ID_ROOM")
                .IsRequired();

            modelBuilder.Entity<Bookings>()
                .Property(b => b.WorkspaceId)
                .HasColumnName("ID_WORKSPACE")
                .IsRequired();

            modelBuilder.Entity<Bookings>()
                .Property(b => b.Description)
                .HasColumnName("DESCRIPTION")
                .IsRequired(false);

            modelBuilder.Entity<Bookings>()
                .Property(b => b.BookingTime)
                .HasColumnName("BOOKING_TIME")
                .IsRequired();

            modelBuilder.Entity<Bookings>()
                .Property(b => b.StartTime)
                .HasColumnName("START_TIME")
                .IsRequired();

            modelBuilder.Entity<Bookings>()
                .Property(b => b.EndTime)
                .HasColumnName("END_TIME")
                .IsRequired();

            // Конфигурация для таблицы PHOTOS
            modelBuilder.Entity<Photos>()
                .ToTable("PHOTOS");

            modelBuilder.Entity<Photos>()
                .HasKey(p => p.PhotoId);

            modelBuilder.Entity<Photos>()
                .Property(p => p.PhotoId)
                .HasColumnName("ID_PHOTO")
                .IsRequired();

            modelBuilder.Entity<Photos>()
                .Property(p => p.RoomId)
                .HasColumnName("ID_ROOM")
                .IsRequired();

            modelBuilder.Entity<Photos>()
                .Property(p => p.UrlFile)
                .HasColumnName("URLFILE")
                .IsRequired();

            // Конфигурация для таблицы USERS
            modelBuilder.Entity<Users>()
                .ToTable("USERS");

            modelBuilder.Entity<Users>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Users>()
                .Property(u => u.UserId)
                .HasColumnName("ID_USER")
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(u => u.TgId)
                .HasColumnName("ID_TG")
                .IsRequired(false);

            modelBuilder.Entity<Users>()
                .Property(u => u.Email)
                .HasColumnName("EMAIL")
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(u => u.Password)
                .HasColumnName("PASSWORD")
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(u => u.Name)
                .HasColumnName("NAME")
                .IsRequired(false);

            modelBuilder.Entity<Users>()
                .Property(u => u.RoleId)
                .HasColumnName("ID_ROLE")
                .IsRequired(false);

            // Конфигурация для таблицы ROLES
            modelBuilder.Entity<Roles>()
                .ToTable("ROLES");

            modelBuilder.Entity<Roles>()
                .HasKey(r => r.RoleId);

            modelBuilder.Entity<Roles>()
                .Property(r => r.RoleId)
                .HasColumnName("ID_ROLE")
                .IsRequired();

            modelBuilder.Entity<Roles>()
                .Property(r => r.RoleName)
                .HasColumnName("ROLE")
                .IsRequired();
        }
    }
}