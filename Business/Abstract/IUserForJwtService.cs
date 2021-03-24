using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserForJwtService
    {
        IDataResult<List<OperationClaim>> GetClaims(UserForJwt userForJwt);
        IResult Add(UserForJwt userForJwt);
        IDataResult<UserForJwt> GetByMail(string mail);
       
    }
}
