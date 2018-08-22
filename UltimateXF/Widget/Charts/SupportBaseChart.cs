using System;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportBaseChart : View
    {
        public static readonly BindableProperty XAxisProperty = BindableProperty.Create("XAxis", typeof(XAxisConfig), typeof(SupportBaseChart), new XAxisConfig());
        public XAxisConfig XAxis
        {
            get => (XAxisConfig)GetValue(XAxisProperty);
            set => SetValue(XAxisProperty, value);
        }

        public static readonly BindableProperty DescriptionChartProperty = BindableProperty.Create("DescriptionChart", typeof(ChartDescription), typeof(SupportBaseChart), new ChartDescription());
        public ChartDescription DescriptionChart
        {
            get => (ChartDescription)GetValue(DescriptionChartProperty);
            set => SetValue(DescriptionChartProperty, value);
        }

        public static readonly BindableProperty LogEnabledProperty = BindableProperty.Create("LogEnabled", typeof(bool?), typeof(SupportBaseChart), null);
        public bool? LogEnabled
        {
            get => (bool?)GetValue(LogEnabledProperty);
            set => SetValue(LogEnabledProperty, value);
        }
       
        public static readonly BindableProperty HighLightPerTapEnabledProperty = BindableProperty.Create("HighLightPerTapEnabled", typeof(bool?), typeof(SupportBaseChart), null);
        public bool? HighLightPerTapEnabled
        {
            get => (bool?)GetValue(HighLightPerTapEnabledProperty);
            set => SetValue(HighLightPerTapEnabledProperty, value);
        }

        public static readonly BindableProperty DragDecelerationEnabledProperty = BindableProperty.Create("DragDecelerationEnabled", typeof(bool?), typeof(SupportBaseChart), null);
        public bool? DragDecelerationEnabled
        {
            get => (bool?)GetValue(DragDecelerationEnabledProperty);
            set => SetValue(DragDecelerationEnabledProperty, value);
        }

        public static readonly BindableProperty DragDecelerationFrictionCoefProperty = BindableProperty.Create("DragDecelerationFrictionCoef", typeof(float?), typeof(SupportBaseChart), null);
        public float? DragDecelerationFrictionCoef
        {
            get => (float?)GetValue(DragDecelerationFrictionCoefProperty);
            set => SetValue(DragDecelerationFrictionCoefProperty, value);
        }

        public static readonly BindableProperty ExtraTopOffsetProperty = BindableProperty.Create("ExtraTopOffset", typeof(float?), typeof(SupportBaseChart), null);
        public float? ExtraTopOffset
        {
            get => (float?)GetValue(ExtraTopOffsetProperty);
            set => SetValue(ExtraTopOffsetProperty, value);
        }

        public static readonly BindableProperty ExtraRightOffsetProperty = BindableProperty.Create("ExtraRightOffset", typeof(float?), typeof(SupportBaseChart), null);
        public float? ExtraRightOffset
        {
            get => (float?)GetValue(ExtraRightOffsetProperty);
            set => SetValue(ExtraRightOffsetProperty, value);
        }

        public static readonly BindableProperty ExtraBottomOffsetProperty = BindableProperty.Create("ExtraBottomOffset", typeof(float?), typeof(SupportBaseChart), null);
        public float? ExtraBottomOffset
        {
            get => (float?)GetValue(ExtraBottomOffsetProperty);
            set => SetValue(ExtraBottomOffsetProperty, value);
        }

        public static readonly BindableProperty ExtraLeftOffsetProperty = BindableProperty.Create("ExtraLeftOffset", typeof(float?), typeof(SupportBaseChart), null);
        public float? ExtraLeftOffset
        {
            get => (float?)GetValue(ExtraLeftOffsetProperty);
            set => SetValue(ExtraLeftOffsetProperty, value);
        }

        public static readonly BindableProperty MaxHighlightDistanceProperty = BindableProperty.Create("MaxHighlightDistance", typeof(float?), typeof(SupportBaseChart), null);
        public float? MaxHighlightDistance
        {
            get => (float?)GetValue(MaxHighlightDistanceProperty);
            set => SetValue(MaxHighlightDistanceProperty, value);
        }

        public static readonly BindableProperty AnimationXProperty = BindableProperty.Create("AnimationX", typeof(AnimatorXF), typeof(SupportBaseChart), null);
        public AnimatorXF AnimationX
        {
            get => (AnimatorXF)GetValue(AnimationXProperty);
            set => SetValue(AnimationXProperty, value);
        }

        public static readonly BindableProperty AnimationYProperty = BindableProperty.Create("AnimationY", typeof(AnimatorXF), typeof(SupportBaseChart), null);
        public AnimatorXF AnimationY
        {
            get => (AnimatorXF)GetValue(AnimationYProperty);
            set => SetValue(AnimationYProperty, value);
        }
    }
}