using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CreditCartManager:ICreditCartService
    {
        public IResult MakePayment(CreditCart cart)
        {
            int random = new Random().Next(0, 2);
            if (random==0)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
