using CalamityModCustomPublicPrivateFork.Systems;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Merges
{
    public sealed class AstralSnowMerge : TileBlendTexture
    {
        public override int TileType => ModContent.TileType<AstralSnow.AstralSnow>();
    }
}
