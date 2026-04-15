using CalamityModCustomPublicPrivateFork.Systems;
using CalamityModCustomPublicPrivateFork.Tiles.SunkenSea;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Merges
{
    public sealed class ShellstoneMerge : TileBlendTexture
    {
        public override int TileType => ModContent.TileType<Shellstone>();
    }
}
