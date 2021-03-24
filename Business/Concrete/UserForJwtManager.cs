using System.Collections.Generic;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserForJwtManager: IUserForJwtService
    {
        private IUserForJwtDal _userForJwtDal;

        public UserForJwtManager(IUserForJwtDal userForJwtDal)
        {
            _userForJwtDal = userForJwtDal;
        }


        public IDataResult<List<OperationClaim>> GetClaims(UserForJwt userForJwt)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userForJwtDal.GetClaims(userForJwt));
        }

        public IResult Add(UserForJwt userForJwt)
        {
            _userForJwtDal.Add(userForJwt);
            return new SuccessResult();
        }

        public IDataResult<UserForJwt> GetByMail(string mail)
        {
            return new DataResult<UserForJwt>(_userForJwtDal.Get(p => p.Email == mail),true);
        }

       
    }
}
