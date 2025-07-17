using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Infrastructure.Common.Extensions
{
    public static class SessionExtensions
    {
        /// <summary>
        /// Sets a <see cref="string"/> value in the <see cref="ISession"/>.
        /// </summary>
        /// <param name="session">The <see cref="ISession"/>.</param>
        /// <param name="key">The key to assign.</param>
        /// <param name="value">The value to assign.</param>
        public static void SetString(this ISession session, string? key, string? value)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
            session.Set(key, Encoding.UTF8.GetBytes(value));
        }

        public static string GetString(this Microsoft.AspNetCore.Http.ISession session, string key)
        {
            string result = string.Empty;
            if (session == null) throw new ArgumentNullException(nameof(session));
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            byte[] theWorkBytes;

            if (session.TryGetValue(key, out theWorkBytes))
            {
                if (theWorkBytes != null && theWorkBytes.Length > 0)
                {
                    result = Encoding.UTF8.GetString(theWorkBytes);
                }
            }
            return result;
        }
    }
}
