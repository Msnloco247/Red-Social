using Microsoft.AspNetCore.Identity;
using Red_Social1.Core.Domain.Entities;


namespace Red_Social1.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? PhotoUrl { get; set; }


        public ICollection<PublicationUser>? Publications { get; set; }
        public ICollection<ComentaryUser>? Comentaries { get; set; }


    }
}
