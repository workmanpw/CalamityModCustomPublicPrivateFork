using CalamityModCustomPublicPrivateFork.Systems;
using CalamityModCustomPublicPrivateFork.Tiles.AstralDesert;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Merges
{
    public sealed class AstralSandstoneMerge : TileBlendTexture
    {
        public override int TileType => ModContent.TileType<AstralSandstone>();
    }
}
