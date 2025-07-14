using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace api.DTOs;

public static class Mappers
{
  public static LoggedInDto ConvertAppUserToLoggedInDto(AppUser appuser, string tokenValue)
  {
    return new(
        Email: appuser.Email,
        Name: appuser.Name,
        Token: tokenValue
    );
  }

  public static MemberDto ConvertAppUserToMemberDto(AppUser appUser)
  {
    return new(
        Email: appUser.Email,
        Name: appUser.Name,
        Age: appUser.Age,
        Gender: appUser.Gender,
        City: appUser.City,
        Country: appUser.Country
    );
  }

}