using System;
using Microsoft.AspNetCore.Identity;
using MODELS;
using MODELS.Models.InputModel;
using MODELS.Models.ViewsModel;
using SERVICE.Iservice;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SERVICE;

public class AuthService : IAuthService
{
   private readonly UserManager<AppUser> _userManager;
    // private readonly SignInManager<AppUser> _signInManager;
    // SignInManager<AppUser> signInManager
    public AuthService(
        UserManager<AppUser> userManager
        )
    {
        _userManager = userManager;
        // _signInManager = signInManager;
    }
    public Task<bool> ChangePasswordAsync(ApplicationUserRegisterInputModel model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ForgotPasswordAsync(ApplicationUserRegisterInputModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<bool>> LoginAsync(ApplicationUserLoginInputModel model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RefreshTokenAsync(ApplicationUserRegisterInputModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseModel<bool>> RegisterAsync(ApplicationUserRegisterInputModel model)
    {
        // validate model.Email && model.Password
       if (model.Password != model.ConfirmPassword)
        {
            return ResponseModel<bool>.Failure("Passwords do not match");
        }
        var newuser= new AppUser
        {
            Email=model.Email,
            PasswordHash=model.Password
            
        };
        var res=await _userManager.CreateAsync();
        return res.successful?Ok()://throw error
    }

    public Task<bool> ResetPasswordAsync(ApplicationUserRegisterInputModel model)
    {
        throw new NotImplementedException();
    }
}
