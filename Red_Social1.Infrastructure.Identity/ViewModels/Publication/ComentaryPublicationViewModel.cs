

using Red_Social1.Infrastructure.Identity.ViewModels.Comentary;

namespace Red_Social1.Infrastructure.Identity.ViewModels.Publication
{
    public class ComentaryPublicationViewModel
    {
        public List<PublicationUserViewModel>? publications { get; set; }
        public SaveComentaryUserViewModel comentary { get; set; }
    }
}
