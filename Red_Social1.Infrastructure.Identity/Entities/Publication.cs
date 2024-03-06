using Red_Social1.Core.Domain.Common;
using Red_Social1.Core.Domain.Entities;


namespace Red_Social1.Infrastructure.Identity.Entities
{
    public class PublicationUser : AuditableBasePublicationEntity
    {
        public string Content { get; set; }

        public int ComentaryId { get; set; }

        public ICollection<ComentaryUser>? Comentaries { get; set; }
        public string UserId { get; set; }

        public ApplicationUser? User { get; set; }
    }
}
