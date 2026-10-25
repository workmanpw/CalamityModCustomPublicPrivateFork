#nullable enable

using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CalamityMod.Utilities.Daybreak;

/// <summary>
///     A "snapshot" of the current state of a <see cref="SpriteBatch" />.
///     <br />
///     These values may be manipulated freely.
/// </summary>
/// <remarks>
///     This API exists for making preservation of a <see cref="SpriteBatch" />'s
///     state trivial.
///     <br />
///     The act of taking a snapshot through this object's constructor is pure
///     (that is, it has no side effects).  It will not mutate the state of the
///     <see cref="SpriteBatch" /> being analyzed.  If you intend to modify the
///     <see cref="SpriteBatch" />, use the APIs provided in
///     <see cref="SpriteBatchSnapshotExtensions" />.
/// </remarks>
internal struct SpriteBatchSnapshot
{
    // FNA's SpriteBatch keeps its active parameters in private fields.  They are
    // not exposed through any public API, so cache the field metadata once and
    // read it directly through reflection when taking a snapshot.
    private static readonly FieldInfo? sortModeField = typeof(SpriteBatch).GetField("sortMode", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo? blendStateField = typeof(SpriteBatch).GetField("blendState", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo? samplerStateField = typeof(SpriteBatch).GetField("samplerState", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo? depthStencilStateField = typeof(SpriteBatch).GetField("depthStencilState", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo? rasterizerStateField = typeof(SpriteBatch).GetField("rasterizerState", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo? customEffectField = typeof(SpriteBatch).GetField("customEffect", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo? transformMatrixField = typeof(SpriteBatch).GetField("transformMatrix", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo? beginCalledField = typeof(SpriteBatch).GetField("beginCalled", BindingFlags.Instance | BindingFlags.NonPublic);

    private static T GetFieldValue<T>(SpriteBatch spriteBatch, FieldInfo? field, T fallback)
    {
        if (field is null)
            return fallback;

        object? value = field.GetValue(spriteBatch);
        return value is T typed ? typed : fallback;
    }

    /// <summary>
    ///     Determines whether the given <see cref="SpriteBatch"/> currently has
    ///     an active <see cref="SpriteBatch.Begin"/> call.
    /// </summary>
    public static bool IsActive(SpriteBatch spriteBatch)
    {
        return GetFieldValue(spriteBatch, beginCalledField, false);
    }

    /// <summary>
    ///     The sort mode.
    /// </summary>
    public SpriteSortMode SortMode { get; set; }

    /// <summary>
    ///     The blend state.
    /// </summary>
    public BlendState BlendState { get; set; }

    /// <summary>
    ///     The sampler state.
    /// </summary>
    public SamplerState SamplerState { get; set; }

    /// <summary>
    ///     The depth stencil state.
    /// </summary>
    public DepthStencilState DepthStencilState { get; set; }

    /// <summary>
    ///     The rasterizer state.
    /// </summary>
    public RasterizerState RasterizerState { get; set; }

    /// <summary>
    ///     The custom effect, if applicable.
    /// </summary>
    public Effect? CustomEffect { get; set; }

    /// <summary>
    ///     The transformation matrix.
    /// </summary>
    public Matrix TransformMatrix { get; set; }

    /// <summary>
    ///     Creates a new <see cref="SpriteBatch"/> snapshot from raw
    ///     parameters.
    /// </summary>
    public SpriteBatchSnapshot(
        SpriteSortMode sortMode,
        BlendState blendState,
        SamplerState samplerState,
        DepthStencilState depthStencilState,
        RasterizerState rasterizerState,
        Effect? customEffect,
        Matrix transformMatrix
    )
    {
        SortMode = sortMode;
        BlendState = blendState;
        SamplerState = samplerState;
        DepthStencilState = depthStencilState;
        RasterizerState = rasterizerState;
        CustomEffect = customEffect;
        TransformMatrix = transformMatrix;
    }

    /// <summary>
    ///     Creates a new <see cref="SpriteBatch"/> snapshot from the current
    ///     settings of the given <see cref="SpriteBatch"/>.
    /// </summary>
    /// <param name="spriteBatch">
    ///     The <see cref="SpriteBatch" /> to take a snapshot of.
    /// </param>
    public SpriteBatchSnapshot(SpriteBatch spriteBatch)
    {
        SortMode = GetFieldValue(spriteBatch, sortModeField, SpriteSortMode.Deferred);
        BlendState = GetFieldValue(spriteBatch, blendStateField, BlendState.AlphaBlend);
        SamplerState = GetFieldValue(spriteBatch, samplerStateField, SamplerState.LinearClamp);
        DepthStencilState = GetFieldValue(spriteBatch, depthStencilStateField, DepthStencilState.None);
        RasterizerState = GetFieldValue(spriteBatch, rasterizerStateField, RasterizerState.CullNone);
        CustomEffect = GetFieldValue(spriteBatch, customEffectField, (Effect?)null);
        TransformMatrix = GetFieldValue(spriteBatch, transformMatrixField, Matrix.Identity);
    }

    /// <summary>
    ///     Initializes a set of parameters from this snapshot.
    /// </summary>
    public readonly SpriteBatchParameters ToParameters()
    {
        return new SpriteBatchParameters(
            SortMode,
            BlendState,
            SamplerState,
            DepthStencilState,
            RasterizerState,
            CustomEffect,
            TransformMatrix
        );
    }
}

/// <summary>
///     Extensions to <see cref="SpriteBatch" /> using
///     <see cref="SpriteBatchSnapshot" /> instances.
/// </summary>
internal static class SpriteBatchSnapshotExtensions
{
    /// <summary>
    ///     Takes a snapshot of the <see cref="SpriteBatch" /> and then ends the
    ///     <see cref="SpriteBatch" />/
    /// </summary>
    /// <param name="sb">The <see cref="SpriteBatch" />.</param>
    /// <param name="ss">The produced <see cref="SpriteBatchSnapshot" />.</param>
    public static void End(this SpriteBatch sb, out SpriteBatchSnapshot ss)
    {
        ss = new SpriteBatchSnapshot(sb);
        sb.End();
    }

    /// <summary>
    ///     Starts a <see cref="SpriteBatch" /> with the parameters from the
    ///     given <see cref="SpriteBatchSnapshot" />.
    /// </summary>
    /// <param name="sb">The <see cref="SpriteBatch" />.</param>
    /// <param name="ss">The <see cref="SpriteBatchSnapshot" /> to use.</param>
    public static void Begin(this SpriteBatch sb, in SpriteBatchSnapshot ss)
    {
        sb.Begin(
            ss.SortMode,
            ss.BlendState,
            ss.SamplerState,
            ss.DepthStencilState,
            ss.RasterizerState,
            ss.CustomEffect,
            ss.TransformMatrix
        );
    }

    /// <summary>
    ///     Immediately ends and then starts the given <see cref="SpriteBatch" />
    ///     with the parameters from the given
    ///     <see cref="SpriteBatchSnapshot" />.
    /// </summary>
    /// <param name="sb">The <see cref="SpriteBatch" />.</param>
    /// <param name="ss">The <see cref="SpriteBatchSnapshot" /> to use.</param>
    public static void Restart(this SpriteBatch sb, in SpriteBatchSnapshot ss)
    {
        sb.End();
        sb.Begin(ss);
    }
}
