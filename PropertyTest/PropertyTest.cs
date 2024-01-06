using PropertyTest.CustomProperty;
using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Effects;

namespace PropertyTest
{
    [VideoEffect("カスタムプロパティテスト", new[] { "テスト" }, new string[] { })]
    internal class PropertyTest : VideoEffectBase
    {
        public override string Label => "カスタムプロパティテスト";

        
        [Display(GroupName = "カスタムプロパティテスト", Name = "カスタムコントロール", Description = "カスタムコントロール")]
        [IncreaseDecreaseButton]
        public int IntValue { get => intValue; set => Set(ref intValue, value); }
        int intValue = 0;

        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return Enumerable.Empty<string>();
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new PropertyTestProcessor(this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => Enumerable.Empty<IAnimatable>();
    }
}
