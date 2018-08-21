using System;
using System.ComponentModel;
using iOSCharts;
using UltimateXF.iOS.Renderers.Exporters;
using UltimateXF.Widget.Charts;
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