using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Application.Abstractions
{
    public interface ISessionService
    {
        void SetSessionValue(string key, string value);
        string GetSessionValue(string key);
        string GetUserIP();
        string GetPortNumber();
        string GetBrowserName();
        string GetBrowserVersion();
    }
}
