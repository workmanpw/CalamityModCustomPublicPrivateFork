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

            // REFLECTION: Check if the batch is already active to prevent InvalidOperationException
            // The 'sortMode' field being non-zero internally indicates an active batch in FNA/XNA.
            var sortModeField = typeof(SpriteBatch).GetField("sortMode", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            bool isBatchActive = sortModeField != null && (int)sortModeField.GetValue(Main.spriteBatch) != 0;

            using var lease = RenderTargetPool.Shared.Rent(
                device,
                Main.screenWidth,
                Main.screenHeight,
                RenderTargetDescriptor.Default
            );

            // Only End the batch if 'beginSpriteBatch' is true AND the batch is actually active.
            // Use try-catch because the reflection check might not be reliable.
            bool endedSuccessfully = false;
            SpriteBatchSnapshot ss = default;
            if (beginSpriteBatch && isBatchActive)
            {
                try
                {
                    Main.spriteBatch.End(out ss);
                    endedSuccessfully = true;
                }
                catch (InvalidOperationException)
                {
                    // Reflection check was wrong, batch was not actually active
                    endedSuccessfully = false;
                    ss = new SpriteBatchSnapshot(Main.spriteBatch);
                }
            }
            else
            {
                ss = new SpriteBatchSnapshot(Main.spriteBatch);
            }

            using (lease.Scope(clearColor: Color.Black))
            {
                Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, SamplerState.PointClamp, DepthStencilState.Default, Main.Rasterizer, null, Matrix.Identity);
                foreach (var item in lights)
                {
                    Main.spriteBatch.Draw(item.texture, (item.center - Main.screenPosition), item.frame, item.color * item.opacity, item.rotation, item.frame is null ? item.texture.Size() * 0.5f : item.frame.Value.Size(), item.vectorScale * item.scale, SpriteEffects.None, 0);
                }
                Main.spriteBatch.End();
            }

            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, Main.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
            var shader = GameShaders.Misc["CalamityMod:DozeLightingShader"];
            if (shader != null)
            {
                shader.UseOpacity(mp.darknessIntensity);
                shader.Apply();
            }
            Main.spriteBatch.Draw(lease.Target, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1, 0, 0);
            Main.spriteBatch.End();

            // Only restart the batch if we were the ones who ended it.
            if (endedSuccessfully)
            {
                Main.spriteBatch.Begin(ss);
            }
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