﻿using Content.KZlevels.Server.Systems;
using Robust.Server.GameObjects;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Toolshed;
using Robust.Shared.Toolshed.Syntax;

namespace Content.KZlevels.Server;

[ToolshedCommand]
public sealed class ZStackCommand : ToolshedCommand
{
    private ZStackSystem? _zStack;
    private MapSystem? _map;

    [CommandImplementation("make_stack")]
    public EntityUid MakeStack([PipedArgument] EntityUid map)
    {
        _zStack ??= GetSys<ZStackSystem>();
        EntityUid? stack = null;
        _zStack.AddToStack(map, ref stack);
        return stack.Value;
    }

    [CommandImplementation("add_to_stack")]
    public EntityUid AddToStack([PipedArgument] EntityUid stack,
        [CommandArgument] ValueRef<EntityUid> map,
        [CommandInvocationContext] IInvocationContext ctx)
    {
        var val = map.Evaluate(ctx);
        _zStack ??= GetSys<ZStackSystem>();
        var stackLoc = (EntityUid?) stack;
        _zStack.AddToStack(val, ref stackLoc);
        return stack;
    }

    [CommandImplementation("quick_stack")]
    public EntityUid QuickStack([PipedArgument] EntityUid map)
    {
        _map ??= GetSys<MapSystem>();
        _zStack ??= GetSys<ZStackSystem>();

        var lowest = _map.CreateMap();
        var lower = _map.CreateMap();
        var stackLoc = (EntityUid?) null;
        _zStack.AddToStack(lowest, ref stackLoc);
        _zStack.AddToStack(lower, ref stackLoc);
        _zStack.AddToStack(map, ref stackLoc);

        return stackLoc.Value;
    }
}