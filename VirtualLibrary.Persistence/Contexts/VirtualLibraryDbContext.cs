using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Domain;
using VirtualLibrary.Domain.StudyRoomEntities;

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

            builder.Entity<User>().HasMany(x => x.UserFriends).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<StudyRoom> StudyRooms { get; set; }
        public DbSet<Pomodoro> Pomodoros { get; set; }
        public DbSet<StudyRoomUser> StudyRoomUsers { get; set; }
    }
}
