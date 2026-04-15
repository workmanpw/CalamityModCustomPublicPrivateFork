using CalamityModCustomPublicPrivateFork.NPCs.Abyss;
using CalamityModCustomPublicPrivateFork.NPCs.Astral;
using CalamityModCustomPublicPrivateFork.NPCs.Crags;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class BestiaryRegistrySystem : ModSystem
    {
        public override void PostSetupContent()
        {
            // Manually register variants post-initiailization
            ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[NPCType<AstralachneaGround>()] = ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[NPCType<AstralachneaWall>()];
            ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[NPCType<DevilFishAlt>()] = ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[NPCType<DevilFish>()];
            ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[NPCType<ScryllarRage>()] = ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[NPCType<Scryllar>()];
        }
    }
}
