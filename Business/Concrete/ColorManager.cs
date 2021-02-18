using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.ValidationRules;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class ColorManager:IColorService
   {
       private IColorDal _colorDal;

       public ColorManager(IColorDal colorDal)
       {
          
           _colorDal = colorDal;
       }

       public IResult Add(Color color)
        {
            ValidationTool.Validate(new ColorValidation(), color);
            _colorDal.Add(color);
            return new SuccessResult();
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return  new SuccessResult();
           
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll().ToList());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(p => p.Id == id));
            //return _colorDal.Get(p => p.Id == id);
        }
   }
}
