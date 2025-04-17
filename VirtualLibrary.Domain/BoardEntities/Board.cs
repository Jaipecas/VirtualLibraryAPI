
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VirtualLibrary.Domain.BoardEntities
{
    public class Board : GenericEntity
    {
        public required string Title { get; set; }

        private List<CardList>? _cardLists;
        public List<CardList>? CardLists
        {
            get => _lazyLoader.Load(this, ref _cardLists);
            set => _cardLists = value;
        }

        private readonly ILazyLoader _lazyLoader;
        public Board(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;
        public Board() { }
    }
}
