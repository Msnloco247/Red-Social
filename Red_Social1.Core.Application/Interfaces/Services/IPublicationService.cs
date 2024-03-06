
using Red_Social1.Core.Application.ViewModels.Publication;
using Red_Social1.Core.Domain.Entities;

namespace Red_Social1.Core.Application.Interfaces.Services
{
    public interface IPublicationService : IGenericService<SavePublicationViewModel, PublicationViewModel, Publication>
    {
    }
}
