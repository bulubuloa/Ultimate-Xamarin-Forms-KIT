using System;
using UltimateXF.Widget.Charts.Models;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportLineChart : SupportChartView
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(IBaseData<UltimateXF.Widget.Charts.Models.Entry>), typeof(SupportLineChart), null);
        public IBaseData<UltimateXF.Widget.Charts.Models.Entry> ChartData
        {
            get => (IBaseData<UltimateXF.Widget.Charts.Models.Entry>)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public SupportLineChart()
        {
            
        }
    }
}