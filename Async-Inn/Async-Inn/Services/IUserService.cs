using Async_Inn.Models.Api;
using Async_Inn.Models.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Services
{
    public interface IUserService
    {
        Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState);
    }
}
