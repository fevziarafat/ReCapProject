using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarListDto> GetCarList()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result =
                    from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join l in context.Colors
                        on c.ColorId equals l.Id
                    join i in context.CarImages
                        on c.Id equals i.CarId
                    select new CarListDto
                    {
                        BrandName = b.BrandName,
                        CarName = c.CarName,
                        DailyPrice = c.DailyPrice,
                        ColorName = l.ColorName,
                        BrandId = b.Id,
                        CarId = c.Id,
                        ColorId = l.Id,
                        Description = c.Description,
                        ModelYear = c.ModelYear,
                        ImagePath = i.ImagePath
                    }
                ;
                return result.ToList();
            }

        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result =
                    from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join d in context.Colors
                        on c.ColorId equals d.Id
                    join i in context.CarImages
                        on c.Id equals i.CarId
                    select new CarDetailDto
                    {
                        BrandName = b.BrandName,
                        CarName = c.CarName,
                        DailyPrice = c.DailyPrice,
                        ColorName = d.ColorName,
                        BrandId = b.Id,
                        CarId = c.Id,
                        ColorId = d.Id,
                        Description = c.Description,
                        ModelYear = c.ModelYear,
                        ImagePath = i.ImagePath
                    };
                return result.ToList();
            }
        }

        public List<Car> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
