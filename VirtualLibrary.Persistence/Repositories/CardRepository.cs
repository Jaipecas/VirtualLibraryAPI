
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Domain.BoardEntities;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.Repositories
{
    public  class CardRepository : GenericRepository<Card>, ICardRepository
    {
        private readonly VirtualLibraryDbContext _virtualLibraryContext;

        public CardRepository(VirtualLibraryDbContext virtualLibraryContext) : base(virtualLibraryContext)
        {
            _virtualLibraryContext = virtualLibraryContext;
        }
    }
}
