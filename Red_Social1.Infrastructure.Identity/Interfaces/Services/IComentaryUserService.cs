using Red_Social1.Core.Application.Interfaces.Services;
using Red_Social1.Core.Domain.Entities;
using Red_Social1.Infrastructure.Identity.Entities;
using Red_Social1.Infrastructure.Identity.ViewModels.Comentary;
using Red_Social1.Infrastructure.Identity.ViewModels.Publication;

namespace Red_Social1.Infrastructure.Identity.Interfaces.Services
{
    public interface IComentaryUserService : IGenericService<SaveComentaryUserViewModel, ComentaryUserViewModel, ComentaryUser>
    {
        Task<List<ComentaryUserViewModel>> GetAllViewModelWithInclude();
    }
}
