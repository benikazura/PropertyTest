using Vortice.Direct2D1;
using YukkuriMovieMaker.Player.Video;

namespace PropertyTest
{
    internal class PropertyTestProcessor : IVideoEffectProcessor
    {
        readonly PropertyTest item;
        ID2D1Image? input;

        public ID2D1Image Output => input ?? throw new NullReferenceException(nameof(input) + "is null");

        public PropertyTestProcessor(PropertyTest item)
        {
            this.item = item;
        }

        public DrawDescription Update(EffectDescription effectDescription)
        {
            var frame = effectDescription.ItemPosition.Frame;
            var length = effectDescription.ItemDuration.Frame;
            var fps = effectDescription.FPS;

            return new DrawDescription(
                effectDescription.DrawDescription,
                draw: new System.Numerics.Vector3(
                    effectDescription.DrawDescription.Draw.X + item.IntValue * 100,
                    effectDescription.DrawDescription.Draw.Y,
                    effectDescription.DrawDescription.Draw.Z));
        }
        public void ClearInput()
        {
            input = null;
        }
        public void SetInput(ID2D1Image input)
        {
            this.input = input;
        }

        public void Dispose()
        {

        }
    }
}
