using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Domain;
using VirtualLibrary.Domain.StudyRoomEntities;
using VirtualLibrary.Domain.UserEntities;

namespace VirtualLibrary.Persistence.Contexts
{
    public class VirtualLibraryDbContext : IdentityDbContext<User>
    {
        public VirtualLibraryDbContext(DbContextOptions<VirtualLibraryDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StudyRoom>().HasMany(x => x.StudyRoomUsers).WithOne(x => x.StudyRoom).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<StudyRoom>().HasOne(x => x.Pomodoro).WithOne(x => x.StudyRoom).HasForeignKey<Pomodoro>(x => x.StudyRoomId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<StudyRoom>().HasOne(x => x.Owner).WithMany(x => x.StudyRooms).HasForeignKey(x => x.OwnerId);

            //TODO repasar esto DeleteBehavior.Restrict
            builder.Entity<User>().HasMany(x => x.UserFriends).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<UserFriend>().HasOne(x => x.Friend).WithMany().HasForeignKey(x => x.FriendId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Notification>()
                   .HasDiscriminator<string>("NotificationType")
                   .HasValue<RoomNotification>("Room");

            builder.Entity<Notification>().HasOne(x => x.Sender).WithMany().HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Notification>().HasOne(x => x.Recipient).WithMany().HasForeignKey(x => x.RecipientId).OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<StudyRoom> StudyRooms { get; set; }
        public DbSet<Pomodoro> Pomodoros { get; set; }
        public DbSet<StudyRoomUser> StudyRoomUsers { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
