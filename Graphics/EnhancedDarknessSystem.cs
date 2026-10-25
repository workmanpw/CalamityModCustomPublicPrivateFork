using System;
using System.Collections.Generic;
using CalamityMod.Utilities.Daybreak;
using CalamityMod.Utilities.Daybreak.Buffers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Light;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace CalamityMod.Graphics
{
    public class EnhancedDarknessSystem : ModSystem
    {
        private static Asset<Texture2D> _defaultTexture;

        public class LightSource
        {
            public Texture2D texture = _defaultTexture.Value;
            public float scale = 1;
            public Vector2 vectorScale = Vector2.One;
            public Vector2 center = Main.LocalPlayer.Center;
            public float rotation = 0;
            public float opacity = 1;
            public Color color = Color.White;
            public int lifetime = 1;
            public Rectangle? frame = null;

            public LightSource() { }

            public LightSource(Vector2? center = null, Texture2D texture = null, float scale = 1, float rotation = 0, Vector2? vectorScale = null, float opacity = 1)
            {
                this.texture = texture ?? ModContent.Request<Texture2D>("CalamityMod/Particles/BloomCircle").Value;
                this.scale = scale;
                this.vectorScale = vectorScale ?? Vector2.One;
                this.center = center ?? Main.LocalPlayer.Center;
                this.rotation = rotation;
                this.opacity = opacity;
            }
        }

        public static List<LightSource> lights = new();

        public override void Load()
        {
            On_OverlayManager.Draw += DrawShadowOverlay;
            On_LightingEngine.UpdateLightDecay += AdjustTransmissiveness;
            _defaultTexture = ModContent.Request<Texture2D>("CalamityMod/Particles/BloomCircle");
        }

        private void DrawShadowOverlay(On_OverlayManager.orig_Draw orig, OverlayManager self, SpriteBatch spriteBatch, RenderLayers layer, bool beginSpriteBatch)
        {
            orig(self, spriteBatch, layer, beginSpriteBatch);

            if (Main.gameMenu || layer != RenderLayers.All || Main.LocalPlayer.Calamity().darknessIntensity <= 0)
                return;

            var mp = Main.LocalPlayer.Calamity();
            var device = Main.instance.GraphicsDevice;

            using var lease = RenderTargetPool.Shared.Rent(
                device,
                Main.screenWidth,
                Main.screenHeight,
                RenderTargetDescriptor.Default
            );

            // The overlay manager may or may not leave a SpriteBatch active,
            // depending on the call site and whether any vanilla overlays were
            // drawn.  Preserve whichever state we inherited instead of relying
            // on the (incorrect) assumption that only beginSpriteBatch=true can
            // leave a batch running.
            bool wasBatchActive = SpriteBatchSnapshot.IsActive(Main.spriteBatch);
            SpriteBatchSnapshot ss = default;
            if (wasBatchActive)
                Main.spriteBatch.End(out ss);

            using (lease.Scope(clearColor: Color.Transparent))
            {
                Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, SamplerState.LinearClamp, DepthStencilState.Default, Main.Rasterizer, null, Matrix.Identity);
                foreach (var item in lights)
                {
                    Main.spriteBatch.Draw(item.texture, (item.center - Main.screenPosition), item.frame, item.color * item.opacity, item.rotation, item.frame is null ? item.texture.Size() * 0.5f : item.frame.Value.Size(), item.vectorScale * item.scale, SpriteEffects.None, 0);
                }
                Main.spriteBatch.End();
            }

            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, Main.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
            var shader = GameShaders.Misc["CalamityMod:DozeLightingShader"];
            if (shader != null)
            {
                shader.UseOpacity(mp.darknessIntensity);
                shader.Apply();
            }
            Main.spriteBatch.Draw(lease.Target, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1, 0, 0);
            Main.spriteBatch.End();

            // Only restart the batch if we were the ones who ended it.
            if (wasBatchActive)
                Main.spriteBatch.Begin(ss);
        }

        private void AdjustTransmissiveness(On_LightingEngine.orig_UpdateLightDecay orig, LightingEngine self)
        {
            orig(self);
            var mp = Main.LocalPlayer.Calamity();
            if (mp.ZoneAbyss)
            {
                // Logic preserved for future implementation if LightMap accessibility is restored.
            }
        }

        public override void OnWorldUnload()
        {
            lights.Clear();
        }

        public override void PreUpdateEntities()
        {
            for (var i = 0; i < lights.Count; i++)
            {
                var item = lights[i];
                item.lifetime--;
                if (item.lifetime <= 0)
                {
                    lights.Remove(item);
                    i--;
                }   
            }
        }
    }
}