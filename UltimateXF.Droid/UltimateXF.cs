using System;
using Android.App;

namespace UltimateXF.Droid
{
    public static class UltimateXF
    {
        public static Activity Context;

        public static void Initialize(Activity activity)
        {
            Context = activity;
        }
    }
}