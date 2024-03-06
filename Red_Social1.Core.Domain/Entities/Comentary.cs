using Red_Social1.Core.Domain.Common;

namespace Red_Social1.Core.Domain.Entities
{
    public class Comentary : AuditableBasePublicationEntity
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public int PublicationId { get; set; }

        public Publication Publication { get; set; }
    }
}
