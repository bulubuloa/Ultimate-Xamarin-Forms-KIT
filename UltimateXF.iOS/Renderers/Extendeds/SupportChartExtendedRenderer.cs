using System;
using System.ComponentModel;
using iOSCharts;
using UltimateXF.iOS.Renderers.Exporters;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms.Platform.iOS;

namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportChartExtendedRenderer<TSupportView, TOriginalChart> : ViewRenderer<TSupportView,TOriginalChart> 
        where TSupportView : SupportBaseChart where TOriginalChart : ChartViewBase
    {
        protected TSupportView SupportChartView;
        protected TOriginalChart OriginalChartView;
        protected ExtendedChartExport Export;

        public SupportChartExtendedRenderer()
        {
            Export = new ExtendedChartExport();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TSupportView> e)
        {
            base.OnElementChanged(e);
            if(e.NewElement!=null)
            {
                if(e.NewElement is TSupportView)
                {
                    SupportChartView = e.NewElement as TSupportView;
                    OnInitializeOriginalChart();
                    OnInitializeOriginalChartSettings();
                    OnInitializeChartData();
                    OnSetNativeControl();
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        protected virtual void OnInitializeOriginalChart()
        {
            OriginalChartView = (TOriginalChart)Activator.CreateInstance(typeof(TOriginalChart));
            OriginalChartView.Frame = this.Frame;
        }

        private ChartEasingOption ConvertAnimationType(EasingOptionXF easingOptionXF)
        {
            switch (easingOptionXF)
            {
                case EasingOptionXF.Linear:
                    return ChartEasingOption.Linear;
                case EasingOptionXF.EaseInQuad:
                    return ChartEasingOption.EaseInQuad;
                case EasingOptionXF.EaseOutQuad:
                    return ChartEasingOption.EaseOutQuad;
                case EasingOptionXF.EaseInOutQuad:
                    return ChartEasingOption.EaseInOutQuad;
                case EasingOptionXF.EaseInCubic:
                    return ChartEasingOption.EaseInCubic;
                case EasingOptionXF.EaseOutCubic:
                    return ChartEasingOption.EaseOutCubic;
                case EasingOptionXF.EaseInOutCubic:
                    return ChartEasingOption.EaseInOutCubic;
                case EasingOptionXF.EaseInQuart:
                    return ChartEasingOption.EaseInQuart;
                case EasingOptionXF.EaseOutQuart:
                    return ChartEasingOption.EaseOutQuart;
                case EasingOptionXF.EaseInOutQuart:
                    return ChartEasingOption.EaseInOutQuart;
                case EasingOptionXF.EaseInSine:
                    return ChartEasingOption.EaseInSine;
                case EasingOptionXF.EaseOutSine:
                    return ChartEasingOption.EaseOutSine;
                case EasingOptionXF.EaseInOutSine:
                    return ChartEasingOption.EaseInOutSine;
                case EasingOptionXF.EaseInExpo:
                    return ChartEasingOption.EaseInExpo;
                case EasingOptionXF.EaseOutExpo:
                    return ChartEasingOption.EaseOutExpo;
                case EasingOptionXF.EaseInOutExpo:
                    return ChartEasingOption.EaseInOutExpo;
                case EasingOptionXF.EaseInCirc:
                    return ChartEasingOption.EaseInCirc;
                case EasingOptionXF.EaseOutCirc:
                    return ChartEasingOption.EaseOutCirc;
                case EasingOptionXF.EaseInOutCirc:
                    return ChartEasingOption.EaseInOutCirc;
                case EasingOptionXF.EaseInElastic:
                    return ChartEasingOption.EaseInElastic;
                case EasingOptionXF.EaseOutElastic:
                    return ChartEasingOption.EaseOutElastic;
                case EasingOptionXF.EaseInOutElastic:
                    return ChartEasingOption.EaseInOutElastic;
                case EasingOptionXF.EaseInBack:
                    return ChartEasingOption.EaseInBack;
                case EasingOptionXF.EaseOutBack:
                    return ChartEasingOption.EaseOutBack;
                case EasingOptionXF.EaseInOutBack:
                    return ChartEasingOption.EaseInOutBack;
                case EasingOptionXF.EaseInBounce:
                    return ChartEasingOption.EaseInBounce;
                case EasingOptionXF.EaseOutBounce:
                    return ChartEasingOption.EaseOutBounce;
                default:
                    return ChartEasingOption.EaseInOutBounce;
            }
        }

        protected virtual void OnInitializeOriginalChartSettings()
        {
            if (SupportChartView != null && OriginalChartView != null)
            {
                /*
                 * Properties could not set
                 * LogEnabled
                 * HighlightPerDragEnabled
                 */
                if (SupportChartView.HighLightPerTapEnabled.HasValue)
                    OriginalChartView.HighlightPerTapEnabled = SupportChartView.HighLightPerTapEnabled.Value;
                
                if (SupportChartView.DragDecelerationEnabled.HasValue)
                    OriginalChartView.DragDecelerationEnabled = SupportChartView.DragDecelerationEnabled.Value;
                
                if (SupportChartView.DragDecelerationFrictionCoef.HasValue)
                    OriginalChartView.DragDecelerationFrictionCoef = SupportChartView.DragDecelerationFrictionCoef.Value;

                if (SupportChartView.ExtraTopOffset.HasValue)
                    OriginalChartView.ExtraTopOffset = SupportChartView.ExtraTopOffset.Value;

                if (SupportChartView.ExtraLeftOffset.HasValue)
                    OriginalChartView.ExtraLeftOffset = SupportChartView.ExtraLeftOffset.Value;

                if (SupportChartView.ExtraRightOffset.HasValue)
                    OriginalChartView.ExtraRightOffset = SupportChartView.ExtraRightOffset.Value;

                if (SupportChartView.ExtraBottomOffset.HasValue)
                    OriginalChartView.ExtraBottomOffset = SupportChartView.ExtraBottomOffset.Value;

                if (SupportChartView.MaxHighlightDistance.HasValue)
                    OriginalChartView.MaxHighlightDistance = SupportChartView.MaxHighlightDistance.Value;

                if(SupportChartView.DescriptionChart!=null)
                {
                    OriginalChartView.ChartDescription.Text = SupportChartView.DescriptionChart.Text;
                }

                if (SupportChartView.AnimationX != null)
                {
                    var animator = SupportChartView.AnimationX;
                    if (animator.Duration.HasValue)
                    {
                        var duration = ((double)animator.Duration.Value) / 1000d;
                        if(animator.EasingType.HasValue)
                        {
                            OriginalChartView.AnimateWithXAxisDuration(duration, ConvertAnimationType(animator.EasingType.Value)); 
                        }
                        else
                        {
                            OriginalChartView.AnimateWithXAxisDuration(duration);
                        }
                    }
                }

                if (SupportChartView.AnimationY != null)
                {
                    var animator = SupportChartView.AnimationY;
                    if (animator.Duration.HasValue)
                    {
                        var duration = ((double)animator.Duration.Value) / 1000d;
                        if (animator.EasingType.HasValue)
                        {
                            OriginalChartView.AnimateWithYAxisDuration(duration, ConvertAnimationType(animator.EasingType.Value));
                        }
                        else
                        {
                            OriginalChartView.AnimateWithYAxisDuration(duration);
                        }
                    }
                }

                if (SupportChartView.XAxis != null && OriginalChartView.XAxis !=null)
                {
                    var SupportXAxis = SupportChartView.XAxis;
                    var OriginalAxis = OriginalChartView.XAxis;

                    OriginalAxis.SetupConfigBase(SupportXAxis);
                    OriginalAxis.SetupAxisConfigBase(SupportXAxis);
                    OriginalAxis.SetupXAxisConfig(SupportXAxis);

                    if (SupportChartView.XAxis.AxisValueFormatter == null)
                    {
                        //OriginalChartView.XAxis.ValueFormatter = new FullTitleFormatter();
                    }
                    else
                    {
                        OriginalChartView.XAxis.ValueFormatter = new AxisValueFormatterExport(SupportChartView.XAxis.AxisValueFormatter);
                    }
                }
            }
        }
        protected virtual void OnSetNativeControl()
        {
            if (OriginalChartView != null)
                SetNativeControl(OriginalChartView);
        }

        protected virtual void OnInitializeChartData()
        {
            
        }
    }
}