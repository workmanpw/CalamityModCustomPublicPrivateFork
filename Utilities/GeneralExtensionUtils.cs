using CalamityModCustomPublicPrivateFork.CalPlayer;
using CalamityModCustomPublicPrivateFork.Items;
using CalamityModCustomPublicPrivateFork.Items.BaseItems;
using CalamityModCustomPublicPrivateFork.NPCs;
using CalamityModCustomPublicPrivateFork.NPCs.VanillaNPCAIOverrides;
using CalamityModCustomPublicPrivateFork.Projectiles;
using Terraria;

namespace CalamityModCustomPublicPrivateFork
{
    public static partial class CalamityUtils
    {
        public static CalamityPlayer Calamity(this Player player) => player.GetModPlayer<CalamityPlayer>();
        public static CalamityGlobalNPC Calamity(this NPC npc) => npc.GetGlobalNPC<CalamityGlobalNPC>();
        public static CalamityVanillaAIOverrideNPC AIOverrideNPC(this NPC npc) => npc.GetGlobalNPC<CalamityVanillaAIOverrideNPC>();
        public static T? AIOverride<T>(this NPC npc) {
            VanillaAIOverride aiOverride = npc.GetGlobalNPC<CalamityVanillaAIOverrideNPC>().AIOverride;
            if (aiOverride == null)
                throw new System.Exception("NPC does not have an AI Override");

            if(aiOverride is T ai)
                return ai;

            throw new System.Exception($"NPC's AI Override is not of Type {typeof(T).Name}");
        }
        public static CalamityTileCollisionHarmNPC FlungNPC(this NPC npc) => npc.GetGlobalNPC<CalamityTileCollisionHarmNPC>();
        public static CalamityPolarityNPC PolarityNPC(this NPC npc) => npc.GetGlobalNPC<CalamityPolarityNPC>();
        public static CalamityGlobalItem Calamity(this Item item) => item.GetGlobalItem<CalamityGlobalItem>();
        public static CalamityGlobalProjectile Calamity(this Projectile proj) => proj.GetGlobalProjectile<CalamityGlobalProjectile>();
        public static TransformationPlayer Transformation(this Player player) => player.GetModPlayer<TransformationPlayer>();
    }
}
