using AutoMapper;
using Microsoft.AspNetCore.Http;
using Red_Social1.Core.Application.Dtos.Account;
using Red_Social1.Core.Application.Helpers;
using Red_Social1.Core.Application.Interfaces.Repositories;
using Red_Social1.Core.Application.Interfaces.Services;
using Red_Social1.Core.Application.ViewModels.Publication;
using Red_Social1.Core.Application.ViewModels.User;
using Red_Social1.Core.Domain.Entities;
using StockApp.Core.Application.Interfaces.Services;
using System.Diagnostics;
using System.Xml.Linq;

namespace Red_Social1.Core.Application.Services
{
    public class PublicationService : GenericService<SavePublicationViewModel, PublicationViewModel, Publication>, IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _accountService;
        private readonly AuthenticationResponse userViewModel;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PublicationService(IPublicationRepository publicationRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(publicationRepository, mapper)
        {
            _publicationRepository = publicationRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");

        }

        public override async Task<SavePublicationViewModel> Add(SavePublicationViewModel vm)
        {
            AuthenticationResponse id = userViewModel;
            vm.UserId = userViewModel.Id;
            return await base.Add(vm);
        }

        public async Task<List<PublicationViewModel>> GetAllViewModelWithInclude()
        {

            //UserResponse user = await _accountService.GetUserWithEmail(userViewModel.Email);

            var publicationList = await _publicationRepository.GetAllWithIncludeAsync(new List<string> { "Publications" });

            return publicationList.Where(publication => publication.UserId == userViewModel.Id).Select(publication => new PublicationViewModel
            {

                Id = publication.Id,
                Content = publication.Content,
                UserId = publication.UserId
            }).ToList();
        }

        public Task Update(SavePublicationViewModel vm, int id)
        {
            throw new NotImplementedException();
        }

        Task<SavePublicationViewModel> IGenericService<SavePublicationViewModel, PublicationViewModel, Publication>.GetByIdSaveViewModel(int id)
        {
            throw new NotImplementedException();
        }
    }
}
