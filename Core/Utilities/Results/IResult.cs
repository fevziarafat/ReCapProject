namespace Core.Utilities.Results
{
    //Temel voidler
    //Kullanıcıya cevap döndürmek için API de durumu
    public interface IResult
    {

         bool Success { get; }
         string Message { get; }
    }
}
