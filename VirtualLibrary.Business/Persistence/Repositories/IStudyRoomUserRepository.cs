
using VirtualLibrary.Domain.StudyRoomEntities;

namespace VirtualLibrary.Application.Persistence.Repositories
{
    public interface IStudyRoomUserRepository : IGenericRepository<StudyRoomUser>
    {
        Task<List<StudyRoomUser>?> GetByRoomId(int roomId);
        bool RemoveRoomUsers(List<StudyRoomUser> roomsUser);
        Task<List<StudyRoomUser>?> GetRoomsByUser(string userId);
        Task<bool> DeleteRoomUsers(int roomId, List<string> userIds);
    }
}
