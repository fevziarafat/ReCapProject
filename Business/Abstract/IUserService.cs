using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User> Get(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetByLetterSize(int size);
    }
}
