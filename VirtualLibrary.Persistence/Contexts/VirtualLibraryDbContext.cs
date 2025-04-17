using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Domain;
using VirtualLibrary.Domain.BoardEntities;
using VirtualLibrary.Domain.Constants;
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

            builder.Entity<StudyRoom>().HasMany(x => x.StudyRoomUsers).WithOne(x => x.StudyRoom).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<StudyRoom>().HasOne(x => x.Pomodoro).WithOne(x => x.StudyRoom).HasForeignKey<Pomodoro>(x => x.StudyRoomId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<StudyRoom>().HasOne(x => x.Owner).WithMany(x => x.StudyRooms).HasForeignKey(x => x.OwnerId).OnDelete(DeleteBehavior.Restrict);

            //TODO repasar esto DeleteBehavior.Restrict
            builder.Entity<User>().HasMany(x => x.UserFriends).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<UserFriend>().HasOne(x => x.Friend).WithMany().HasForeignKey(x => x.FriendId).OnDelete(DeleteBehavior.Restrict);   

            builder.Entity<Notification>().HasOne(x => x.Sender).WithMany().HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Notification>().HasOne(x => x.Recipient).WithMany().HasForeignKey(x => x.RecipientId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RoomNotification>().HasOne(x => x.StudyRoom).WithMany().HasForeignKey(x => x.RoomId);

            builder.Entity<StudyRoom>().HasMany(x => x.RoomNotifications).WithOne(x => x.StudyRoom).HasForeignKey(x => x.RoomId);


            //boards
            builder.Entity<Board>().HasMany(x => x.CardLists).WithOne().HasForeignKey(x => x.BoardId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CardList>().HasMany(x => x.Cards).WithOne().HasForeignKey(x => x.CardListId).OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Notification>()
             .HasDiscriminator<string>("NotificationType")
             .HasValue<RoomNotification>(NotificationTypes.RoomNotification)
             .HasValue<FriendNotification>(NotificationTypes.FriendNotification);
        }

        public DbSet<StudyRoom> StudyRooms { get; set; }
        public DbSet<Pomodoro> Pomodoros { get; set; }
        public DbSet<StudyRoomUser> StudyRoomUsers { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<CardList> CardLists { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
