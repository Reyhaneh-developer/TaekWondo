using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs;

public record MemberDto
(    string Email,
    string Name,
    int Age,
    string gender,
    string City,
    string Country
);