using System;
using System.Reflection;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalamityMod.Utilities.Daybreak.Buffers;

/// <summary>
///     Handles preserving the contents of <see cref="RenderTarget2D" />s.
///     <br />
///     For most cases, <see cref="RenderTargetScope"/> is preferred for
///     temporarily swapping render targets.
/// </summary>
public static class RenderTargetPreserver
{
    /// <summary>
    ///     Forcefully sets the usage of a given set of render target bindings to
    ///     preserve contents.
    /// </summary>
    /// <param name="bindings"></param>
    public static void PreserveBindings(RenderTargetBinding[] bindings)
    {
        foreach (var binding in bindings)
        {
            if (binding.RenderTarget is not RenderTarget2D rt)
            {
                continue;
            }

            // FNA RenderTargetUsage is now read-only (CS0200) in current tModLoader/FNA:
            // there is no setter to publicize, private or otherwise. Set the backing
            // field via reflection instead, preserving the original intent. If the
            // field is not found (future FNA change), skip silently rather than crash.
            try
            {
                var field = typeof(RenderTarget2D).GetField("<RenderTargetUsage>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
                field?.SetValue(rt, RenderTargetUsage.PreserveContents);
            }
            catch
            {
                // PreserveContents could not be forced; leave the binding as-is.
            }
        }
    }

    /// <summary>
    ///     A utility method that gets the current bindings from the graphics
    ///     device and ensures they are preserved.
    /// </summary>
    /// <returns></returns>
    public static RenderTargetBinding[] GetAndPreserveCurrentBindings()
    {
        var bindings = Main.instance.GraphicsDevice.GetRenderTargets();
        {
            PreserveBindings(bindings);
        }

        return bindings;
    }
}
