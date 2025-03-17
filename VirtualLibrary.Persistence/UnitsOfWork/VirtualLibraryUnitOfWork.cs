using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Domain;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.UnitsOfWork
{
    public class VirtualLibraryUnitOfWork : IVirtualLibraryUnitOfWork
    {
        private readonly VirtualLibraryDbContext _virtualLibraryDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IUserRepository Users { get; }
        public IStudyRoomRepository StudyRooms { get; }
        public IStudyRoomUserRepository StudyRoomUser {  get; }

        public VirtualLibraryUnitOfWork(VirtualLibraryDbContext VirtualLibraryDbContext, IUserRepository users, IStudyRoomRepository studyRooms, IHttpContextAccessor httpContextAccessor, IStudyRoomUserRepository studyRoomUser)
        {
            _virtualLibraryDbContext = VirtualLibraryDbContext;
            _httpContextAccessor = httpContextAccessor;
            Users = users;
            StudyRooms = studyRooms;
            StudyRoomUser = studyRoomUser;
        }

        public async Task<int> SaveChanges()
        {
            var entries = _virtualLibraryDbContext.ChangeTracker.Entries<GenericEntity>();

            var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = userId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = userId;
                }
            }

            return await _virtualLibraryDbContext.SaveChangesAsync();

        }
    }
}
