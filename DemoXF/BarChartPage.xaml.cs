using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.BarChart;
using UltimateXF.Widget.Charts.Models.Formatters;
using Xamarin.Forms;

namespace DemoXF
{
    public partial class BarChartPage : ContentPage
    {
        public BarChartPage()
        {
            InitializeComponent();

            var entries = new List<EntryChart>();
            var entries2 = new List<EntryChart>();
            var labels = new List<string>();

            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                entries.Add(new EntryChart(i, random.Next(20)));
                entries2.Add(new EntryChart(i, random.Next(20)));
                labels.Add("Entry" + i);
            }

            var dataSet4 = new BarDataSet(entries, "Bar DataSet 1")
            {
                Colors = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                },
            };
            var dataSet5 = new BarDataSet(entries2, "Bar DataSet 2")
            {
                Colors = new List<Color>{
                    Color.Green
                },
            };

            var data4 = new BarChartData(new List<IBarDataSet>() { dataSet4 });

            chart.ChartData = data4;
            chart.DescriptionChart.Text = "Test label chart description";

            chart.AxisLeft.DrawGridLines = false;
            chart.AxisLeft.DrawAxisLine = true;
            chart.AxisLeft.Enabled = true;

            chart.AxisRight.DrawAxisLine = false;
            chart.AxisRight.DrawGridLines = false;
            chart.AxisRight.Enabled = false;

            chart.XAxis.XAXISPosition = XAXISPosition.BOTTOM;
            chart.XAxis.DrawGridLines = false;
            chart.XAxis.AxisValueFormatter = new TextByIndexXAxisFormatter(labels);

            chart2.ChartData = data4;
        }
    }
}