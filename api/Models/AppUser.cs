namespace api.Models;

public record AppUser
(
string Email,
string Name,
string LastName,
string NationalId,
string Password,
string ConfirmPassword,
string gender,
string Country,
string SkillLevel,
int Age,
int DatOfBirth
);
    

