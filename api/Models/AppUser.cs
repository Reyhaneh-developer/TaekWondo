namespace api.Models;

public record AppUser
(
 [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
  string Email,
string Name,
string LastName,
string NationalId,
string Password,
string ConfirmPassword,
string Gender,
string Country,
string City,
string SkillLevel,
int Age,
int DatOfBirth
);


