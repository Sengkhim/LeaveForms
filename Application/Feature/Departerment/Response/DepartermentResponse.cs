
using System.Text.Json.Serialization;

namespace Application.Feature
{
    public class DepartermentResponse 
    {
        [JsonPropertyName("id")] public Guid Id { get; set; }
        [JsonPropertyName("na")] public string? Name { get; set; }
        [JsonPropertyName("code")] public string? Code { get; set; }
        [JsonPropertyName("desc")] public string? Description { get; set; }
        [JsonPropertyName("cd")] public DateTimeOffset CreatedDate { get; set; }
        [JsonPropertyName("md")] public DateTimeOffset? ModifiedDate { get; set; }
        [JsonPropertyName("cuid")] public Guid CreatedUserId { get; set; }
        [JsonPropertyName("muid")] public Guid? ModifiedUserId { get; set; }
    }
}
