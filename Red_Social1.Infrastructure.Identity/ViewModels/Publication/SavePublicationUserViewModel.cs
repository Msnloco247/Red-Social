using Microsoft.AspNetCore.Http;
using Red_Social1.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Red_Social1.Infrastructure.Identity.ViewModels.Publication
{
    public class SavePublicationUserViewModel
    {
        public int Id { get; set; }


        public string? UserId { get; set; }

        [Required(ErrorMessage = "Debe colocar colocar un contenido")]
        [DataType(DataType.Text)]
        public string Content { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }

    }
}
