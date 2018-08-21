using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;
using UltimateXF.Widget.Charts.Models.PieChart;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportPieChartExtended : SupportPieRadarChartBase
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(PieChartData), typeof(SupportPieChartExtended), null);
        public PieChartData ChartData
        {
            get => (PieChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public static readonly BindableProperty DrawEntryLabelsProperty = BindableProperty.Create("DrawEntryLabels", typeof(bool?), typeof(SupportPieChartExtended), null);
        public bool? DrawEntryLabels
        {
            get => (bool?)GetValue(DrawEntryLabelsProperty);
            set => SetValue(DrawEntryLabelsProperty, value);
        }

        public static readonly BindableProperty DrawHoleProperty = BindableProperty.Create("DrawHole", typeof(bool?), typeof(SupportPieChartExtended), null);
        public bool? DrawHole
        {
            get => (bool?)GetValue(DrawHoleProperty);
            set => SetValue(DrawHoleProperty, value);
        }

        public static readonly BindableProperty DrawSlicesUnderHoleProperty = BindableProperty.Create("DrawSlicesUnderHole", typeof(bool?), typeof(SupportPieChartExtended), null);
        public bool? DrawSlicesUnderHole
        {
            get => (bool?)GetValue(DrawSlicesUnderHoleProperty);
            set => SetValue(DrawSlicesUnderHoleProperty, value);
        }

        public static readonly BindableProperty UsePercentValuesProperty = BindableProperty.Create("UsePercentValues", typeof(bool?), typeof(SupportPieChartExtended), null);
        public bool? UsePercentValues
        {
            get => (bool?)GetValue(UsePercentValuesProperty);
            set => SetValue(UsePercentValuesProperty, value);
        }

        public static readonly BindableProperty DrawRoundedSlicesProperty = BindableProperty.Create("DrawRoundedSlices", typeof(bool?), typeof(SupportPieChartExtended), null);
        public bool? DrawRoundedSlices
        {
            get => (bool?)GetValue(DrawRoundedSlicesProperty);
            set => SetValue(DrawRoundedSlicesProperty, value);
        }

        public static readonly BindableProperty CenterTextProperty = BindableProperty.Create("CenterText", typeof(string), typeof(SupportPieChartExtended), "");
        public string CenterText
        {
            get => (string)GetValue(CenterTextProperty);
            set => SetValue(CenterTextProperty, value);
        }

        public static readonly BindableProperty HoleRadiusPercentProperty = BindableProperty.Create("HoleRadiusPercent", typeof(float?), typeof(SupportPieChartExtended), null);
        public float? HoleRadiusPercent
        {
            get => (float?)GetValue(HoleRadiusPercentProperty);
            set => SetValue(HoleRadiusPercentProperty, value);
        }

        public static readonly BindableProperty TransparentCircleRadiusPercentProperty = BindableProperty.Create("TransparentCircleRadiusPercent", typeof(float?), typeof(SupportPieChartExtended), null);
        public float? TransparentCircleRadiusPercent
        {
            get => (float?)GetValue(TransparentCircleRadiusPercentProperty);
            set => SetValue(TransparentCircleRadiusPercentProperty, value);
        }

        public static readonly BindableProperty CenterTextRadiusPercentProperty = BindableProperty.Create("CenterTextRadiusPercent", typeof(float?), typeof(SupportPieChartExtended), null);
        public float? CenterTextRadiusPercent
        {
            get => (float?)GetValue(CenterTextRadiusPercentProperty);
            set => SetValue(CenterTextRadiusPercentProperty, value);
        }

        public static readonly BindableProperty MaxAngleProperty = BindableProperty.Create("MaxAngle", typeof(float?), typeof(SupportPieChartExtended), null);
        public float? MaxAngle
        {
            get => (float?)GetValue(MaxAngleProperty);
            set => SetValue(MaxAngleProperty, value);
        }

        public static readonly BindableProperty DrawCenterTextProperty = BindableProperty.Create("DrawCenterText", typeof(bool?), typeof(SupportPieChartExtended), null);
        public bool? DrawCenterText
        {
            get => (bool?)GetValue(DrawCenterTextProperty);
            set => SetValue(DrawCenterTextProperty, value);
        }

        public static readonly BindableProperty AbsoluteAnglesProperty = BindableProperty.Create("AbsoluteAngles", typeof(List<float>), typeof(SupportPieChartExtended), null);
        public List<float> AbsoluteAngles
        {
            get => (List<float>)GetValue(AbsoluteAnglesProperty);
            set => SetValue(AbsoluteAnglesProperty, value);
        }

        public static readonly BindableProperty DrawAnglesProperty = BindableProperty.Create("DrawAngles", typeof(List<float>), typeof(SupportPieChartExtended), null);
        public List<float> DrawAngles
        {
            get => (List<float>)GetValue(DrawAnglesProperty);
            set => SetValue(DrawAnglesProperty, value);
        }

        //private RectF mCircleBox = new RectF();
        //private MPPointF mCenterTextOffset = MPPointF.getInstance(0, 0);

        public SupportPieChartExtended()
        {
            XAxis = null;
        }
    }
}
