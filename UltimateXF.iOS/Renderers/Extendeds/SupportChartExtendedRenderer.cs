using System;
using System.ComponentModel;
using iOSCharts;
using UIKit;
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

                if (SupportChartView.Legend != null)
                {
                    var SupportLegend = SupportChartView.Legend;
                    var OriginalLegend = OriginalChartView.Legend;

                    if (SupportLegend.Enabled.HasValue)
                    {
                        OriginalLegend.Enabled = SupportLegend.Enabled.Value;
                    }

                    if (SupportLegend.XOffset.HasValue)
                    {
                        OriginalLegend.XOffset = SupportLegend.XOffset.Value;
                    }

                    if (SupportLegend.YOffset.HasValue)
                    {
                        OriginalLegend.YOffset = SupportLegend.YOffset.Value;
                    }

                    try
                    {
                        if (string.IsNullOrEmpty(SupportLegend.FontFamily))
                        {
                            if (SupportLegend.TextSize.HasValue)
                            {
                                OriginalLegend.Font = UIFont.SystemFontOfSize(SupportLegend.TextSize.Value);
                            }
                        }
                        else
                        {
                            if (SupportLegend.TextSize.HasValue)
                            {
                                OriginalLegend.Font = UIFont.FromName(SupportLegend.FontFamily, SupportLegend.TextSize.Value);
                            }
                            else
                            {
                                OriginalLegend.Font = UIFont.FromName(SupportLegend.FontFamily, OriginalLegend.Font.PointSize);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }


                    if (SupportLegend.TextColor.HasValue)
                    {
                        OriginalLegend.TextColor = SupportLegend.TextColor.Value.ToUIColor();
                    }

                    if (SupportLegend.LegendHorizontalAlignment.HasValue)
                    {
                        switch (SupportLegend.LegendHorizontalAlignment.Value)
                        {
                            case Widget.Charts.Models.Legend.LegendHorizontalAlignment.LEFT:
                                OriginalLegend.HorizontalAlignment = ChartLegendHorizontalAlignment.Left;
                                break;
                            case Widget.Charts.Models.Legend.LegendHorizontalAlignment.CENTER:
                                OriginalLegend.HorizontalAlignment = ChartLegendHorizontalAlignment.Center;
                                break;
                            case Widget.Charts.Models.Legend.LegendHorizontalAlignment.RIGHT:
                                OriginalLegend.HorizontalAlignment = ChartLegendHorizontalAlignment.Right;
                                break;
                            default:
                                break;
                        }
                    }

                    if (SupportLegend.LegendVerticalAlignment.HasValue)
                    {
                        switch (SupportLegend.LegendVerticalAlignment.Value)
                        {
                            case Widget.Charts.Models.Legend.LegendVerticalAlignment.TOP:
                                OriginalLegend.VerticalAlignment = ChartLegendVerticalAlignment.Top;
                                break;
                            case Widget.Charts.Models.Legend.LegendVerticalAlignment.CENTER:
                                OriginalLegend.VerticalAlignment = ChartLegendVerticalAlignment.Center;
                                break;
                            case Widget.Charts.Models.Legend.LegendVerticalAlignment.BOTTOM:
                                OriginalLegend.VerticalAlignment = ChartLegendVerticalAlignment.Bottom;
                                break;
                            default:
                                break;
                        }
                    }

                    if (SupportLegend.LegendOrientation.HasValue)
                    {
                        switch (SupportLegend.LegendOrientation.Value)
                        {
                            case Widget.Charts.Models.Legend.LegendOrientation.HORIZONTAL:
                                OriginalLegend.Orientation = ChartLegendOrientation.Horizontal;
                                break;
                            case Widget.Charts.Models.Legend.LegendOrientation.VERTICAL:
                                OriginalLegend.Orientation = ChartLegendOrientation.Vertical;
                                break;
                            default:
                                break;
                        }
                    }

                    if (SupportLegend.LegendDirection.HasValue)
                    {
                        switch (SupportLegend.LegendDirection.Value)
                        {
                            case Widget.Charts.Models.Legend.LegendDirection.LEFT_TO_RIGHT:
                                OriginalLegend.Direction = ChartLegendDirection.LeftToRight;
                                break;
                            case Widget.Charts.Models.Legend.LegendDirection.RIGHT_TO_LEFT:
                                OriginalLegend.Direction = ChartLegendDirection.RightToLeft;
                                break;
                            default:
                                break;
                        }
                    }

                    if (SupportLegend.LegendForm.HasValue)
                    {
                        switch (SupportLegend.LegendForm.Value)
                        {
                            case Widget.Charts.Models.Legend.LegendForm.NONE:
                                OriginalLegend.Form = ChartLegendForm.None;
                                break;
                            case Widget.Charts.Models.Legend.LegendForm.EMPTY:
                                OriginalLegend.Form = ChartLegendForm.Empty;
                                break;
                            case Widget.Charts.Models.Legend.LegendForm.DEFAULT:
                                OriginalLegend.Form = ChartLegendForm.Default;
                                break;
                            case Widget.Charts.Models.Legend.LegendForm.SQUARE:
                                OriginalLegend.Form = ChartLegendForm.Square;
                                break;
                            case Widget.Charts.Models.Legend.LegendForm.CIRCLE:
                                OriginalLegend.Form = ChartLegendForm.Circle;
                                break;
                            case Widget.Charts.Models.Legend.LegendForm.LINE:
                                OriginalLegend.Form = ChartLegendForm.Line;
                                break;
                            default:
                                break;
                        }
                    }

                    if (SupportLegend.DrawInsideEnabled.HasValue)
                    {
                        OriginalLegend.DrawInside = (SupportLegend.DrawInsideEnabled.Value);
                    }

                    if (SupportLegend.FormSize.HasValue)
                    {
                        OriginalLegend.FormSize = (SupportLegend.FormSize.Value);
                    }

                    if (SupportLegend.FormLineWidth.HasValue)
                    {
                        OriginalLegend.FormLineWidth = (SupportLegend.FormLineWidth.Value);
                    }

                    if (SupportLegend.XEntrySpace.HasValue)
                    {
                        OriginalLegend.XEntrySpace = (SupportLegend.XEntrySpace.Value);
                    }

                    if (SupportLegend.YEntrySpace.HasValue)
                    {
                        OriginalLegend.YEntrySpace = (SupportLegend.YEntrySpace.Value);
                    }

                    if (SupportLegend.FormToTextSpace.HasValue)
                    {
                        OriginalLegend.FormToTextSpace = (SupportLegend.FormToTextSpace.Value);
                    }

                    if (SupportLegend.StackSpace.HasValue)
                    {
                        OriginalLegend.StackSpace = (SupportLegend.StackSpace.Value);
                    }

                    if (SupportLegend.WordWrapEnabled.HasValue)
                    {
                        OriginalLegend.WordWrapEnabled = (SupportLegend.WordWrapEnabled.Value);
                    }

                    if (SupportLegend.MaxSizePercent.HasValue)
                    {
                        OriginalLegend.MaxSizePercent = (SupportLegend.MaxSizePercent.Value);
                    }

                    if (SupportLegend.NeededWidth.HasValue)
                    {
                        OriginalLegend.NeededWidth = (SupportLegend.NeededWidth.Value);
                    }

                    if (SupportLegend.NeededHeight.HasValue)
                    {
                        OriginalLegend.NeededHeight = (SupportLegend.NeededHeight.Value);
                    }

                    if (SupportLegend.TextHeightMax.HasValue)
                    {
                        OriginalLegend.TextHeightMax = (SupportLegend.TextHeightMax.Value);
                    }

                    if (SupportLegend.TextWidthMax.HasValue)
                    {
                        OriginalLegend.TextWidthMax = (SupportLegend.TextWidthMax.Value);
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