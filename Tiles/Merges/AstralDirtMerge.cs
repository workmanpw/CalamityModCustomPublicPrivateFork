using CalamityModCustomPublicPrivateFork.Systems;
using CalamityModCustomPublicPrivateFork.Tiles.Astral;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Merges
{
    public sealed class AstralDirtMerge : TileBlendTexture
    {
        public override int TileType => ModContent.TileType<AstralDirt>();
    }
}
