using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public class SupportPieRadarChartBase : SupportBaseChart
    {
        public static readonly BindableProperty RotateEnabledProperty = BindableProperty.Create("RotateEnabled", typeof(bool?), typeof(SupportPieRadarChartBase), null);
        public bool? RotateEnabled
        {
            get => (bool?)GetValue(RotateEnabledProperty);
            set => SetValue(RotateEnabledProperty, value);
        }

        public static readonly BindableProperty RotationAngleProperty = BindableProperty.Create("RotationAngle", typeof(float?), typeof(SupportPieRadarChartBase), null);
        public float? RotationAngle
        {
            get => (float?)GetValue(RotationAngleProperty);
            set => SetValue(RotationAngleProperty, value);
        }

        public static readonly BindableProperty RawRotationAngleProperty = BindableProperty.Create("RawRotationAngle", typeof(float?), typeof(SupportPieRadarChartBase), null);
        public float? RawRotationAngle
        {
            get => (float?)GetValue(RawRotationAngleProperty);
            set => SetValue(RawRotationAngleProperty, value);
        }

        public SupportPieRadarChartBase()
        {
        }
    }
}