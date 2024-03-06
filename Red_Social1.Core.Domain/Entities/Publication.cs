using Red_Social1.Core.Domain.Common;

namespace Red_Social1.Core.Domain.Entities
{
    public class Publication : AuditableBasePublicationEntity
    {
        public string Content { get; set; }

        public int ComentaryId { get; set; }

        public ICollection<Comentary>? Comentaries { get; set; }
        public string UserId { get; set; }


    }
}
