using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Red_Social1.Core.Application.Dtos.Account;
using Red_Social1.Core.Application.Interfaces.Services;
using Red_Social1.Core.Application.ViewModels.Publication;
using WebApp.Red_Social1.Middlewares;
using Red_Social1.Core.Application.Helpers;
using Microsoft.AspNetCore.Http;
using Red_Social1.Infrastructure.Identity.Interfaces.Services;
using Red_Social1.Infrastructure.Identity.ViewModels.Publication;



namespace Red_Social1.Controllers
{
    [Authorize(Roles = "Basic")]
    public class PublicationsController : Controller
    {
        private readonly IPublicationUserService _publicationService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public PublicationsController(IPublicationUserService publicationService, IHttpContextAccessor httpContextAccessor, ValidateUserSession validateUserSession)
        {
            _publicationService = publicationService;

            _httpContextAccessor = httpContextAccessor;
        }




        public async Task<IActionResult> Index()
        {
            ComentaryPublicationViewModel vm = new ComentaryPublicationViewModel();
            vm.publications = await _publicationService.GetAllViewModelWithInclude();
            return View(vm);
        }

        public IActionResult Save()
        {
            return View("SavePublication");
        }

        [HttpPost]
        public async Task<IActionResult> Save(SavePublicationUserViewModel vm)
        {
            vm.UserId = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user").Id;
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _publicationService.Add(vm);
            return RedirectToRoute(new { controller = "Publications", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _publicationService.Delete(id);

            return RedirectToRoute(new { controller = "Publications", action = "Index" });
        }
    }
}
