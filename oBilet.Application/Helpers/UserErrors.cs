
using oBilet.Application.DTOs.Session;

namespace oBilet.Application.Helpers;

public static class UserErrors
{
    public static Error AuthorizationFailed(UserSessionData userSessionData) => Error.Failure(
        "Users.AuthorizationFailed",
        "Http Authorization failed");
    public static Error Unauthorized() => Error.Failure(
        "Users.Unauthorized",
        "You are not authorized to perform this action.");

}
