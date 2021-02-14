using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        private List<Brand> _brands = new List<Brand>
        {
            new Brand {BrandName = "Ford", Id = 1},
            new Brand {BrandName = "Kia", Id = 2},
            new Brand {BrandName = "Mercedes", Id = 3},
            new Brand {BrandName = "BMW", Id = 4},
        };
        public List<Brand> GetAll()
        {
            return _brands;
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Update(Brand brand)
        {
            var item=_brands.SingleOrDefault(p => p.Id == brand.Id);
            item.BrandName = brand.BrandName;

        }

        public void Delete(Brand brand)
        {
            var item=_brands.SingleOrDefault(p => p.Id == brand.Id);
            _brands.Remove(item);
        }
    }
}
