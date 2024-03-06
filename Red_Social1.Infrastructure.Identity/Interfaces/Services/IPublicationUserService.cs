using Red_Social1.Core.Application.Interfaces.Services;
using Red_Social1.Core.Domain.Entities;
using Red_Social1.Infrastructure.Identity.Entities;
using Red_Social1.Infrastructure.Identity.ViewModels.Publication;

namespace Red_Social1.Infrastructure.Identity.Interfaces.Services
{
    public interface IPublicationUserService : IGenericService<SavePublicationUserViewModel, PublicationUserViewModel, PublicationUser>
    {
        Task<List<PublicationUserViewModel>> GetAllViewModelWithInclude();
    }
}
