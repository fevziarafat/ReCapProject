using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {

          //  ValidationTool.Validate(new BrandValidator(), brand);
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {

            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }

       

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll().ToList());
        }

        public IDataResult<List<Brand>> GetByLetterSize(Expression<Func<Brand, bool>> filter)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(filter).ToList());
         
        }

        public IDataResult<List<Brand>> GetByLetterSize(int size)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p => p.BrandName.Length > size).ToList());
            // return _brandDal.GetAll(p => p.BrandName.Length > 15);
        }

       public IDataResult<Brand> Get(Brand brand)
       {
           return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == brand.Id));
       }
    }
}
