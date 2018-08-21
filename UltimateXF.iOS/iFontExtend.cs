using UIKit;
using UltimateXF.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(iFontExtend))]
namespace UltimateXF.iOS
{
    public class iFontExtend : IFont
    {
        public string IF_GetDefaultFontFamily()
        {
            return new UITextField().Font.Name;
        }
    }
}