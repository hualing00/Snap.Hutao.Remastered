using Snap.Hutao.Remastered.Web.Hoyolab.Hk4e.Event.GachaInfo;
using System.Collections.Frozen;

namespace Snap.Hutao.Remastered.Service.GachaLog;

public static class BeyondGachaLog
{
    public static readonly FrozenSet<GachaType> QueryTypes =
    [
        GachaType.UGCStandard,
        GachaType.UGCAvatarEventWish,
    ];
}
