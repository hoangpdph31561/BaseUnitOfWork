using System.Text.Json.Serialization;

namespace BaseUnitOfWork.Application.ValueObjects.Common
{
    public class RefreshToken
    {
        [JsonPropertyName("userId")]
        public Guid? UserId { get; set; } = null;
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;
        [JsonPropertyName("createdTime")]
        public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
        [JsonPropertyName("expires")]
        public DateTimeOffset Expires { get; set; }
    }
}
