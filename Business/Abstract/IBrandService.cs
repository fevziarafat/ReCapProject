using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
        IDataResult<Brand> Get(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetByLetterSize(int size);

    }
}
