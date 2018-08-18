using System.Collections.Generic;
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
            entries.Add(new RadarEntry(40));
            entries.Add(new RadarEntry(50));
            entries.Add(new RadarEntry(20));
            entries.Add(new RadarEntry(70));
            entries.Add(new RadarEntry(60));
            entries.Add(new RadarEntry(50));
            entries.Add(new RadarEntry(100));
            entries.Add(new RadarEntry(70));
            entries.Add(new RadarEntry(75));

            var labels = new List<string>();
            labels.Add("Party A");
            labels.Add("Party B");
            labels.Add("Party C");
            labels.Add("Party D");
            labels.Add("Party E");
            labels.Add("Party F");
            labels.Add("Party G");
            labels.Add("Party H");
            labels.Add("Party I");

            var dataSet4 = new RadarDataSet(entries, "Radar DataSet")
            {
                DrawValue = false,
                DataColorScheme = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                },
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