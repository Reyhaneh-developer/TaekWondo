using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
string gender,
string Country,
string City,
string SkillLevel,
int Age,
int DatOfBirth
);
    

