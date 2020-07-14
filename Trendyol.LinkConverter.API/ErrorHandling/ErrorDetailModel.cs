using Newtonsoft.Json;

namespace Trendyol.LinkConverter.API.ErrorHandling
{
    public class ErrorDetailModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
