using System.Collections.Generic;
using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepositoryBase<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<Car> GetById(int id );

        List<CarDetailDto> GetCarDetailsId(int id);
        List<CarListDto> GetCarList();
    }
}
