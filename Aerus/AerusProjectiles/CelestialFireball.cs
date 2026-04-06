using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Graphics.Shaders;
using Terraria.Graphics.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.Audio;
using static Terraria.ModLoader.ModContent;

namespace CelestialCalamityAerus.Aerus.AerusProjectiles
{
    public class CelestialFireball : ModProjectile
    {
        public override string Texture => "CelestialCalamityAerus/Aerus/CelestialFireball";
        
        public override void SetStaticDefaults()
            => DisplayName.SetDefault("Celestial Beam");

        public override void SetDefaults()
        {
            Projectile.width = 36;
            Projectile.height = 36;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 2;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 27;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 360;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 120;
        }

        public override void AI()
        {
            Projectile.rotation += 0.2f;
            Lighting.AddLight(Projectile.Center,
                Main.DiscoR / 70f, Main.DiscoG / 70f, Main.DiscoB / 70f);
            for (int i = 0; i < 6; i++)
            {
                var d = Dust.NewDustDirect(
                    Projectile.position, Projectile.width, Projectile.height,
                    DustID.RainbowTorch);
                d.velocity = Projectile.velocity * 0.5f;
                d.scale = 1.8f;
                d.noGravity = true;
                d.fadeIn = 1.2f;
                d.alpha = 100;
            }
            Projectile.localAI[0]++;
            if (Projectile.localAI[0] > 10)
            {
                float maxDetect = 500f, homingSpeed = 20f;
                NPC target = null;
                float minDist = maxDetect;
                foreach (NPC npc in Main.npc)
                    if (npc.CanBeChasedBy(Projectile))
                    {
                        float dist = Vector2.Distance(Projectile.Center, npc.Center);
                        if (dist < minDist) { minDist = dist; target = npc; }
                    }
                if (target != null)
                {
                    Vector2 to = target.Center - Projectile.Center;
                    Projectile.velocity = Vector2.Lerp(
                        Projectile.velocity,
                        Vector2.Normalize(to) * homingSpeed,
                        0.15f);
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
            => Explode();
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
            => Explode();

        private void Explode()
        {
            SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);
            for (int j = 0; j < 40; j++)
            {
                var d = Dust.NewDustDirect(Projectile.Center, 1, 1, DustID.Smoke);
                d.velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi)
                    * Main.rand.NextFloat(6f, 14f);
                d.scale = Main.rand.NextFloat(1.6f, 2.4f);
                d.noGravity = false;
            }
            for (int j = 0; j < 30; j++)
            {
                var d = Dust.NewDustDirect(Projectile.Center, 1, 1, 107);
                d.velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi)
                    * Main.rand.NextFloat(4f, 10f);
                d.scale = 1.6f;
                d.noGravity = true;
                d.fadeIn = 1.8f;
            }
        }

        public override Color? GetAlpha(Color lightColor)
            => new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
    }
}
