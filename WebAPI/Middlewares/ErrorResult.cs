using Newtonsoft.Json;

namespace WebAPI.Middlewares
{
    public class ErrorResult : ErrorStatusCode
    {
        public string Message { get; set; }
    }

    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this); //JsonConvert kullanmak için Newtonsoft.Json kütüphanesini kullanmak gerekli

        }
    }

    public class ValidationErrorDetails : ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
