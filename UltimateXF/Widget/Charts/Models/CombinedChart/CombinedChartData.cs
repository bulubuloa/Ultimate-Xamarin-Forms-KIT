using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.BarChart;
using UltimateXF.Widget.Charts.Models.BubbleChart;
using UltimateXF.Widget.Charts.Models.CandleStickChart;
using UltimateXF.Widget.Charts.Models.Component;
using UltimateXF.Widget.Charts.Models.LineChart;
using UltimateXF.Widget.Charts.Models.ScatterChart;

namespace UltimateXF.Widget.Charts.Models.CombinedChart
{
    public class CombinedChartData : ChartDataXF<IDataSetXF<BaseEntry>, BaseEntry>
    {
        private LineChartData _LineChartData;
        public LineChartData LineChartData 
        {
            get => _LineChartData;
            set
            {
                _LineChartData = value;
                OnPropertyChanged();
            }
        }

        private BarChartData _BarChartData;
        public BarChartData BarChartData
        {
            get => _BarChartData;
            set
            {
                _BarChartData = value;
                OnPropertyChanged();
            }
        }

        private ScatterChartData _ScatterChartData;
        public ScatterChartData ScatterChartData
        {
            get => _ScatterChartData;
            set
            {
                _ScatterChartData = value;
                OnPropertyChanged();
            }
        }

        private CandleStickChartData _CandleStickChartData;
        public CandleStickChartData CandleStickChartData
        {
            get => _CandleStickChartData;
            set
            {
                _CandleStickChartData = value;
                OnPropertyChanged();
            }
        }

        private BubbleChartData _BubbleChartData;
        public BubbleChartData BubbleChartData
        {
            get => _BubbleChartData;
            set
            {
                _BubbleChartData = value;
                OnPropertyChanged();
            }
        }

        public CombinedChartData(IDataSetXF<BaseEntry> dataSet, List<string> _Titles) : base(dataSet, _Titles)
        {
        }
    }
}