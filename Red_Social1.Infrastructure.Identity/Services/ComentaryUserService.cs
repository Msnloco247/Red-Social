using AutoMapper;
using Microsoft.AspNetCore.Http;
using Red_Social1.Core.Application.Dtos.Account;
using Red_Social1.Core.Application.Helpers;
using Red_Social1.Core.Application.Interfaces.Repositories;
using Red_Social1.Core.Application.Interfaces.Services;
using Red_Social1.Core.Application.Services;
using Red_Social1.Core.Domain.Entities;
using Red_Social1.Infrastructure.Identity.Interfaces.Repositories;
using Red_Social1.Infrastructure.Identity.Interfaces.Services;
using Red_Social1.Infrastructure.Identity.ViewModels.Comentary;


namespace Red_Social1.Infrastructure.Identity.Services
{
    public class ComentaryUserService : GenericService<SaveComentaryUserViewModel, ComentaryUserViewModel, ComentaryUser>, IComentaryUserService
    {
        private readonly IComentaryUserRepository _comentaryRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _accountService;
        private readonly AuthenticationResponse userViewModel;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ComentaryUserService(IComentaryUserRepository comentaryRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(comentaryRepository, mapper)
        {
            _comentaryRepository = comentaryRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");

        }

        public override async Task<SaveComentaryUserViewModel> Add(SaveComentaryUserViewModel vm)
        {
            AuthenticationResponse id = userViewModel;
            vm.UserId = userViewModel.Id;
            return await base.Add(vm);
        }
        public async Task<List<ComentaryUserViewModel>> GetAllViewModelWithInclude()
        {

            //UserResponse user = await _accountService.GetUserWithEmail(userViewModel.Email);

            var comentaryList = await _comentaryRepository.GetAllWithIncludeAsync(new List<string> { "User" });

            return comentaryList.Where(comentary => comentary.UserId == userViewModel.Id).Select(comentary => new ComentaryUserViewModel
            {

                Id = comentary.Id,
                Content = comentary.Content,
                UserName = comentary.User.FirstName + " " + comentary.User.LastName,
                PhotoUrl = comentary.User.PhotoUrl,
                UserId = comentary.UserId
            }).ToList();
        }


    }
}
