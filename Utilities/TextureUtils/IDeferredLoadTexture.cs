namespace CalamityModCustomPublicPrivateFork
{
    public interface IDeferredLoadTexture
    {
        bool IsAssetLoaded { get; }
        void OnTextureLoaded();
    }
}
