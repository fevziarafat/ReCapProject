using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface ICreditCartService
    {
        IResult MakePayment(CreditCart cart);
    }
}
