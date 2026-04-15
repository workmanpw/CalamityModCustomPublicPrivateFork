using CalamityModCustomPublicPrivateFork.Projectiles.Typeless;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea
{
    [LegacyName("RuneSand")]
    public class Dunesand : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<EutrophicSand>();

            //+5 flat damage
            ItemID.Sets.SandgunAmmoProjectileData[Type] = new(ModContent.ProjectileType<DuneSandBallGun>(), 5);
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.SunkenSea.Dunesand>());
            Item.ammo = AmmoID.Sand;
            Item.notAmmo = true;
        }
    }
}
