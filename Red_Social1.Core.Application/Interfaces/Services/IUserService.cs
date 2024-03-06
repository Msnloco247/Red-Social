using Red_Social1.Core.Application.Dtos.Account;
using Red_Social1.Core.Application.ViewModels.User;

namespace Red_Social1.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel vm);

        //Task<UserResponse> GetUserWithEmail(string email);
        Task SignOutAsync();
    }
}