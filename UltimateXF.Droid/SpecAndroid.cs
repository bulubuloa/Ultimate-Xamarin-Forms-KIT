using System;
namespace UltimateXF.Droid
{
    public class SpecAndroid
    {
        static object Lock = new object();
        public static System.Collections.Hashtable CACHE = new System.Collections.Hashtable();

        public static Typeface CreateTypeface(Context context, string fontName)
        {
            lock (Lock)
            {
                try
                {
                    if (!CACHE.ContainsKey(fontName))
                    {
                        Typeface typeface;
                        typeface = Typeface.CreateFromAsset(context.Assets, fontName);
                        CACHE.Add(fontName, typeface);
                    }
                    return CACHE[fontName] as Typeface;
                }
                catch (Exception ex)
                {
                    return Typeface.Default;
                }
            }
        }
    }
}