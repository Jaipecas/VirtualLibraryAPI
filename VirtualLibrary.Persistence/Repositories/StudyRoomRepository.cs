
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Domain.StudyRoom;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.Repositories
{
    public class StudyRoomRepository : GenericRepository<StudyRoom>, IStudyRoomRepository
    {
        private readonly VirtualLibraryDbContext _virtualLibraryContext;

        public StudyRoomRepository(VirtualLibraryDbContext context) : base(context)
        {
            _virtualLibraryContext = context;
        }
    }
}
