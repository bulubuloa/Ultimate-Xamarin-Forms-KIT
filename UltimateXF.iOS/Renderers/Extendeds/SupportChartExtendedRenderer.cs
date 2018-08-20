using System;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.Component;
using UltimateXF.Widget.Charts.Models.ComponentXF;
using Xamarin.Forms.Platform.iOS;

namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportChartExtendedRenderer<TSupportView, TOriginalChart> : ViewRenderer<TSupportView,TOriginalChart> 
        where TSupportView : SupportBaseChart where TOriginalChart : ChartViewBase
    {
        protected TSupportView SupportChartView;
        protected TOriginalChart OriginalChartView;

        public SupportChartExtendedRenderer()
        {
            
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

                if (SupportChartView.XAxis != null && OriginalChartView.XAxis !=null)
                {
                    var SupportXAxis = SupportChartView.XAxis;
                    var OriginalAxis = OriginalChartView.XAxis;

                    OriginalAxis.SetupConfigBase(SupportXAxis);
                    OriginalAxis.SetupAxisConfigBase(SupportXAxis);
                    OriginalAxis.SetupXAxisConfig(SupportXAxis);
                }

                Console.WriteLine("dkm");
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

        protected virtual void OnSettingsBaseDataSet<TEntry>(IBaseDataSetXF<TEntry> baseDataSetXF, ChartBaseDataSet originalBaseDataSet) where TEntry : BaseEntry
        {
            /*
                 * Properties could not set
                 * IF_GetGradientColor
                 * IF_GetValueTextSize
                 * IF_GetValueFormatter
                 */
            if (baseDataSetXF.IF_GetColors() != null && baseDataSetXF.IF_GetColors().Count>0)
            {
                originalBaseDataSet.SetColors(baseDataSetXF.IF_GetColors().Select(obj => obj.ToUIColor()).ToArray(),1f);
            }
            if (baseDataSetXF.IF_GetValueColors() != null && baseDataSetXF.IF_GetValueColors().Count > 0)
            {
                originalBaseDataSet.ValueColors = (baseDataSetXF.IF_GetValueColors().Select(obj => obj.ToUIColor()).ToArray());
            }
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
                originalBaseDataSet.DrawIconsEnabled = baseDataSetXF.IF_GetDrawIcons().Value ? 1 : 0;
            }
            if (baseDataSetXF.IF_GetDrawValues().HasValue)
            {
                originalBaseDataSet.DrawValuesEnabled = baseDataSetXF.IF_GetDrawValues().Value;
            }
        }

        protected virtual void OnSettingsBarLineScatterCandleBubbleDataSet<TEntry>(IBarLineScatterCandleBubbleDataSetXF<TEntry> baseDataSetXF, BarLineScatterCandleBubbleChartDataSet originalBaseDataSet) where TEntry : BaseEntry
        {
            OnSettingsBaseDataSet(baseDataSetXF,originalBaseDataSet);

            if (baseDataSetXF.IF_GetighLightColor().HasValue)
            {
                originalBaseDataSet.HighlightColor = baseDataSetXF.IF_GetighLightColor().Value.ToUIColor();
            }
        }

        protected virtual void OnSettingsLineScatterCandleRadarDataSet<TEntry>(ILineScatterCandleRadarDataSetXF<TEntry> baseDataSetXF, LineScatterCandleRadarChartDataSet originalBaseDataSet) where TEntry : BaseEntry
        {
            OnSettingsBarLineScatterCandleBubbleDataSet(baseDataSetXF, originalBaseDataSet);

            if (baseDataSetXF.IF_GetDrawVerticalHighlightIndicator().HasValue)
            {
                originalBaseDataSet.DrawVerticalHighlightIndicatorEnabled = baseDataSetXF.IF_GetDrawVerticalHighlightIndicator().Value;
            }
            if (baseDataSetXF.IF_GetDrawHorizontalHighlightIndicator().HasValue)
            {
                originalBaseDataSet.DrawHorizontalHighlightIndicatorEnabled = baseDataSetXF.IF_GetDrawHorizontalHighlightIndicator().Value;
            }
            if (baseDataSetXF.IF_GetHighlightLineWidth().HasValue)
            {
                originalBaseDataSet.HighlightLineWidth = baseDataSetXF.IF_GetHighlightLineWidth().Value;
            }
        }

        protected virtual void OnSettingsLineRadarDataSet<TEntry>(ILineRadarDataSetXF<TEntry> baseDataSetXF, LineRadarChartDataSet originalBaseDataSet) where TEntry : BaseEntry
        {
            OnSettingsLineScatterCandleRadarDataSet(baseDataSetXF, originalBaseDataSet);

            if (baseDataSetXF.IF_GetFillColor().HasValue)
            {
                originalBaseDataSet.FillColor = baseDataSetXF.IF_GetFillColor().Value.ToUIColor();
            }

            if (baseDataSetXF.IF_GetFillAlpha().HasValue)
            {
                originalBaseDataSet.FillAlpha = baseDataSetXF.IF_GetFillAlpha().Value;
            }

            if (baseDataSetXF.IF_GetLineWidth().HasValue)
            {
                originalBaseDataSet.LineWidth = baseDataSetXF.IF_GetLineWidth().Value;
            }

            if (baseDataSetXF.IF_GetDrawFilled().HasValue)
            {
                originalBaseDataSet.DrawFilledEnabled = baseDataSetXF.IF_GetDrawFilled().Value;
            }
        }
    }
}