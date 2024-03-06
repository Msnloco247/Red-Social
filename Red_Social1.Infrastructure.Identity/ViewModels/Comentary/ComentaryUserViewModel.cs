using Red_Social1.Core.Domain.Entities;
using Red_Social1.Infrastructure.Identity.Entities;
using System.ComponentModel.DataAnnotations;


namespace Red_Social1.Infrastructure.Identity.ViewModels.Comentary
{
    public class ComentaryUserViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string PublicationId { get; set; }

        [Required(ErrorMessage = "Debe colocar colocar un contenido")]
        [DataType(DataType.Text)]
        public string Content { get; set; }

        public string UserName { get; set; }

        public string PhotoUrl { get; set; }


    }
}
