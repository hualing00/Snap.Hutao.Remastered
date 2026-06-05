// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using System.Collections.Immutable;

namespace Snap.Hutao.Remastered.Model.InterChange.GachaLog;

// This class unfortunately can't use required properties because it's been rooted in XamlTypeInfo
// ReSharper disable once InconsistentNaming
public class UIGF
{
    [JsonRequired]
    [JsonPropertyName("info")]
    [JsonPropertyOrder(0)]
    public UIGFInfo Info { get; init; } = default!;

    // ReSharper disable once InconsistentNaming
    [JsonPropertyName("hk4e")]
    [JsonPropertyOrder(1)]
    public ImmutableArray<UIGFEntry<Hk4eItem>> Hk4e { get; set; }
}
