using System.Text.Json.Serialization;

namespace Application.Feature
{
    public class ReasonCodeResponse : IEntityResponse
    {
        [JsonPropertyName("id")] public Guid Id { get ; set ; }
        [JsonPropertyName("uid")] public Guid UserId { get; set; }
        [JsonPropertyName("code")] public string? Code { get; set; }
        [JsonPropertyName("desc")] public string? Description { get; set; }
        [JsonPropertyName("cd")] public DateTimeOffset CreatedDate { get ; set ; }
        [JsonPropertyName("md")] public DateTimeOffset? ModifiedDate { get ; set ; }
        [JsonPropertyName("cuid")] public Guid CreatedUserId { get ; set ; }
        [JsonPropertyName("muid")] public Guid? ModifiedUserId { get ; set ; }
        [JsonPropertyName("res")] public ICollection<ReasonCodeRecordResponse>? ReasonCodeRecord { get; set; }
    }
}
