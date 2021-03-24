using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserForJwtService _userForJwtService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserForJwtService userForJwtService, ITokenHelper tokenHelper)
        {
            _userForJwtService = userForJwtService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<UserForJwt> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash,out passwordSalt);
            var user = new UserForJwt
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userForJwtService.Add(user);
            return new SuccessDataResult<UserForJwt>(user, Messages.UserRegistered);
        }

        public IDataResult<UserForJwt> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userForJwtService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<UserForJwt>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(
                userForLoginDto.Password,userToCheck.Data.PasswordHash,userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<UserForJwt>(Messages.PasswordError);
            }

            return new SuccessDataResult<UserForJwt>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userForJwtService.GetByMail(email)!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(UserForJwt userForJwt)
        {
           var claims= _userForJwtService.GetClaims(userForJwt);
          var accessToken= _tokenHelper.CreateToken(userForJwt, claims.Data);
          return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
