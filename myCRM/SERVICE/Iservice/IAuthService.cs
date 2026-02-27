using System;
using MODELS.Models.InputModel;
using MODELS.Models.ViewsModel;

namespace SERVICE.Iservice;

public interface IAuthService
{
        Task<ResponseModel<bool>> LoginAsync(ApplicationUserLoginInputModel model);
        Task<ResponseModel<bool>> RegisterAsync(ApplicationUserRegisterInputModel model);
        Task<bool> ForgotPasswordAsync(ApplicationUserRegisterInputModel model);
        Task<bool> ResetPasswordAsync(ApplicationUserRegisterInputModel model);
        Task<bool> ChangePasswordAsync(ApplicationUserRegisterInputModel model);
        Task<bool> RefreshTokenAsync(ApplicationUserRegisterInputModel model);
}
