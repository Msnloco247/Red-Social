using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Red_Social1.Core.Application.Dtos.Account;

using WebApp.Red_Social1.Middlewares;
using Red_Social1.Core.Application.Helpers;
using Red_Social1.Infrastructure.Identity.Interfaces.Services;
using Red_Social1.Infrastructure.Identity.ViewModels.Comentary;
using Red_Social1.Infrastructure.Identity.ViewModels.Publication;



namespace Red_Social1.Controllers
{
    [Authorize(Roles = "Basic")]
    public class ComentaryController : Controller
    {
        private readonly IComentaryUserService _comentaryService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ComentaryController(IComentaryUserService comentaryService, IHttpContextAccessor httpContextAccessor, ValidateUserSession validateUserSession)
        {
            _comentaryService = comentaryService;

            _httpContextAccessor = httpContextAccessor;
        }




        public async Task<IActionResult> Index()
        {
            return View(await _comentaryService.GetAllViewModelWithInclude());
        }

        [HttpPost]

        public async Task<IActionResult> Index(SaveComentaryUserViewModel vm)
        {
            return View(await _comentaryService.GetAllViewModelWithInclude());
        }


        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ComentaryPublicationViewModel vm)
        {
            vm.comentary.UserId = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user").Id;

            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "Publications", action = "Index" });
            }

            await _comentaryService.Add(vm.comentary);
            return RedirectToRoute(new { controller = "Publications", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _comentaryService.Delete(id);

            return RedirectToRoute(new { controller = "Comentarys", action = "Index" });
        }
    }
}
