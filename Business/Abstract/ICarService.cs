using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<Car> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
      
    }
}
