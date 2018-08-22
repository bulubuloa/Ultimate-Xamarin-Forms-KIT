using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.Component;
using UltimateXF.Widget.Charts.Models.Formatters;
using UltimateXF.Widget.Charts.Models.LineChart;
using Xamarin.Forms;

namespace DemoXF
{
    public class CustomXAxisValueFormatter : IAxisValueFormatterXF
    {
        private List<string> Titles;

        public CustomXAxisValueFormatter(List<string> _Titles)
        {
            Titles = _Titles;
        }

        public string GetFormattedValue(float _Value)
        {
            try
            {
                return Titles[(int)_Value];
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }

    //test custom $
    public class CustomDataSetValueFormatter : IDataSetValueFormatter
    {
        public string GetFormattedValue(float value, int dataSetIndex)
        {
            return value.ToString("N2") + "$";
        }
    }

    public partial class LineChartPage : ContentPage
    {
        public LineChartPage()
        {
            InitializeComponent();

            var entries = new List<EntryChart>();
            var entries2 = new List<EntryChart>();
            var labels = new List<string>();

            var random = new Random();
            for (int i = 0; i < 7; i++)
            {
                entries.Add(new EntryChart(i, random.Next(1000,50000)));
                entries2.Add(new EntryChart(i, random.Next(1000,50000)));
                labels.Add("Entry" + i);
            }

            var FontFamily = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    FontFamily = "Pacifico-Regular";
                    break;
                case Device.Android:
                    FontFamily = "Fonts/Pacifico-Regular.ttf";
                    break;
                default:
                    break;
            }
            var dataSet4 = new LineDataSetXF(entries, "Line DataSet 1")
            {
                CircleRadius = 10,
                CircleHoleRadius = 4f,
                CircleColors = new List<Color>(){
                    Color.Accent, Color.Red, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                },
                CircleHoleColor = Color.Green,
                ValueColors = new List<Color>(){
                    Color.Accent, Color.Red, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                },
                Mode = LineDataSetMode.CUBIC_BEZIER,
                ValueFormatter = new CustomDataSetValueFormatter(),
                ValueFontFamily = FontFamily
            };

            Xamarin.Forms.OnPlatform<string> onPlatform = (Xamarin.Forms.OnPlatform<string>)Application.Current.Resources["PacificoRegular"];
            var xxx = onPlatform.Default;

            var dataSet5 = new LineDataSetXF(entries2, "Line DataSet 2")
            {
                Colors = new List<Color>{
                    Color.Green
                },
                CircleHoleColor = Color.Blue,
                CircleColors = new List<Color>{
                    Color.Blue
                },
                CircleRadius = 3,
                DrawValues = false,

            };

            var data4 = new LineChartData(new List<ILineDataSetXF>() { dataSet4,dataSet5 });

            chart.ChartData = data4;
            chart.DescriptionChart.Text = "Test label chart description";
            chart.AxisLeft.DrawGridLines = false;
            chart.AxisLeft.DrawAxisLine = true;
            chart.AxisLeft.Enabled = true;

            chart.AxisRight.DrawAxisLine = false;
            chart.AxisRight.DrawGridLines = false;
            chart.AxisRight.Enabled = false;

            chart.AxisRight.FontFamily = FontFamily;
            chart.AxisLeft.FontFamily = FontFamily;
            chart.XAxis.FontFamily = FontFamily;

            chart.XAxis.XAXISPosition = XAXISPosition.BOTTOM;
            chart.XAxis.DrawGridLines = false;
            chart.XAxis.AxisValueFormatter = new TextByIndexXAxisFormatter(labels);
        }
    }
}