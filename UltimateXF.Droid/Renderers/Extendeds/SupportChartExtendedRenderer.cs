using System;
using System.ComponentModel;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Animation;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers.Exporters;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms.Platform.Android;

namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportChartExtendedRenderer<TSupportView, TOriginalChart> : ViewRenderer<TSupportView, TOriginalChart>
        where TSupportView : SupportBaseChart 
        where TOriginalChart : Chart
    {

        protected TSupportView SupportChartView;
        protected TOriginalChart OriginalChartView;
        protected ExtendedChartExport Export;

        public SupportChartExtendedRenderer(Context context) : base(context)
        {
            Export = new ExtendedChartExport();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TSupportView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (e.NewElement is TSupportView)
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
            OriginalChartView = (TOriginalChart)Activator.CreateInstance(typeof(TOriginalChart),Context);
            OriginalChartView.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
        }

        private Easing.EasingOption ConvertAnimationType(EasingOptionXF easingOptionXF)
        {
            switch (easingOptionXF)
            {
                case EasingOptionXF.Linear:
                    return Easing.EasingOption.Linear;
                case EasingOptionXF.EaseInQuad:
                    return Easing.EasingOption.EaseInQuad;
                case EasingOptionXF.EaseOutQuad:
                    return Easing.EasingOption.EaseOutQuad;
                case EasingOptionXF.EaseInOutQuad:
                    return Easing.EasingOption.EaseInOutQuad;
                case EasingOptionXF.EaseInCubic:
                    return Easing.EasingOption.EaseInCubic;
                case EasingOptionXF.EaseOutCubic:
                    return Easing.EasingOption.EaseOutCubic;
                case EasingOptionXF.EaseInOutCubic:
                    return Easing.EasingOption.EaseInOutCubic;
                case EasingOptionXF.EaseInQuart:
                    return Easing.EasingOption.EaseInQuart;
                case EasingOptionXF.EaseOutQuart:
                    return Easing.EasingOption.EaseOutQuart;
                case EasingOptionXF.EaseInOutQuart:
                    return Easing.EasingOption.EaseInOutQuart;
                case EasingOptionXF.EaseInSine:
                    return Easing.EasingOption.EaseInSine;
                case EasingOptionXF.EaseOutSine:
                    return Easing.EasingOption.EaseOutSine;
                case EasingOptionXF.EaseInOutSine:
                    return Easing.EasingOption.EaseInOutSine;
                case EasingOptionXF.EaseInExpo:
                    return Easing.EasingOption.EaseInExpo;
                case EasingOptionXF.EaseOutExpo:
                    return Easing.EasingOption.EaseOutExpo;
                case EasingOptionXF.EaseInOutExpo:
                    return Easing.EasingOption.EaseInOutExpo;
                case EasingOptionXF.EaseInCirc:
                    return Easing.EasingOption.EaseInCirc;
                case EasingOptionXF.EaseOutCirc:
                    return Easing.EasingOption.EaseOutCirc;
                case EasingOptionXF.EaseInOutCirc:
                    return Easing.EasingOption.EaseInOutCirc;
                case EasingOptionXF.EaseInElastic:
                    return Easing.EasingOption.EaseInElastic;
                case EasingOptionXF.EaseOutElastic:
                    return Easing.EasingOption.EaseOutElastic;
                case EasingOptionXF.EaseInOutElastic:
                    return Easing.EasingOption.EaseInOutElastic;
                case EasingOptionXF.EaseInBack:
                    return Easing.EasingOption.EaseInBack;
                case EasingOptionXF.EaseOutBack:
                    return Easing.EasingOption.EaseOutBack;
                case EasingOptionXF.EaseInOutBack:
                    return Easing.EasingOption.EaseInOutBack;
                case EasingOptionXF.EaseInBounce:
                    return Easing.EasingOption.EaseInBounce;
                case EasingOptionXF.EaseOutBounce:
                    return Easing.EasingOption.EaseOutBounce;
                default:
                    return Easing.EasingOption.EaseInOutBounce;
            }
        }

        protected virtual void OnInitializeOriginalChartSettings()
        {
            if (SupportChartView != null && OriginalChartView != null)
            {
                /*
                 * Properties could not set
                 */
                if (SupportChartView.LogEnabled.HasValue)
                    OriginalChartView.LogEnabled = SupportChartView.LogEnabled.Value;
                
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

                if (SupportChartView.DescriptionChart != null)
                {
                    OriginalChartView.Description.Text = SupportChartView.DescriptionChart.Text;
                }

                if (SupportChartView.AnimationX != null)
                {
                    var animator = SupportChartView.AnimationX;
                    if(animator.Duration.HasValue)
                    {
                        if (animator.EasingType.HasValue)
                        {
                            OriginalChartView.AnimateX(animator.Duration.Value, ConvertAnimationType(animator.EasingType.Value));
                        }
                        else
                        {
                            OriginalChartView.AnimateX(animator.Duration.Value);
                        }
                    }
                }

                if (SupportChartView.AnimationY != null)
                {
                    var animator = SupportChartView.AnimationY;
                    if (animator.Duration.HasValue)
                    {
                        if (animator.EasingType.HasValue)
                        {
                            OriginalChartView.AnimateY(animator.Duration.Value, ConvertAnimationType(animator.EasingType.Value));
                        }
                        else
                        {
                            OriginalChartView.AnimateY(animator.Duration.Value);
                        }
                    }
                }

                if (SupportChartView.XAxis != null && OriginalChartView.XAxis!=null)
                {
                    var SupportXAxis = SupportChartView.XAxis;
                    var OriginalAxis = OriginalChartView.XAxis;

                    OriginalAxis.SetupConfigBase(SupportXAxis);
                    OriginalAxis.SetupAxisConfigBase(SupportXAxis);
                    OriginalAxis.SetupXAxisConfig(SupportXAxis);

                    if(SupportChartView.XAxis.AxisValueFormatter == null)
                    {
                        //OriginalChartView.XAxis.ValueFormatter = new FullTitleFormatter();
                    }
                    else
                    {
                        OriginalChartView.XAxis.ValueFormatter = new AxisValueFormatterExport(SupportChartView.XAxis.AxisValueFormatter);
                    }
                }

                if(SupportChartView.Legend!=null)
                {
                    var SupportLegend = SupportChartView.Legend;
                    var OriginalLegend = OriginalChartView.Legend;

                    if(SupportLegend.Enabled.HasValue)
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

                    if (SupportLegend.TextSize.HasValue)
                    {
                        OriginalLegend.TextSize = SupportLegend.TextSize.Value;
                    }
                    
                    if (!string.IsNullOrEmpty(SupportLegend.FontFamily))
                    {
                        OriginalLegend.Typeface = SpecAndroid.CreateTypeface(UltimateXFSettup.Context, SupportLegend.FontFamily);
                    }

                    if (SupportLegend.TextColor.HasValue)
                    {
                        OriginalLegend.TextColor = SupportLegend.TextColor.Value.ToAndroid();
                    }

                    if (SupportLegend.LegendHorizontalAlignment.HasValue)
                    {
                        switch (SupportLegend.LegendHorizontalAlignment.Value)
                        {
                            case Widget.Charts.Models.Legend.LegendHorizontalAlignment.LEFT:
                                OriginalLegend.HorizontalAlignment = MikePhil.Charting.Components.Legend.LegendHorizontalAlignment.Left;
                                break;
                            case Widget.Charts.Models.Legend.LegendHorizontalAlignment.CENTER:
                                OriginalLegend.HorizontalAlignment = MikePhil.Charting.Components.Legend.LegendHorizontalAlignment.Center;
                                break;
                            case Widget.Charts.Models.Legend.LegendHorizontalAlignment.RIGHT:
                                OriginalLegend.HorizontalAlignment = MikePhil.Charting.Components.Legend.LegendHorizontalAlignment.Right;
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
                                OriginalLegend.VerticalAlignment = MikePhil.Charting.Components.Legend.LegendVerticalAlignment.Top;
                                break;
                            case Widget.Charts.Models.Legend.LegendVerticalAlignment.CENTER:
                                OriginalLegend.VerticalAlignment = MikePhil.Charting.Components.Legend.LegendVerticalAlignment.Center;
                                break;
                            case Widget.Charts.Models.Legend.LegendVerticalAlignment.BOTTOM:
                                OriginalLegend.VerticalAlignment = MikePhil.Charting.Components.Legend.LegendVerticalAlignment.Bottom;
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
                                OriginalLegend.Orientation = MikePhil.Charting.Components.Legend.LegendOrientation.Horizontal;
                                break;
                            case Widget.Charts.Models.Legend.LegendOrientation.VERTICAL:
                                OriginalLegend.Orientation = MikePhil.Charting.Components.Legend.LegendOrientation.Vertical;
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
                                OriginalLegend.Direction = MikePhil.Charting.Components.Legend.LegendDirection.LeftToRight;
                                break;
                            case Widget.Charts.Models.Legend.LegendDirection.RIGHT_TO_LEFT:
                                OriginalLegend.Direction = MikePhil.Charting.Components.Legend.LegendDirection.RightToLeft;
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
                                OriginalLegend.Form = MikePhil.Charting.Components.Legend.LegendForm.None;
                                break;
                            case Widget.Charts.Models.Legend.LegendForm.EMPTY:
                                OriginalLegend.Form = MikePhil.Charting.Components.Legend.LegendForm.Empty;
                                break;
                            case Widget.Charts.Models.Legend.LegendForm.DEFAULT:
                                OriginalLegend.Form = MikePhil.Charting.Components.Legend.LegendForm.Default;
                                break;
                            case Widget.Charts.Models.Legend.LegendForm.SQUARE:
                                OriginalLegend.Form = MikePhil.Charting.Components.Legend.LegendForm.Square;
                                break;
                            case Widget.Charts.Models.Legend.LegendForm.CIRCLE:
                                OriginalLegend.Form = MikePhil.Charting.Components.Legend.LegendForm.Circle;
                                break;
                            case Widget.Charts.Models.Legend.LegendForm.LINE:
                                OriginalLegend.Form = MikePhil.Charting.Components.Legend.LegendForm.Line;
                                break;
                            default:
                                break;
                        }
                    }

                    if (SupportLegend.DrawInsideEnabled.HasValue)
                    {
                        OriginalLegend.SetDrawInside(SupportLegend.DrawInsideEnabled.Value);
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
                        OriginalLegend.MNeededWidth = (SupportLegend.NeededWidth.Value);
                    }

                    if (SupportLegend.NeededHeight.HasValue)
                    {
                        OriginalLegend.MNeededHeight = (SupportLegend.NeededHeight.Value);
                    }

                    if (SupportLegend.TextHeightMax.HasValue)
                    {
                        OriginalLegend.MTextHeightMax = (SupportLegend.TextHeightMax.Value);
                    }

                    if (SupportLegend.TextWidthMax.HasValue)
                    {
                        OriginalLegend.MTextWidthMax = (SupportLegend.TextWidthMax.Value);
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