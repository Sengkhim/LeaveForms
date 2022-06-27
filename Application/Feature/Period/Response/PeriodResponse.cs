using System.Text.Json.Serialization;

namespace Application.Feature
{
    public class PeriodResponse : IEntityResponse
    {
        [JsonPropertyName("id")] public Guid Id { get ; set ; }
        [JsonPropertyName("uid")] public Guid UserId { get; set; }
        [JsonPropertyName("desc")] public string? Description { get; set; }
        [JsonPropertyName("bd")] public DateTimeOffset? BeginDate { get; set; }
        [JsonPropertyName("ed")] public DateTimeOffset? EndDate { get; set; }
        [JsonPropertyName("cd")] public DateTimeOffset CreatedDate { get ; set ; }
        [JsonPropertyName("md")] public DateTimeOffset? ModifiedDate { get ; set ; }
        [JsonPropertyName("cuid")] public Guid CreatedUserId { get ; set ; }
        [JsonPropertyName("muid")] public Guid? ModifiedUserId { get ; set ; }
    }
}
