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

        public SupportBarLineChartBase()
        {
        }

        protected int MaxVisibleCount;
        protected bool ;
        protected bool PinchZoomEnabled;
        protected bool DoubleTapToZoomEnabled;
        protected bool HighlightPerDragEnabled;
        private bool DragXEnabled;
        private bool DragYEnabled;
        private bool ScaleXEnabled;
        private bool ScaleYEnabled;
        protected bool DrawGridBackground;
        protected bool DrawBorders;
        protected bool ClipValuesToContent;

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
    }
}