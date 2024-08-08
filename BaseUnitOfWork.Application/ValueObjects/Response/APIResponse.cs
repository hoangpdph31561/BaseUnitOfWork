using System.Net;
using System.Text.Json.Serialization;

namespace BaseUnitOfWork.Application.ValueObjects.Response
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorMessages = new List<string>();
        }
        [JsonPropertyName("statusCode")]
        public HttpStatusCode StatusCode { get; set; }
        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; } = true;
        [JsonPropertyName("errorMessages")]
        public List<string> ErrorMessages { get; set; }
        [JsonPropertyName("result")]
        public object Result { get; set; }
    }
}
