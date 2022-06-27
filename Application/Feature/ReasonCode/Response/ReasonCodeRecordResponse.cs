using System.Text.Json.Serialization;

namespace Application.Feature
{
    public class ReasonCodeRecordResponse
    {
        [JsonPropertyName("id")] public Guid Id { get; set; }
        [JsonPropertyName("cd")] public DateTimeOffset CreatedDate { get; set; }
        [JsonPropertyName("cuid")] public Guid CreatedUserId { get; set; }
        [JsonPropertyName("md")] public DateTimeOffset? ModifiedDate { get; set; }
        [JsonPropertyName("muid")] public Guid? ModifiedUserId { get; set; }
        [JsonPropertyName("resid")] public Guid ReasonCodeId { get; set; }
        [JsonPropertyName("perid")] public Guid PeriodId { get; set; }
        [JsonPropertyName("restid")] public Guid RecordStatusTypeId { get; set; }
        [JsonPropertyName("des")] public string? Description { get; set; }
        [JsonPropertyName("bd")] public DateTimeOffset? BeginDate { get; set; }
        [JsonPropertyName("ed")] public DateTimeOffset? EndDate { get; set; }
        [JsonPropertyName("rest")] public string? RecordStatusTypeCode { get; set; }
    }
}
