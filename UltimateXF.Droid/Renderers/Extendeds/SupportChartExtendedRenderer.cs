using System;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models.Component;
using UltimateXF.Widget.Charts.Models.ComponentXF;
using Xamarin.Forms.Platform.Android;

namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportChartExtendedRenderer<TSupportView, TOriginalChart> : ViewRenderer<TSupportView, TOriginalChart>
        where TSupportView : SupportBaseChart where TOriginalChart : Chart
    {

        protected TSupportView SupportChartView;
        protected TOriginalChart OriginalChartView;

        public SupportChartExtendedRenderer(Context context) : base(context)
        {
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

                if (SupportChartView.XAxis != null)
                {
                    var SupportXAxis = SupportChartView.XAxis;
                    var OriginalAxis = OriginalChartView.XAxis;

                    OriginalAxis.SetupConfigBase(SupportXAxis);
                    OriginalAxis.SetupAxisConfigBase(SupportXAxis);
                    OriginalAxis.SetupXAxisConfig(SupportXAxis);
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

        protected virtual void OnSettingsBaseDataSet<TEntry>(IBaseDataSetXF<TEntry> baseDataSetXF, MikePhil.Charting.Data.BaseDataSet originalBaseDataSet) where TEntry : Widget.Charts.Models.BaseEntry
        {
            /*
                 * Properties could not set
                 * IF_GetValueColors
                 * IF_GetGradientColor
                 * IF_GetValueTextSize
                 * IF_GetValueFormatter
                 */
            if (baseDataSetXF.IF_GetColors() != null && baseDataSetXF.IF_GetColors().Count > 0)
            {
                originalBaseDataSet.SetColors(baseDataSetXF.IF_GetColors().Select(obj => obj.ToAndroid().ToArgb()).ToArray());
            }
            //if (baseDataSetXF.IF_GetValueColors() != null && baseDataSetXF.IF_GetValueColors().Count > 0)
            //{
            //    originalBaseDataSet.ValueColors = (baseDataSetXF.IF_GetValueColors().Select(obj => obj.ToUIColor()).ToArray());
            //}
            if (baseDataSetXF.IF_GetHighlightEnabled().HasValue)
            {
                originalBaseDataSet.HighlightEnabled = baseDataSetXF.IF_GetHighlightEnabled().Value;
            }
            if (baseDataSetXF.IF_GetVisible().HasValue)
            {
                originalBaseDataSet.Visible = baseDataSetXF.IF_GetVisible().Value;
            }
            if (baseDataSetXF.IF_GetDrawIcons().HasValue)
            {
                originalBaseDataSet.SetDrawIcons(baseDataSetXF.IF_GetDrawIcons().Value);
            }
            if (baseDataSetXF.IF_GetDrawValues().HasValue)
            {
                originalBaseDataSet.SetDrawValues(baseDataSetXF.IF_GetDrawValues().Value);
            }
        }

        protected virtual void OnSettingsBarLineScatterCandleBubbleDataSet<TEntry>(IBarLineScatterCandleBubbleDataSetXF<TEntry> baseDataSetXF, MikePhil.Charting.Data.BarLineScatterCandleBubbleDataSet originalBaseDataSet) where TEntry : Widget.Charts.Models.BaseEntry
        {
            OnSettingsBaseDataSet(baseDataSetXF, originalBaseDataSet);

            if (baseDataSetXF.IF_GetighLightColor().HasValue)
            {
                originalBaseDataSet.HighLightColor = baseDataSetXF.IF_GetighLightColor().Value.ToAndroid();
            }
        }

        protected virtual void OnSettingsLineScatterCandleRadarDataSet<TEntry>(ILineScatterCandleRadarDataSetXF<TEntry> baseDataSetXF, MikePhil.Charting.Data.LineScatterCandleRadarDataSet originalBaseDataSet) where TEntry : Widget.Charts.Models.BaseEntry
        {
            OnSettingsBarLineScatterCandleBubbleDataSet(baseDataSetXF, originalBaseDataSet);

            if (baseDataSetXF.IF_GetDrawVerticalHighlightIndicator().HasValue)
            {
                originalBaseDataSet.SetDrawVerticalHighlightIndicator(baseDataSetXF.IF_GetDrawVerticalHighlightIndicator().Value);
            }
            if (baseDataSetXF.IF_GetDrawHorizontalHighlightIndicator().HasValue)
            {
                originalBaseDataSet.SetDrawHorizontalHighlightIndicator(baseDataSetXF.IF_GetDrawHorizontalHighlightIndicator().Value);
            }
            if (baseDataSetXF.IF_GetHighlightLineWidth().HasValue)
            {
                originalBaseDataSet.HighlightLineWidth = baseDataSetXF.IF_GetHighlightLineWidth().Value;
            }
        }
    }
}