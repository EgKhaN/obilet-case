using Microsoft.AspNetCore.Http;
using oBilet.Application.Abstractions;
using oBilet.Application.DTOs.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace oBilet.Infrastructure.Common
{
    public class BrowserHelper : IBrowserHelper
    {
        private IHttpContextAccessor _httpContextAccessor;
        public BrowserHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Browser GetBrowserDetails()
        {
            Browser browser = new Browser(); ;
            HttpRequest request = _httpContextAccessor.HttpContext.Request;

            if (request.Headers.ContainsKey("User-Agent"))
            {
                var userAgent = request.Headers["User-Agent"].ToString();
                Console.WriteLine($"User-Agent: {userAgent}");

                var browserPatterns = new Dictionary<string, string>
            {
                { "Edge", @"Edge\/(\d+\.\d+)" },
                { "Edge (Chromium)", @"Edg\/(\d+\.\d+)" },
                { "Chrome", @"Chrome\/(\d+\.\d+)" },
                { "Firefox", @"Firefox\/(\d+\.\d+)" },
                { "Safari", @"Version\/(\d+\.\d+).*Safari" },
                { "Opera", @"OPR\/(\d+\.\d+)" },
                { "Internet Explorer", @"Trident\/\d+.*rv:(\d+\.\d+)" }
            };

                browser.Name = "Unknown";
                browser.Version = "Unknown";

                foreach (var pattern in browserPatterns)
                {
                    var match = Regex.Match(userAgent, pattern.Value);
                    if (match.Success)
                    {
                        browser.Name = pattern.Key;
                        browser.Version = match.Groups[1].Value;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("User-Agent header not found");
            }

            return browser;
        }
    }
}
