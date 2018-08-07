using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.RadarChart;
using Xamarin.Forms;

namespace DemoXF
{
    public partial class RadarChartPage : ContentPage
    {
        public RadarChartPage()
        {
            InitializeComponent();

            var entries = new List<RadarEntry>();
            entries.Add(new RadarEntry(5));
            entries.Add(new RadarEntry(7));
            entries.Add(new RadarEntry(10));
            entries.Add(new RadarEntry(8));
            entries.Add(new RadarEntry(14));

            var labels = new List<string>();
            labels.Add("col1");
            labels.Add("col2");
            labels.Add("col3");
            labels.Add("col4");
            labels.Add("col5");

            var dataSet4 = new RadarDataSet(entries, "Radar DataSet")
            {
                DrawValue = false,
                DataColorScheme = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                }
            };
            var data4 = new RadarChartData(new List<IRadarDataSet>() { dataSet4 }, labels);

            var dataSet5 = new RadarDataSet(entries, "Radar DataSet")
            {
                DrawValue = false,
                DataColorScheme = new List<Color>(){
                    Color.GreenYellow
                }
            };
            var data5 = new RadarChartData(new List<IRadarDataSet>() { dataSet5 }, labels);

            radarChart.ChartData = data4;
            radarChart2.ChartData = data5;
        }
    }
}