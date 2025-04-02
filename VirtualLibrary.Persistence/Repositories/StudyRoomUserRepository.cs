
using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Domain.StudyRoomEntities;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.Repositories
{
    public class StudyRoomUserRepository : GenericRepository<StudyRoomUser>, IStudyRoomUserRepository
    {
        private readonly VirtualLibraryDbContext _virtualLibraryContext;

        public StudyRoomUserRepository(VirtualLibraryDbContext context) : base(context)
        {
            _virtualLibraryContext = context;
        }

        public async Task<List<StudyRoomUser>?> GetByRoomId(int roomId)
        {
            var result = await _virtualLibraryContext.StudyRoomUsers.Where(studyRoomUser => studyRoomUser.StudyRoom.Id == roomId).ToListAsync();
            return result;
        }

        public bool RemoveRoomUsers(List<StudyRoomUser> roomsUser)
        {
            _virtualLibraryContext.StudyRoomUsers.RemoveRange(roomsUser);
            return true;
        }

        public async Task<List<StudyRoomUser>?> GetRoomsByUser(string userId)
        {
            var result = await _virtualLibraryContext.StudyRoomUsers.Where(studyRoomUser => studyRoomUser.User.Id == userId && studyRoomUser.IsAccepted == true).ToListAsync();
            return result;
        }
    }
}
