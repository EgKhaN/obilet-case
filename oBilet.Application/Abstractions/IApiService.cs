using oBilet.Application.DTOs;
using oBilet.Application.DTOs.Session;
using oBilet.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Application.Abstractions
{
    public interface IApiService
    {
        Task<Result<UserSessionData?>> FetchUserSessionAsync();
        Task<T?> PostAsync<T, U>(string url, BaseRequest<U> requestModel);
        Task<T?> PostAsync<T>(string url, string serializedContent);
    }
}
