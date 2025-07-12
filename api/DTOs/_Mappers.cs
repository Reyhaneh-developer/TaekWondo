using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs;

public static class Mappers
{
    public static loggedinDto ConvertAppUserToLoggedInDto(AppUser appuser)
    {
        return new(
            Email:appuser.Email,
            Name:appuser.Name,
        );
    }

  public static ConvertAppUserToMemberDto(AppUser appuser)
  {
    return new(
        Email:appuser.Email,
        Name:appuser.Name,
        Age:appuser.Age,
        Gender:appuser.Gender,
        City:appuser.City,
        Country:appuser.Country
    );
  }
}