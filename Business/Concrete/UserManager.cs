using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
           _userDal.Add(user);
           return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IDataResult<User> Get(User user)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == user.Id));
        }

        public IDataResult<List<User>> GetAll()
        {
            //if (DateTime.Now.Hour==03)
            //{
            //    return new ErrorDataResult<List<User>>("Sistem bakımda");
            //}
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<List<User>> GetByLetterSize(int size)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(p => p.FirstName.Length > size));
        }
    }
}
