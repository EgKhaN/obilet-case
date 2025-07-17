using Microsoft.AspNetCore.Http;
using oBilet.Application.Abstractions;
using oBilet.Core.Common;
using oBilet.Infrastructure.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Infrastructure.OBiletAPI
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        private readonly IBrowserHelper _browserHelper;
        public SessionService(IHttpContextAccessor httpContextAccessor, IBrowserHelper browserHelper)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
            _browserHelper = browserHelper;
        }
        public string GetSessionValue(string key)
        {
            return _session.GetString(key);
        }

        public void SetSessionValue(string key, string value)
        {
            _session.SetString(key, value);
        }

        public string GetUserIP()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null)
            {
                throw new InvalidOperationException("HttpContext is not available.");
            }
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            return ipAddress ?? "IP Address not found";
        }
        
        public string GetPortNumber()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null)
            {
                throw new InvalidOperationException("HttpContext is not available.");
            }
            var portNumber = context.Request.Host.Port.ToString();
            return portNumber ?? "Port number not found";
        }
        public string GetBrowserName()
        {
            var browserName = _browserHelper.GetBrowserDetails()?.Name;
            return browserName ?? "Browser name not found";
        }
        public string GetBrowserVersion()
        {
            var browserVersion = _browserHelper.GetBrowserDetails()?.Version;
            return browserVersion ?? "Browser version not found";
        }
       
    }
}
