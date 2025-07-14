namespace api.Controllers;

public class MemberController(IMemberRepository memberRepository) : BaseApiController
{
    [HttpGet("get-all")]
    public async Task<ActionResult<List<MemberDto>>> GetAll(CancellationToken cancellationToken)
    {
        List<AppUser>? appUsers = await memberRepository.GetAllAsynce(cancellationToken);

        if (appUsers is null)
            return NoContent();

        List<MemberDto> memberDtos = [];

        foreach (AppUser user in appUsers)
        {
            MemberDto memberDto = Mappers.ConvertAppUserToMemberDto(user);

            memberDtos.Add(memberDto);
        }

        return memberDtos;
    }
}
