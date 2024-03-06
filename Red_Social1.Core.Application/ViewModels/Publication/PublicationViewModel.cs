using Red_Social1.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace Red_Social1.Core.Application.ViewModels.Publication
{
    public class PublicationViewModel
    {
        public int Id { get; set; }


        public string UserId { get; set; }

        [Required(ErrorMessage = "Debe colocar colocar un contenido")]
        [DataType(DataType.Text)]
        public string Content { get; set; }

        public ICollection<Comentary>? Comentaries { get; set; }

    }
}
