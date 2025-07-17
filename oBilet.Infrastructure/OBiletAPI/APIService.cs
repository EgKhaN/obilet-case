using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using oBilet.Application.Abstractions;
using oBilet.Application.DTOs;
using oBilet.Application.DTOs.Session;
using oBilet.Application.Helpers;
using oBilet.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Infrastructure.OBiletAPI
{
    public class APIService : IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISessionService _sessionService;
        private readonly ILogger<OBiletService> _logger;

        HttpClient client;

        public APIService(ILogger<OBiletService> logger, IHttpClientFactory httpClientFactory, ISessionService sessionService)
        {
            _httpClientFactory = httpClientFactory;
            client = _httpClientFactory.CreateClient(Consts.oBiletHttpFactoryName);
            _sessionService = sessionService;
            _logger = logger;
        }
        public async Task<T?> PostAsync<T>(string url, string serializedContent)
        {
            //TODO : try catch null -return -status

            T? serializedResponse = default(T);
            var serializedRequest = string.IsNullOrEmpty(serializedContent) ? null : new StringContent(serializedContent, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);

            if (serializedRequest == null)
            {
                throw new ArgumentNullException(nameof(serializedContent), "Serialized content cannot be null or empty."); //:TODO
            }

            HttpResponseMessage response = await client.PostAsync(url, serializedRequest);

            if (response.IsSuccessStatusCode)
            {
                string? responseBody = await response.Content.ReadAsStringAsync();
                if (responseBody != null)
                    serializedResponse = JsonConvert.DeserializeObject<T>(responseBody);
                return serializedResponse;
            }
            else
            {
                // Handle error
                return serializedResponse;
            }
        }

        public async Task<T?> PostAsync<T, U>(string url, BaseRequest<U> requestModel)
        {
            UserSessionData? userSessionData = await GetUserSessionData();
            if (userSessionData == null)
            {
                throw new InvalidOperationException("User session data is not available.");
            }
            requestModel.DeviceSession = new DeviceSession(userSessionData);

            var serializedContent = JsonConvert.SerializeObject(requestModel);

            return await PostAsync<T>(url, serializedContent);

        }

        public async Task<Result<UserSessionData?>> FetchUserSessionAsync()
        {
            GetSessionRequest getSessionRequest = new GetSessionRequest(_sessionService.GetUserIP(), _sessionService.GetPortNumber(), _sessionService.GetBrowserName(), _sessionService.GetBrowserVersion());

            var sessionResponse = await PostAsync<GetSessionResponse>(Endpoints.GetSessionPath, JsonConvert.SerializeObject(getSessionRequest));

            if(sessionResponse.Status != "Success")
            {
                _logger.LogError("Failed to fetch user session data");
                return Result.Failure<UserSessionData?>(UserErrors.AuthorizationFailed(null));
            }

            return sessionResponse?.Data;
        }

        public async Task<UserSessionData?> GetUserSessionData()
        {
            UserSessionData? userSessionData = null;
            var sessionValue = _sessionService.GetSessionValue(Consts.SessionDataKey);
            if (!string.IsNullOrEmpty(sessionValue))
            {
                userSessionData = JsonConvert.DeserializeObject<UserSessionData>(sessionValue);
            }
            else
            {
                var result = await FetchUserSessionAsync();
                userSessionData = result.IsFailure ? null : result.Value;
                if (userSessionData != null)
                {
                    _sessionService.SetSessionValue(Consts.SessionDataKey, JsonConvert.SerializeObject(userSessionData));
                }
            }
            return userSessionData;
        }

      

    }
}
