namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //ister data ve mesaj döndür
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        //data döndür
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        //sadece mesaj döndür default veri tipini döndürür veriyi göndermez
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        //hiçbirşey döndürme default veri tipidir int string vb
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
