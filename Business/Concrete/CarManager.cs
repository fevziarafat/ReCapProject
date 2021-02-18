using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
   public class CarManager: ICarService
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
            if (car.CarName.Length>=2&&car.DailyPrice>0)
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
          if (DateTime.Now.Hour==22)
          {
              return new ErrorDataResult<Car>(Messages.MaintenanceTime);
          }

          return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id), Messages.ProductAdded);
          
       }

       public IDataResult<List<Car>> GetAll()
       {
            return new DataResult<List<Car>>(_carDal.GetAll(), true, Messages.ProductAdded);
            
       }

       public IDataResult<List<Car>> GetCarsByBrandId(int id)
       {
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.Id==id).ToList(),Messages.ListedMessage);
           
       }

       public IDataResult<Car> GetCarsByColorId(int id)
       {
           return new SuccessDataResult<Car>(_carDal.Get(p => p.ColorId == id));
           //return _carDal.GetAll(p => p.ColorId == id);
       }

       public IDataResult<List<CarDetailDto>> GetCarDetails()
       {
           return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().ToList(),Messages.ProductAdded);
          // return _carDal.GetCarDetails();
       }
   }
}
