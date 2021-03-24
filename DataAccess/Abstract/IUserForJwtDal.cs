using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserForJwtDal:IEntityRepositoryBase<UserForJwt>
    {
        List<OperationClaim> GetClaims(UserForJwt userForJwt);
    }
}
