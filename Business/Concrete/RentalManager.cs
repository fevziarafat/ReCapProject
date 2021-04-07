using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {

            var cardata1 = _rentalDal.GetAll(p => p.CarId == rental.CarId).Last();
            var cardataDate = _rentalDal.GetAll(p => p.RentDate == rental.RentDate);
            var cardataDate2 = _rentalDal.GetAll(p => p.ReturnDate == rental.ReturnDate);
          
                if (cardata1.ReturnDate != null  && cardata1.RentDate < rental.RentDate && cardata1.ReturnDate < rental.ReturnDate)
                {
                    _rentalDal.Add(rental);
                    return new SuccessResult();
                }
                Console.WriteLine(Messages.CarIsNotHere);
                return new ErrorResult(Messages.CarIsNotHere);
       
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> Get(Rental rental)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == rental.Id));
            // return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id), Messages.ProductAdded);

        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new DataResult<List<Rental>>(_rentalDal.GetAll(), true, "merhaba");
        }

        public IDataResult<List<Rental>> GetByLetterSize(int size)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.Id == size));
        }

        public IDataResult<List<RentalDetailsDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetails().ToList());
        }
    }
}
