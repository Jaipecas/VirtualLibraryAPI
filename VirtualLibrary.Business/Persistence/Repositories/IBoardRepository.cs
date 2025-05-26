
using VirtualLibrary.Domain.BoardEntities;

namespace VirtualLibrary.Application.Persistence.Repositories
{
    public interface IBoardRepository : IGenericRepository<Board>
    {
        Task<List<Board>> GetAllUserBoards(string userId);
    }
}
