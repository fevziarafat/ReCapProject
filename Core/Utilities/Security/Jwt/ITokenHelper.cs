using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(UserForJwt userForJwt,List<OperationClaim> operationClaims);
    }
}
