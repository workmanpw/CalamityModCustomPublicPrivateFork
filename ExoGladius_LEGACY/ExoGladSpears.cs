using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Buffs.DamageOverTime;

namespace CalamityMod.ExoGladius_LEGACY
{
	public class ExoGladSpearsLegacy : ModProjectile
    {
        public override string Texture => "CalamityMod/ExoGladius_LEGACY/ExoGladius";

        private Color currentColor = Color.Black;

        internal ref float FlySpeedMultiplier => ref Projectile.ai[1];

        public override void SetStaticDefaults()
        {
            // DisplayName and Tooltip are now handled automatically through localization files
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 7;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.timeLeft = 600;
            Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
            
            // No homing - just fly straight
            if (Projectile.timeLeft > 30)
                Projectile.timeLeft = 30;

            Lighting.AddLight(Projectile.Center, Main.DiscoR * 0.5f / 255f, Main.DiscoG * 0.5f / 255f, Main.DiscoB * 0.5f / 255f);
            if (currentColor == Color.Black)
            {
                int startPoint = Main.rand.Next(6);
                Projectile.localAI[0] = startPoint;
                currentColor = GetStartingColor(startPoint);
            }
            Visuals(Projectile, ref currentColor);
        }

        internal static void Visuals(Projectile Projectile, ref Color c)
        {
            CalamityUtils.IterateDisco(ref c, ref Projectile.localAI[0], 15);
            Vector3 compositeColor = 0.1f * Color.White.ToVector3() + 0.05f * c.ToVector3();
            Lighting.AddLight(Projectile.Center, compositeColor);
        }

        internal static Color GetStartingColor(int startPoint = 0)
        {
            switch (startPoint)
            {
                default: return new Color(1f, 0f, 0f, 0f); // Color.Red
                case 1: return new Color(1f, 1f, 0f, 0f); // Color.Yellow
                case 2: return new Color(0f, 1f, 0f, 0f); // Color.Green
                case 3: return new Color(0f, 1f, 1f, 0f); // Color.Turquoise
                case 4: return new Color(0f, 0f, 1f, 0f); // Color.Blue
                case 5: return new Color(1f, 0f, 1f, 0f); // Color.Violet
            }
        }

        // This Projectile is always fullbright.
        public override Color? GetAlpha(Color lightColor) => currentColor;

        public override bool PreDraw(ref Color lightColor)
        {
            CalamityUtils.DrawAfterimagesCentered(Projectile, ProjectileID.Sets.TrailingMode[Projectile.type], lightColor, 1);
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<MiracleBlight>(), 300);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
			target.AddBuff(ModContent.BuffType<MiracleBlight>(), 300);
        }
    }
}
