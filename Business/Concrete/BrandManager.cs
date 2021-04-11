using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;
        private ICarService _carService;
        //bir entity manager kendisi hariç başka bir dalı enjecte edemez
        public BrandManager(IBrandDal brandDal, ICarService carService)
        {
            _brandDal = brandDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            string businessResult = null;
            // IResult businessResult = BusinessRules.Run(SameNameCheck(brand), BrandGetAllBusiness(), CarServiceBusiness());
            if (businessResult == null)
            {
                _brandDal.Add(brand);
                return new SuccessResult();
            }
            return new ErrorResult();
            //  ValidationTool.Validate(new BrandValidator(), brand);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(BrandValidator))]
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
        private IResult BrandGetAllBusiness()
        {
            var result = _brandDal.GetAll();
            return new SuccessResult();
        }
        private IResult CarServiceBusiness()
        {
            var carNumber = _carService.GetAll();
            if (carNumber.Data.Count > 9)
            {
                return new ErrorResult(Messages.CarNumberLimitedIsOver);
            }
            return new SuccessResult();
        }
        private IResult SameNameCheck(Brand brand)
        {
            var result = _brandDal.GetAll(p => p.BrandName == brand.BrandName).Any();
            //var carNumber = _carService.GetAll();
            if (result)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
