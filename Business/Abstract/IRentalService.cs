using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> Get(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetByLetterSize(int size);

        IDataResult<List<RentalDetailsDto>> GetRentalDetails();
    }
}
