using System;
using CalamityModCustomPublicPrivateFork.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CalamityModCustomPublicPrivateFork.Systems.Graphic.PixelationSystem
{
    /// <summary>
    /// Contains a singular Action function which is used to draw any relevant asset(s) automatically with a pixelated effect based on the specified <see cref="GeneralDrawLayer"/>.
    /// </summary>
    public record class PixelatedDrawer(Action<Matrix> DrawAction, GeneralDrawLayer DrawLayer, BlendState DefaultBlendState)
    {
       
    }
}
