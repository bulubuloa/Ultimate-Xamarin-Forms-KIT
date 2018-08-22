using System;
using UltimateXF.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(iFontExtend))]
namespace UltimateXF.Droid
{
    public class iFontExtend : IFont
    {
        public string IF_GetDefaultFontFamily()
        {
            return "";
        }
    }
}