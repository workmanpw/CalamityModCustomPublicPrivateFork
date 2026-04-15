using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Skies
{
    [Autoload(Side = ModSide.Client)]
    internal sealed class SkyTextureRefs : ModSystem
    {
        // Astral Sky/BG
        public static Asset<Texture2D> AstralSky;
        public static Asset<Texture2D> AstralSurfaceFront;
        public static Asset<Texture2D> AstralSurfaceFrontGlow;
        public static Asset<Texture2D> AstralSurfaceClose;
        public static Asset<Texture2D> AstralSurfaceCloseGlow;
        public static Asset<Texture2D> AstralSurfaceMiddle;
        public static Asset<Texture2D> AstralSurfaceMiddleGlow;

        // Astral Desert Sky/BG
        public static Asset<Texture2D> AstralDesertSurfaceClose;
        public static Asset<Texture2D> AstralDesertSurfaceMiddle;

        // Astral Snow Sky/BG
        public static Asset<Texture2D> AstralSnowSurfaceMiddle;

        // Sulphur Sea Sky/BG
        public static Asset<Texture2D> SulphurSeaSky;
        public static Asset<Texture2D> SulphurSeaSkyFront;
        public static Asset<Texture2D> SulphurSeaSurface;

        public override void OnModLoad()
        {
            // Astral Sky/BG
            AstralSky = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Skies/AstralSky");
            AstralSurfaceFront = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Backgrounds/AstralSurfaceFront");
            AstralSurfaceFrontGlow = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Backgrounds/AstralSurfaceFrontGlow");
            AstralSurfaceClose = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Backgrounds/AstralSurfaceClose");
            AstralSurfaceCloseGlow = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Backgrounds/AstralSurfaceCloseGlow");
            AstralSurfaceMiddle = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Backgrounds/AstralSurfaceMiddle");
            AstralSurfaceMiddleGlow = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Backgrounds/AstralSurfaceMiddleGlow");

            //Astral Desert Sky/BG
            AstralDesertSurfaceClose = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Backgrounds/AstralDesertSurfaceClose");
            AstralDesertSurfaceMiddle = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Backgrounds/AstralDesertSurfaceMiddle");

            //Astral Snow Sky/BG
            AstralSnowSurfaceMiddle = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Backgrounds/AstralSnowSurfaceMiddle");

            // Sulpher Sea Sky/BG
            SulphurSeaSky = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Skies/SulphurSeaSky");
            SulphurSeaSkyFront = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Skies/SulphurSeaSkyFront");
            SulphurSeaSurface = ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Skies/SulphurSeaSurface");
        }

        public override void Unload()
        {
            AstralSky = null;
            AstralSurfaceFront = null;
            AstralSurfaceFrontGlow = null;
            AstralSurfaceClose = null;
            AstralSurfaceCloseGlow = null;
            AstralSurfaceMiddle = null;
            AstralSurfaceMiddleGlow = null;

            AstralDesertSurfaceClose = null;
            AstralDesertSurfaceMiddle = null;

            AstralSnowSurfaceMiddle = null;

            SulphurSeaSky = null;
            SulphurSeaSkyFront = null;
            SulphurSeaSurface = null;
        }
    }
}
