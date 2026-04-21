using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Buffs.DamageOverTime;
using CalamityMod.Utilities;
using CalamityMod.ExoGladius_LEGACY;

namespace CalamityMod.Projectiles.Melee
{
    public class ExoGladProj : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles";
        public override string Texture => "CalamityMod/ExoGladius_LEGACY/InvisibleProj";

        private float counter = 0f;

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 300;
        }

        public override void AI()
        {
            Vector2 value7 = new Vector2(5f, 10f);
            counter += 1f;
            if (counter == 48f)
            {
                counter = 0f;
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    int dustType = i == 0 ? 107 : 234;
                    if (Main.rand.NextBool(4))
                    {
                        dustType = 269;
                    }
                    Vector2 offset = -Vector2.UnitY.RotatedBy((double)(counter * 0.1308997f + (float)i * MathHelper.Pi), default) * value7;
                    int exo = Dust.NewDust(Projectile.Center, 0, 0, dustType, 0f, 0f, 160, default, 1.5f);
                    Main.dust[exo].noGravity = true;
                    Main.dust[exo].position = Projectile.Center + offset;
                    Main.dust[exo].velocity = Projectile.velocity;
                    int dusters = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, dustType, 0f, 0f, 100, default, 0.8f);
                    Main.dust[dusters].noGravity = true;
                    Main.dust[dusters].velocity *= 0f;
                }
            }

            CalamityUtils.HomeInOnNPC(Projectile, true, 250f, 12f, 20f);
        }

        [Obsolete]
        public override void OnKill(int timeLeft)
        {
            int dustType = Utils.SelectRandom(Main.rand, [107, 234, 269]);
            for (int k = 0; k < 4; k++)
            {
                int exo = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, dustType, (float)(Projectile.direction * 2), 0f, 150, default, 1f);
                Main.dust[exo].noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            OnHitEffects(target.Center);
            target.AddBuff(ModContent.BuffType<MiracleBlight>(), 300);
        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            OnHitEffects(target.Center);
            target.AddBuff(ModContent.BuffType<MiracleBlight>(), 300);
        }

        private void OnHitEffects(Vector2 targetPos)
        {
            float swordKB = Projectile.knockBack;
            int swordDmg = (int)(Projectile.damage * 0.25);
            int numSwords = Main.rand.Next(2, 5);
            
            if (Projectile.owner == Main.myPlayer)
            {
                for (int i = 0; i < numSwords; ++i)
                {
                    // Pick a random screen edge: 0 = Top, 1 = Bottom, 2 = Left, 3 = Right
                    int side = Main.rand.Next(4);
                    Vector2 spawnPos = targetPos;
                    float dist = Main.rand.NextFloat(700f, 900f);

                    switch (side)
                    {
                        case 0: // Top
                            spawnPos += new Vector2(Main.rand.NextFloat(-500f, 500f), -dist);
                            break;
                        case 1: // Bottom
                            spawnPos += new Vector2(Main.rand.NextFloat(-500f, 500f), dist);
                            break;
                        case 2: // Left
                            spawnPos += new Vector2(-dist, Main.rand.NextFloat(-500f, 500f));
                            break;
                        case 3: // Right
                            spawnPos += new Vector2(dist, Main.rand.NextFloat(-500f, 500f));
                            break;
                    }

                    Vector2 velocity = (targetPos - spawnPos).SafeNormalize(Vector2.UnitY) * Main.rand.NextFloat(26f, 34f);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), spawnPos, velocity, ModContent.ProjectileType<ExoGladiusBeamLegacy>(), swordDmg, swordKB, Projectile.owner);
                }

                // Keeps a small amount of rain spears for extra visual chaos
                for (int n = 0; n < Main.rand.Next(1, 3); n++)
                {
                    CalamityUtils.ProjectileRain(Projectile.GetSource_FromThis(), targetPos, 400f, 100f, -1000f, -800f, 29f, ModContent.ProjectileType<ExoGladSpearsLegacy>(), swordDmg, swordKB, Projectile.owner);
                }
            }
        }
    }
}