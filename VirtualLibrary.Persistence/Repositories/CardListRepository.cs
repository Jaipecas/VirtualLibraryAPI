
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Domain.BoardEntities;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.Repositories
{
    public  class CardListRepository : GenericRepository<CardList>, ICardListRepository
    {
        private readonly VirtualLibraryDbContext _virtualLibraryContext;

        public CardListRepository(VirtualLibraryDbContext virtualLibraryContext) : base(virtualLibraryContext)
        {
            _virtualLibraryContext = virtualLibraryContext;
        }
    }
}
