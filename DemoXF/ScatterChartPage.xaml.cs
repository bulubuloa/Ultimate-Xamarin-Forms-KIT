using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.ScatterChart;
using Xamarin.Forms;

namespace DemoXF
{
    public partial class ScatterChartPage : ContentPage
    {
        public ScatterChartPage()
        {
            InitializeComponent();

            var entries = new List<EntryChart>();
            entries.Add(new EntryChart(0, 5));
            entries.Add(new EntryChart(1, 7));
            entries.Add(new EntryChart(2, 10));
            entries.Add(new EntryChart(3, 3));
            entries.Add(new EntryChart(4, 1));
            entries.Add(new EntryChart(5, 7));
            entries.Add(new EntryChart(6, 2));

            var labels = new List<string>();
            labels.Add("col1");
            labels.Add("col2");
            labels.Add("col3");
            labels.Add("col4");
            labels.Add("col5");
            labels.Add("col6");
            labels.Add("col7");

            var dataSet4 = new ScatterDataSet(entries, "Scatter DataSet")
            {
                DrawValue = true,
                DataColorScheme = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                }
            };
            var data4 = new ScatterChartData(new List<IScatterDataSet>() { dataSet4 }, labels);

            var dataSet5 = new ScatterDataSet(entries, "Bar DataSet")
            {
                DrawValue = true,
                DataColorScheme = new List<Color>(){
                    Color.GreenYellow
                }
            };
            var data5 = new ScatterChartData(new List<IScatterDataSet>() { dataSet5 }, labels);

            scatterChart.ChartData = data4;
            scatterChart2.ChartData = data5;
        }
    }
}