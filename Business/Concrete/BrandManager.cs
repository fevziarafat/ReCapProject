using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
           _brandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetByLetterSize(Expression<Func<Brand, bool>> filter)
        {
            return filter==null ? _brandDal.GetAll()
                : _brandDal.GetAll(filter);
        }

        public List<Brand> GetByLetterSize()
        {
            return _brandDal.GetAll(p => p.BrandName.Length > 15);
        }
    }
}
