
namespace VirtualLibrary.Domain
{
    public class GenericEntity
    {
        public int Id { get; set; }
        public required string CreatedBy { get; set; }
        public required DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
