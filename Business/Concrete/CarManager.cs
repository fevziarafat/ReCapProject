using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            // var context = new ValidationContext<Car>(car);
            //CarValidator carValidator = new CarValidator();
            //var result = carValidator.Validate(context);
            if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                //Magic Strings
                return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult(Messages.ProductNameInvalid);
        }

        public IDataResult<Car> GetById(int id)
        {
            // return new Result(true, "İşlem Başarılı");
            //if (3==4)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(), true, Messages.ProductAdded);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id).ToList(), Messages.ListedMessage);

        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id).ToList());
            //return _carDal.GetAll(p => p.ColorId == id);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().ToList(), Messages.ProductAdded);
            // return _carDal.GetCarDetails();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsId(id).ToList(), Messages.ProductAdded);

        }

        public IDataResult<List<CarListDto>> GetCarList()
        {
            return new SuccessDataResult<List<CarListDto>>(_carDal.GetCarList());
        }

        public IDataResult<List<CarListDto>> GetCarListWithBrand(int brandId)
        {
            return new SuccessDataResult<List<CarListDto>>
                (_carDal.GetCarList().Where(p => p.BrandId == brandId).ToList());
        }

        public IDataResult<List<CarListDto>> GetCarListWithColor(int colorId)
        {
            return new SuccessDataResult<List<CarListDto>>
            (_carDal.GetCarList().Where(p => p.ColorId == colorId)
                .ToList());
        }

        public IDataResult<List<CarListDto>> GetCarListWithBrandName(string brandName)
        {
            return new SuccessDataResult<List<CarListDto>>
            (_carDal.GetCarList().Where(p => p.BrandName == brandName)
                .ToList());
        }

        public IDataResult<List<CarListDto>> GetCarListWithColorName(string colorName)
        {
            return new SuccessDataResult<List<CarListDto>>
            (_carDal.GetCarList().Where(p => p.ColorName == colorName)
                .ToList());
        }

        public IDataResult<List<CarListDto>> GetCarDetailsWithImage(int id)
        {
            return new SuccessDataResult<List<CarListDto>>
                (_carDal.GetCarList().Where(p=>p.CarId==id).ToList());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }
    }
}
