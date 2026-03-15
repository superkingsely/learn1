using System;
using Auth.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Auth.Services.contract;

public interface IAuthService
{
    Task<ApiResponseDto<object>> RegisterAsync(RegisterDto model);
    Task<ApiResponseDto<object>> LoginAsync(LoginDto model);
}
