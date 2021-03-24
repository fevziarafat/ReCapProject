using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<UserForJwt> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<UserForJwt> Login(UserForLoginDto userForRegisterDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(UserForJwt userForJwt);
    }
}
