using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public class SupportBarLineChartBase : SupportBaseChart
    {
        public static readonly BindableProperty AxisLeftProperty = BindableProperty.Create("AxisLeft", typeof(YAxisConfig), typeof(SupportBarLineChartBase), new YAxisConfig());
        public YAxisConfig AxisLeft
        {
            get => (YAxisConfig)GetValue(AxisLeftProperty);
            set => SetValue(AxisLeftProperty, value);
        }

        public static readonly BindableProperty AxisRightProperty = BindableProperty.Create("AxisRight", typeof(YAxisConfig), typeof(SupportBarLineChartBase), new YAxisConfig());
        public YAxisConfig AxisRight
        {
            get => (YAxisConfig)GetValue(AxisRightProperty);
            set => SetValue(AxisRightProperty, value);
        }

        public static readonly BindableProperty AutoScaleMinMaxEnabledProperty = BindableProperty.Create("AutoScaleMinMaxEnabled", typeof(bool?), typeof(SupportBarLineChartBase), null);
        public bool? AutoScaleMinMaxEnabled
        {
            get => (bool?)GetValue(AutoScaleMinMaxEnabledProperty);
            set => SetValue(AutoScaleMinMaxEnabledProperty, value);
        }

        public static readonly BindableProperty PinchZoomEnabledProperty = BindableProperty.Create("PinchZoomEnabled", typeof(bool?), typeof(SupportBarLineChartBase), null);
        public bool? PinchZoomEnabled
        {
            get => (bool?)GetValue(PinchZoomEnabledProperty);
            set => SetValue(PinchZoomEnabledProperty, value);
        }

        public static readonly BindableProperty DoubleTapToZoomEnabledProperty = BindableProperty.Create("DoubleTapToZoomEnabled", typeof(bool?), typeof(SupportBarLineChartBase), null);
        public bool? DoubleTapToZoomEnabled
        {
            get => (bool?)GetValue(DoubleTapToZoomEnabledProperty);
            set => SetValue(DoubleTapToZoomEnabledProperty, value);
        }

        public static readonly BindableProperty HighlightPerDragEnabledProperty = BindableProperty.Create("HighlightPerDragEnabled", typeof(bool?), typeof(SupportBarLineChartBase), null);
        public bool? HighlightPerDragEnabled
        {
            get => (bool?)GetValue(HighlightPerDragEnabledProperty);
            set => SetValue(HighlightPerDragEnabledProperty, value);
        }

        public static readonly BindableProperty DragXEnabledProperty = BindableProperty.Create("DragXEnabled", typeof(bool?), typeof(SupportBarLineChartBase), null);
        public bool? DragXEnabled
        {
            get => (bool?)GetValue(DragXEnabledProperty);
            set => SetValue(DragXEnabledProperty, value);
        }

        public static readonly BindableProperty DragYEnabledProperty = BindableProperty.Create("DragYEnabled", typeof(bool?), typeof(SupportBarLineChartBase), null);
        public bool? DragYEnabled
        {
            get => (bool?)GetValue(DragYEnabledProperty);
            set => SetValue(DragYEnabledProperty, value);
        }

        public static readonly BindableProperty ScaleXEnabledProperty = BindableProperty.Create("ScaleXEnabled", typeof(bool?), typeof(SupportBarLineChartBase), null);
        public bool? ScaleXEnabled
        {
            get => (bool?)GetValue(ScaleXEnabledProperty);
            set => SetValue(ScaleXEnabledProperty, value);
        }

        public static readonly BindableProperty ScaleYEnabledProperty = BindableProperty.Create("ScaleYEnabled", typeof(bool?), typeof(SupportBarLineChartBase), null);
        public bool? ScaleYEnabled
        {
            get => (bool?)GetValue(ScaleYEnabledProperty);
            set => SetValue(ScaleYEnabledProperty, value);
        }

        public static readonly BindableProperty DrawGridBackgroundProperty = BindableProperty.Create("DrawGridBackground", typeof(bool?), typeof(SupportBarLineChartBase), null);
        public bool? DrawGridBackground
        {
            get => (bool?)GetValue(DrawGridBackgroundProperty);
            set => SetValue(DrawGridBackgroundProperty, value);
        }

        public static readonly BindableProperty DrawBordersProperty = BindableProperty.Create("DrawBorders", typeof(bool?), typeof(SupportBarLineChartBase), null);
        public bool? DrawBorders
        {
            get => (bool?)GetValue(DrawBordersProperty);
            set => SetValue(DrawBordersProperty, value);
        }

        public static readonly BindableProperty ClipValuesToContentProperty = BindableProperty.Create("ClipValuesToContent", typeof(bool?), typeof(SupportBarLineChartBase), null);
        public bool? ClipValuesToContent
        {
            get => (bool?)GetValue(ClipValuesToContentProperty);
            set => SetValue(ClipValuesToContentProperty, value);
        }

        public static readonly BindableProperty MaxVisibleCountProperty = BindableProperty.Create("MaxVisibleCount", typeof(int?), typeof(SupportBarLineChartBase), null);
        public int? MaxVisibleCount
        {
            get => (int?)GetValue(MaxVisibleCountProperty);
            set => SetValue(MaxVisibleCountProperty, value);
        }

        public SupportBarLineChartBase()
        {
            AxisRight.PropertyChanged += AxisLeft_PropertyChanged;
        }



        //protected Paint mGridBackgroundPaint;
        //protected Paint mBorderPaint;
        //protected float mMinOffset = 15.f;
        //protected bool mKeepPositionOnRotation = false;
        //protected OnDrawListener mDrawListener;
        //protected YAxisRenderer mAxisRendererLeft;
        //protected YAxisRenderer mAxisRendererRight;
        //protected Transformer mLeftAxisTransformer;
        //protected Transformer mRightAxisTransformer;
        //protected XAxisRenderer mXAxisRenderer;

        void AxisLeft_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(AxisRightProperty.PropertyName);
        }
    }
}