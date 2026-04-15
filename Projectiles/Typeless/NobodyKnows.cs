using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Projectiles.Typeless
{
    public class NobodyKnows : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Typeless";
        public override string Texture => "CalamityModCustomPublicPrivateFork/Projectiles/InvisibleProj";

        public override void SetDefaults()
        {
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 1;
        }
    }
}
