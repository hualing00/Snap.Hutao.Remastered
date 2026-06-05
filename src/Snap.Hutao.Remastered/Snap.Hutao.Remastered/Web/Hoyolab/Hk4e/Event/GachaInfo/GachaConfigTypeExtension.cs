// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

namespace Snap.Hutao.Remastered.Web.Hoyolab.Hk4e.Event.GachaInfo;

public static class GachaConfigTypeExtension
{
    extension(GachaType configType)
    {
        public GachaType ToQueryType()
        {
            return configType switch
            {
                GachaType.SpecialActivityAvatar => GachaType.ActivityAvatar,
                GachaType.UGCActivityAvatarMaleOne or GachaType.UGCActivityAvatarMaleTwo or GachaType.UGCActivityAvatarFemaleOne or GachaType.UGCActivityAvatarFemaleTwo => GachaType.UGCAvatarEventWish,
                _ => configType,
            };
        }
    }
}