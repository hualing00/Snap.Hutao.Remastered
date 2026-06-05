// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Snap.Hutao.Remastered.Model.InterChange.GachaLog;
using Snap.Hutao.Remastered.Web.Hoyolab.Hk4e.Event.GachaInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snap.Hutao.Remastered.Model.Entity;

[Table("beyond_gacha_items")]
public sealed class BeyondGachaItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid InnerId { get; set; }

    [ForeignKey(nameof(ArchiveId))]
    public GachaArchive Archive { get; set; } = default!;

    public Guid ArchiveId { get; set; }

    public GachaType GachaType { get; set; }

    public GachaType QueryType { get; set; }

    public uint ItemId { get; set; }

    public DateTimeOffset Time { get; set; }

    public long Id { get; set; }

    public long ScheduleId { get; set; }

    public long RankType { get; set; }

    public string Uid { get; set; } = default!;

    public int IsUp { get; set; }

    public static BeyondGachaItem From(Guid archiveId, BeyondGachaLogItem item)
    {
        return new()
        {
            ArchiveId = archiveId,
            GachaType = item.GachaType,
            QueryType = item.GachaType.ToQueryType(),
            ItemId = uint.Parse(item.ItemId),
            Time = item.Time,
            Id = item.Id,
            ScheduleId = long.Parse(item.ScheduleId),
            RankType = (long)item.RankType,
            Uid = item.Uid,
            IsUp = item.IsUp,
        };
    }

    public static BeyondGachaItem From(Guid archiveId, Hk4eUGCItem item, int timezoneOffset)
    {
        return new()
        {
            ArchiveId = archiveId,
            GachaType = item.GachaType,
            QueryType = item.GachaType.ToQueryType(),
            ItemId = item.ItemId,
            Time = new(item.Time, TimeSpan.FromHours(timezoneOffset)),
            Id = item.Id,
            ScheduleId = item.ScheduleId,
            RankType = item.RankType,
            Uid = string.Empty, // Hk4eUGCItem doesn't have Uid
            IsUp = 0, // Hk4eUGCItem doesn't have IsUp
        };
    }

    public Hk4eUGCItem ToHk4eUGCItem(Metadata.Item.BeyondItem beyondItem)
    {
        return new()
        {
            GachaType = GachaType,
            ItemId = ItemId,
            Time = Time.UtcDateTime,
            Id = Id,
            ItemType = beyondItem.TypeDescription ?? string.Empty,
            ItemName = beyondItem.Name,
            ScheduleId = ScheduleId,
            RankType = RankType,
        };
    }
}
