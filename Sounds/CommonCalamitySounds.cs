using Terraria.Audio;

namespace CalamityModCustomPublicPrivateFork.Sounds
{
    public static class CommonCalamitySounds
    {
        public static readonly SoundStyle AstralNPCDeathSound = new("CalamityModCustomPublicPrivateFork/Sounds/NPCKilled/AstralEnemyDeath") { Volume = 0.7f };
        public static readonly SoundStyle AstralNPCHitSound = new("CalamityModCustomPublicPrivateFork/Sounds/NPCHit/AstralEnemyHit", 3);

        public static readonly SoundStyle ELRFireSound = new("CalamityModCustomPublicPrivateFork/Sounds/Item/ELRFire"); //What does ELR stand for
        public static readonly SoundStyle ExoDeathSound = new("CalamityModCustomPublicPrivateFork/Sounds/NPCKilled/ExoDeath") { MaxInstances = 1 };
        public static readonly SoundStyle ExoHitSound = new("CalamityModCustomPublicPrivateFork/Sounds/NPCHit/ExoHit", 4) { Volume = 0.4f };
        public static readonly SoundStyle ExoLaserShootSound = new("CalamityModCustomPublicPrivateFork/Sounds/Custom/ExoMechs/ExoLaserShoot");
        public static readonly SoundStyle ExoPlasmaExplosionSound = new("CalamityModCustomPublicPrivateFork/Sounds/Custom/ExoMechs/ExoPlasmaExplosion", 2);
        public static readonly SoundStyle ExoPlasmaShootSound = new("CalamityModCustomPublicPrivateFork/Sounds/Custom/ExoMechs/ExoPlasmaShoot");

        public static readonly SoundStyle FlareSound = new("CalamityModCustomPublicPrivateFork/Sounds/Item/FlareSound");

        public static readonly SoundStyle LargeWeaponFireSound = new("CalamityModCustomPublicPrivateFork/Sounds/Item/LargeWeaponFire");
        public static readonly SoundStyle LaserCannonSound = new("CalamityModCustomPublicPrivateFork/Sounds/Item/LaserCannon") { Volume = 0.85f };
        public static readonly SoundStyle LightningSound = new("CalamityModCustomPublicPrivateFork/Sounds/Custom/LightningStrike") { Volume = 1.6f }; // This is just the regular SoundID.Thunder sound, except its only the first variant
        public static readonly SoundStyle LouderPhantomPhoenix = new("CalamityModCustomPublicPrivateFork/Sounds/Item/LouderPhantomPhoenix", 3);

        public static readonly SoundStyle MeatySlashSound = new("CalamityModCustomPublicPrivateFork/Sounds/Custom/MeatySlash");

        public static readonly SoundStyle PlagueBoomSound = new("CalamityModCustomPublicPrivateFork/Sounds/Custom/PlagueSounds/PlagueBoom", 4);
        public static readonly SoundStyle PlasmaBoltSound = new("CalamityModCustomPublicPrivateFork/Sounds/Item/PlasmaBolt") { Volume = 0.8f };
        public static readonly SoundStyle PlatingMine = new("CalamityModCustomPublicPrivateFork/Sounds/Custom/PlatingMine", 3);

        public static readonly SoundStyle ScissorGuillotineSnapSound = new("CalamityModCustomPublicPrivateFork/Sounds/Custom/ScissorGuillotineSnap");
        public static readonly SoundStyle SwiftSliceSound = new("CalamityModCustomPublicPrivateFork/Sounds/Custom/SwiftSlice");

        public static readonly SoundStyle VoidstoneMine = new("CalamityModCustomPublicPrivateFork/Sounds/Custom/VoidstoneMine", 3) { Volume = 0.4f };

        public static readonly SoundStyle WulfrumNPCDeathSound = new("CalamityModCustomPublicPrivateFork/Sounds/NPCKilled/WulfrumDeath");
        public static readonly SoundStyle WyrmScreamSound = new("CalamityModCustomPublicPrivateFork/Sounds/Custom/WyrmScream");
    }
}
