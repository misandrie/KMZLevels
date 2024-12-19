using System;
using Content.KayMisaZlevels.Shared.Miscellaneous;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.ViewVariables;

namespace Content.KayMisaZlevels.Shared.Components;

/// <summary>
///     Marker that transitions between Z-Levels
/// </summary>
[RegisterComponent]
public sealed class ZTransitionMarkerComponent : Component
{
    /// <summary>
    /// Direction this marker transitions an entity (Up or Down)
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("Direction")]
    private ZDirection _dir;

    /// <summary>
    /// Map position of this marker
    /// </summary>
    [ViewVariables(VVAccess.ReadOnly)]
    [NonSerialized]
    public MapCoordinates Position;
}
