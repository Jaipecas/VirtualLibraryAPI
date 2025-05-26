
using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Domain.BoardEntities;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.Repositories
{
    public class BoardRepository : GenericRepository<Board>, IBoardRepository
    {
        private readonly VirtualLibraryDbContext _virtualLibraryContext;

        public BoardRepository(VirtualLibraryDbContext virtualLibraryContext) : base(virtualLibraryContext)
        {
            _virtualLibraryContext = virtualLibraryContext;
        }

        public async Task<List<Board>> GetAllUserBoards(string userId)
        {
            var boards = await _virtualLibraryContext.Boards.Where(b => b.UserId == userId).ToListAsync();

            return boards;
        }
    }
}
