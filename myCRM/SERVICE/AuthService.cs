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
             var existingUser = await _userManager.FindByEmailAsync(model.Email);

        if (existingUser != null)
        {
            return ResponseModel<bool>.Failure("Email already exists");
        }
         var newUser = new AppUser
    {
        UserName = model.Email, // IMPORTANT
        Email = model.Email,
        Gender = model.Gender,
        DateOfBirth = model.DateOfBirth,
        ImageName = model.ImageName
    };

         var result = await _userManager.CreateAsync(newUser, model.Password);

    if (!result.Succeeded)
    {
        return ResponseModel<bool>.Failure(
            string.Join(", ", result.Errors.Select(e => e.Description)));
    }

    return ResponseModel<bool>.Success(true);

    }

    public Task<bool> ResetPasswordAsync(ApplicationUserRegisterInputModel model)
    {
        throw new NotImplementedException();
    }
}
