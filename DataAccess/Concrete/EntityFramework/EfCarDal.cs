using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapProjectContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join d in context.Colors
                        on c.ColorId equals d.Id
                    select new CarDetailDto
                    {
                        BrandName = b.BrandName, CarName = c.CarName, DailyPrice = c.DailyPrice, ColorName = d.ColorName
                    };

                return result.ToList();
            }
        }
    }
}
