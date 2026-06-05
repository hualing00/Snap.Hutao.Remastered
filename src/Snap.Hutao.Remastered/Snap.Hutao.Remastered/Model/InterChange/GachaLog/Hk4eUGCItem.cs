using Snap.Hutao.Remastered.Core.Text.Json.Annotation;
using Snap.Hutao.Remastered.Core.Text.Json.Converter;
using Snap.Hutao.Remastered.Web.Hoyolab.Hk4e.Event.GachaInfo;

namespace Snap.Hutao.Remastered.Model.InterChange.GachaLog;

public class Hk4eUGCItem : IJsonOnDeserialized
{
    // ReSharper disable once InconsistentNaming

    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public required long Id { get; init; }

    [JsonPropertyName("schedule_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public required long ScheduleId { get; init; }

    [JsonPropertyName("item_type")]
    public required string ItemType { get; init; }

    [JsonPropertyName("item_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public required uint ItemId { get; init; }

    [JsonPropertyName("item_name")]
    public required string ItemName { get; init; }

    [JsonPropertyName("rank_type")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public required long RankType { get; init; }

    [JsonPropertyName("time")]
    [JsonConverter(typeof(SimpleDateTimeConverter))]
    public required DateTime Time { get; init; }

    [JsonPropertyName("op_gacha_type")]
    [JsonEnumHandling(JsonEnumHandling.NumberString)]
    public required GachaType GachaType { get; init; }

    public void OnDeserialized()
    {
        if (!Enum.IsDefined(GachaType))
        {
            throw new JsonException($"Unsupported GachaType: {GachaType}");
        }
    }
}
