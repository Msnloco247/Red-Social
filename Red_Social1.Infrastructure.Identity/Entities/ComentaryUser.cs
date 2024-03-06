using Red_Social1.Core.Domain.Common;
using Red_Social1.Infrastructure.Identity.Entities;

namespace Red_Social1.Core.Domain.Entities
{
    public class ComentaryUser : AuditableBasePublicationEntity
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public int PublicationId { get; set; }

        public PublicationUser Publication { get; set; }
    }
}
