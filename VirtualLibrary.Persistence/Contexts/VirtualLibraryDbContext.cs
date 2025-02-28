using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using VirtualLibrary.Domain;
using VirtualLibrary.Domain.StudyRoom;

namespace VirtualLibrary.Persistence.Contexts
{
    public class VirtualLibraryDbContext : IdentityDbContext<User>
    {
        public VirtualLibraryDbContext(DbContextOptions<VirtualLibraryDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StudyRoom>().HasMany(x => x.StudyRoomUsers).WithOne(x => x.StudyRoom).OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<StudyRoom>().HasOne(x => x.Pomodoro).WithOne().HasForeignKey<StudyRoom>(x => x.PomodoroId).OnDelete(DeleteBehavior.ClientCascade);
        }

        public DbSet<StudyRoom> StudyRooms { get; set; }
        public DbSet<Pomodoro> Pomodoros { get; set; }
    }
}
