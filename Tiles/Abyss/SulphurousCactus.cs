using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Abyss
{
    public class SulphurousCactus : ModCactus
    {
        public override void SetStaticDefaults()
        {
            // Grows on sulphurous sand
            GrowsOnTileId = new int[] { ModContent.TileType<SulphurousSand>() };
        }

        public override Asset<Texture2D> GetTexture() => ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Tiles/Abyss/SulphurousCactus");

        //What is a FruitTexture
        public override Asset<Texture2D> GetFruitTexture() => null;
    }
}
