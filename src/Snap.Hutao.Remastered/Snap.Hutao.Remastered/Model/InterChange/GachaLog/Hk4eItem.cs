// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Snap.Hutao.Remastered.Core.Text.Json.Annotation;
using Snap.Hutao.Remastered.Core.Text.Json.Converter;
using Snap.Hutao.Remastered.Model.Entity;
using Snap.Hutao.Remastered.Web.Hoyolab.Hk4e.Event.GachaInfo;

namespace Snap.Hutao.Remastered.Model.InterChange.GachaLog;

// ReSharper disable once InconsistentNaming
public sealed class Hk4eItem : IJsonOnDeserialized
{
    // ReSharper disable once InconsistentNaming

    [JsonPropertyName("gacha_type")]
    [JsonEnumHandling(JsonEnumHandling.NumberString)]
    public required GachaType GachaType { get; init; }

    [JsonPropertyName("item_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public required uint ItemId { get; init; }

    [JsonPropertyName("count")]
    public required string Count { get; init; }

    [JsonPropertyName("time")]
    [JsonConverter(typeof(SimpleDateTimeConverter))]
    public required DateTime Time { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("item_type")]
    public required string ItemType { get; init; }

    [JsonPropertyName("rank_type")]
    public required string RankType { get; init; }

    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public required long Id { get; init; }

    [JsonPropertyName("uigf_gacha_type")]
    [JsonEnumHandling(JsonEnumHandling.NumberString)]
    public required GachaType UIGFGachaType { get; init; }

    public static Hk4eItem From(GachaItem item, string name, string itemType, string rankType)
    {
        return new()
        {
            UIGFGachaType = item.QueryType,
            GachaType = item.GachaType,
            ItemId = item.ItemId,
            Count = "1",
            Time = item.Time.UtcDateTime,
            Name = name,
            ItemType = itemType,
            RankType = rankType,
            Id = item.Id,
        };
    }

    public void OnDeserialized()
    {
        if (!Enum.IsDefined(UIGFGachaType))
        {
            throw new JsonException($"Unsupported UIGFGachaType: {UIGFGachaType}");
        }

        if (!Enum.IsDefined(GachaType))
        {
            throw new JsonException($"Unsupported GachaType: {GachaType}");
        }
    }
}