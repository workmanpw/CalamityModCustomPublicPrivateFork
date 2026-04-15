using CalamityModCustomPublicPrivateFork.Systems;
using CalamityModCustomPublicPrivateFork.Tiles.Abyss;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Merges
{
    public sealed class AbyssGravelMerge : TileBlendTexture
    {
        public override int TileType => ModContent.TileType<AbyssGravel>();
    }
}
