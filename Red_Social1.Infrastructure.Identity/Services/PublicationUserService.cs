using AutoMapper;
using Microsoft.AspNetCore.Http;
using Red_Social1.Core.Application.Dtos.Account;
using Red_Social1.Core.Application.Helpers;
using Red_Social1.Core.Application.Interfaces.Repositories;
using Red_Social1.Core.Application.Interfaces.Services;
using Red_Social1.Core.Application.Services;
using Red_Social1.Core.Domain.Entities;
using Red_Social1.Infrastructure.Identity.Entities;
using Red_Social1.Infrastructure.Identity.Interfaces.Repositories;
using Red_Social1.Infrastructure.Identity.Interfaces.Services;
using Red_Social1.Infrastructure.Identity.ViewModels.Publication;


namespace Red_Social1.Infrastructure.Identity.Services
{
    public class PublicationUserService : GenericService<SavePublicationUserViewModel, PublicationUserViewModel, PublicationUser>, IPublicationUserService
    {
        private readonly IPublicationUserRepository _publicationRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _accountService;
        private readonly AuthenticationResponse userViewModel;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PublicationUserService(IPublicationUserRepository publicationRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(publicationRepository, mapper)
        {
            _publicationRepository = publicationRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");

        }

        public override async Task<SavePublicationUserViewModel> Add(SavePublicationUserViewModel vm)
        {
            AuthenticationResponse id = userViewModel;
            vm.UserId = userViewModel.Id;
            return await base.Add(vm);
        }
        public async Task<List<PublicationUserViewModel>> GetAllViewModelWithInclude()
        {

            //UserResponse user = await _accountService.GetUserWithEmail(userViewModel.Email);

            var publicationList = await _publicationRepository.GetAllWithIncludeAsync(new List<string> { "User" });

            return publicationList.Where(publication => publication.UserId == userViewModel.Id).Select(publication => new PublicationUserViewModel
            {

                Id = publication.Id,
                Content = publication.Content,
                UserName = publication.User.FirstName + " " + publication.User.LastName,
                PhotoUrl = publication.User.PhotoUrl,
                UserId = publication.UserId
            }).ToList();
        }


    }
}
