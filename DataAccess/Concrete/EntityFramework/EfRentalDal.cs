using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
       

        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                    join c in context.Customers
                        on r.CustomerId equals c.Id
                    join a in context.Cars
                        on r.CarId equals a.Id
                    join b in context.Brands
                        on a.BrandId equals b.Id
                       
                    select new RentalDetailsDto
                    {
                        BrandName = b.BrandName,
                        FirstName = c.CompanyName,
                        LastName = "",
                        ReturnDate = r.ReturnDate,
                        CustomerId = c.Id,
                        RentDate = r.RentDate,
                        CarId = a.Id,
                        RentalId = r.Id
                    };
                return result.ToList();
            }
        }
    }
}
