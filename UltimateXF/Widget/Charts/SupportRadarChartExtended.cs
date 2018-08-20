using System;
using UltimateXF.Widget.Charts.Models.Component;
using UltimateXF.Widget.Charts.Models.RadarChart;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportRadarChartExtended : SupportPieRadarChartBase
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(RadarChartData), typeof(SupportRadarChartExtended), null);
        public RadarChartData ChartData
        {
            get => (RadarChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public static readonly BindableProperty WebLineWidthProperty = BindableProperty.Create("WebLineWidth", typeof(float?), typeof(SupportRadarChartExtended), null);
        public float? WebLineWidth
        {
            get => (float?)GetValue(WebLineWidthProperty);
            set => SetValue(WebLineWidthProperty, value);
        }

        public static readonly BindableProperty InnerWebLineWidthProperty = BindableProperty.Create("InnerWebLineWidth", typeof(float?), typeof(SupportRadarChartExtended), null);
        public float? InnerWebLineWidth
        {
            get => (float?)GetValue(InnerWebLineWidthProperty);
            set => SetValue(InnerWebLineWidthProperty, value);
        }

        public static readonly BindableProperty WebColorProperty = BindableProperty.Create("WebColor", typeof(Color?), typeof(SupportRadarChartExtended), null);
        public Color? WebColor
        {
            get => (Color?)GetValue(WebColorProperty);
            set => SetValue(WebColorProperty, value);
        }

        public static readonly BindableProperty WebColorInnerProperty = BindableProperty.Create("WebColorInner", typeof(Color?), typeof(SupportRadarChartExtended), null);
        public Color? WebColorInner
        {
            get => (Color?)GetValue(WebColorInnerProperty);
            set => SetValue(WebColorInnerProperty, value);
        }

        public static readonly BindableProperty WebAlphaProperty = BindableProperty.Create("WebAlpha", typeof(int?), typeof(SupportRadarChartExtended), null);
        public int? WebAlpha
        {
            get => (int?)GetValue(WebAlphaProperty);
            set => SetValue(WebAlphaProperty, value);
        }
       
        public static readonly BindableProperty DrawWebProperty = BindableProperty.Create("DrawWeb", typeof(bool?), typeof(SupportRadarChartExtended), null);
        public bool? DrawWeb
        {
            get => (bool?)GetValue(DrawWebProperty);
            set => SetValue(DrawWebProperty, value);
        }

        public static readonly BindableProperty SkipWebLineCountProperty = BindableProperty.Create("SkipWebLineCount", typeof(int?), typeof(SupportRadarChartExtended), null);
        public int? SkipWebLineCount
        {
            get => (int?)GetValue(SkipWebLineCountProperty);
            set => SetValue(SkipWebLineCountProperty, value);
        }

        //private YAxis mYAxis;
        //protected YAxisRendererRadarChart mYAxisRenderer;
        //protected XAxisRendererRadarChart mXAxisRenderer;

        public SupportRadarChartExtended()
        {
        }
    }
}