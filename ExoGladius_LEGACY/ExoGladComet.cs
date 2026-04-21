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
    public class ExoGladCometLegacy : ModProjectile
    {
        public override string Texture => "CalamityMod/ExoGladius_LEGACY/Exocomet";

        public override void SetStaticDefaults()
        {
            // DisplayName and Tooltip are now handled automatically through localization files
            Main.projFrames[Projectile.type] = 5;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
            Projectile.alpha = 50;
        }

        public override void AI()
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 5)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame > 4)
            {
                Projectile.frame = 0;
            }
            if (Projectile.timeLeft > 30 && Projectile.alpha > 0)
            {
                Projectile.alpha -= 25;
            }
            if (Projectile.timeLeft > 30 && Projectile.alpha < 128 && Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
            {
                Projectile.alpha = 128;
            }
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
            if (Projectile.alpha < 40)
            {
                int num309 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 2f - Projectile.velocity.Y * 4f), 8, 8, DustID.Terra, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, new Color(0, 255, 255), 0.5f);
                Main.dust[num309].velocity *= -0.25f;
                num309 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 2f - Projectile.velocity.Y * 4f), 8, 8, DustID.Terra, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, new Color(0, 255, 255), 0.5f);
                Main.dust[num309].velocity *= -0.25f;
                Main.dust[num309].position -= Projectile.velocity * 0.5f;
            }
            Lighting.AddLight(Projectile.Center, 0f, 0.5f, 0.5f);
            Projectile.velocity *= 1.005f;
			
            Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();
            Projectile.rotation = Projectile.velocity.ToRotation() + (Projectile.spriteDirection == 1 ? 0f : MathHelper.Pi) + MathHelper.ToRadians(90) * Projectile.direction;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(ModContent.BuffType<MiracleBlight>(), 300);
            
            // Heal player on enemy hit
            Player owner = Main.player[Projectile.owner];
            if (owner != null && owner.active)
            {
                owner.statLife += 5; // Heal 5 HP
                owner.HealEffect(5);
            }
            
            // Create large mint green particle explosion
            CreateMintGreenExplosion(Projectile.Center);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
			target.AddBuff(ModContent.BuffType<MiracleBlight>(), 300);
            
            // Heal player on enemy hit
            Player owner = Main.player[Projectile.owner];
            if (owner != null && owner.active)
            {
                owner.statLife += 5; // Heal 5 HP
                owner.HealEffect(5);
            }
            
            // Create large mint green particle explosion
            CreateMintGreenExplosion(Projectile.Center);
        }
        
        private void CreateMintGreenExplosion(Vector2 position)
        {
            // Create large mint green particle explosion
            for (int i = 0; i < 30; i++)
            {
                Vector2 velocity = Main.rand.NextVector2Circular(8f, 4f);
                int dust = Dust.NewDust(position, 0, 0, DustID.Terra, velocity.X, velocity.Y, 100, new Color(150, 255, 150), 2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 2f;
            }
            
            // Create larger central particles
            for (int i = 0; i < 15; i++)
            {
                Vector2 velocity = Main.rand.NextVector2Circular(12f, 2f);
                int dust = Dust.NewDust(position, 0, 0, DustID.Terra, velocity.X, velocity.Y, 150, new Color(100, 255, 100), 3f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1.5f;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            CalamityUtils.DrawAfterimagesCentered(Projectile, ProjectileID.Sets.TrailingMode[Projectile.type], lightColor, 1);
            return false;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(0, 255, 255, Projectile.alpha);
        }

        [Obsolete]
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.DD2_WitherBeastDeath, Projectile.Center);
            Projectile.position = Projectile.Center;
            Projectile.width = Projectile.height = 80;
            Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
            Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);
            for (int num193 = 0; num193 < 2; num193++)
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Terra, 0f, 0f, 100, new Color(0, 255, 255), 1.5f);
            }
            for (int num194 = 0; num194 < 20; num194++)
            {
                int num195 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Terra, 0f, 0f, 0, new Color(0, 255, 255), 2.5f);
                Main.dust[num195].noGravity = true;
                Main.dust[num195].velocity *= 3f;
                num195 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Terra, 0f, 0f, 100, new Color(0, 255, 255), 1.5f);
                Main.dust[num195].velocity *= 2f;
                Main.dust[num195].noGravity = true;
            }
        }
    }
}
