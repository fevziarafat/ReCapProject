using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        //ister data ve mesaj döndür
        public SuccessDataResult(T data, string message):base(data,true,message)
        {
            
        }
        //data döndür
        public SuccessDataResult(T data) : base(data, true)
        {
            
        }
        //sadece mesaj döndür
        public SuccessDataResult(string message):base(default,true,message)
        {
            
        }
        //hiçbirşey döndürme default veri tipidir int string vb
        public SuccessDataResult():base(default,true)
        {
            
        }
    }
}
