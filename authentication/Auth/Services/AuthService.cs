using System;
using Auth.DATA;
using Auth.Models;
using Auth.Models.DTOs;
using Auth.Services.contract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace Auth.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> userManager;
    private readonly SignInManager<AppUser> signInManager;

    public AuthService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }
    public async Task<ApiResponseDto<object>> LoginAsync(LoginDto model)
    {

        var isUser= await userManager.FindByEmailAsync(model.Email);//yellow squigle
        if(isUser == null)
        {
            return ApiResponseDto<object>.FailureResponse(
                new List<string>{$"{model.Email} does not exist pls "},"login faild"
            );
        }
        var result= await signInManager.PasswordSignInAsync(isUser,model.Password,false,false);//yell squi
        return ApiResponseDto<object>.SuccessResponse(
            result,"login successful"
        );
    }
    // Task<IdentityResult>
    public async Task<ApiResponseDto<object>> RegisterAsync(RegisterDto model)
    {
        try
        {
            // validate
            ArgumentNullException.ThrowIfNullOrEmpty(model.Email);
            var existingUser= await userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return ApiResponseDto<object>.FailureResponse(
                    new List<string>{"User already exit"},"reg fail"
                );
            }
            var user= new AppUser
            {
                Fullname=model.FullName,
                Email=model.Email,
                UserName=model.Email,
                // PasswordHash=model.Password //pass not hash yet
                
            };
            ArgumentNullException.ThrowIfNullOrEmpty(model.Password);
            var result= await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return ApiResponseDto<object>.FailureResponse(
                    result.Errors.Select(e=>e.Description).ToList(),"reg failed"
                );
            }            
            return ApiResponseDto<object>.SuccessResponse(
                null,"reg successful"
            );// hw will i hand the null yellwo squigle
        }
        catch (System.Exception ex)
        {
           Console.WriteLine($"Error:{ex.Message}");
            // am i suppose to hv a return here too and what return will dat be
            return ApiResponseDto<object>.FailureResponse(
                new List<string>{ex.Message},"internal server error here"
            );
        }
    }
}
