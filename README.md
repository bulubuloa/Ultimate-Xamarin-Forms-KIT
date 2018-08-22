## Xamarin Forms Custom Renderer 
I create this package for sharing all my xamarin forms custom controls

[![NuGet](https://img.shields.io/badge/Nuget%20UltimateXF-V2.0.0-green.svg)](https://www.nuget.org/packages/UltimateXF/)

### MPAndroidChart Binding   

<p>Add assembly references

    xmlns:ultimateChart="clr-namespace:UltimateXF.Widget.Charts;assembly=UltimateXF"

Setup for iOS project (add to AppDelegate before LoadApplication)

    UltimateXF.iOS.UltimateXF.Initialize();

Setup for Android project (add to MainActivity before LoadApplication)

    UltimateXF.Droid.UltimateXF.Initialize(this);

 **Required:**
 - ***[Xamarin.Forms](>= 3.1.0.697729)***
 - ***Your app could not run on simulator(iOS) - only real device)***
 - ***Install Xamarin.Swift4 package for iOS project(maybe if your app can't start)*** 
		

    [Xamarin.Swift4] (>= 4.0.0)
    		[Xamarin.Swift4.Core]  (>= 4.1.2)
    		[Xamarin.Swift4.CoreAudio](>= 4.1.2)
    		[Xamarin.Swift4.CoreData]  (>= 4.1.2)
    		[Xamarin.Swift4.CoreFoundation] (>= 4.1.2)
    		[Xamarin.Swift4.CoreGraphics]  (>= 4.1.2)
    		[Xamarin.Swift4.CoreImage] (>= 4.1.2)
    		[Xamarin.Swift4.CoreMedia] (>= 4.1.2)
    		[Xamarin.Swift4.Darwin] (>= 4.1.2)
    		[Xamarin.Swift4.Dispatch]  (>= 4.1.2)
    		[Xamarin.Swift4.Foundation] (>= 4.1.2)
    		[Xamarin.Swift4.Metal] (>= 4.1.2)
    		[Xamarin.Swift4.ObjectiveC] (>= 4.1.2)
    		[Xamarin.Swift4.OS] (>= 4.1.2)
    		[Xamarin.Swift4.QuartzCore]  (>= 4.1.2)
    		[Xamarin.Swift4.UIKit] (>= 4.1.2)

- ***You can downgrade swift support version for you project or your device (just download this project source and downgrade version of library for each project)***

#### LineChart & BarChart

    <ultimateChart:SupportLineChartExtended 
    	x:Name="chart"
        HorizontalOptions="FillAndExpand"
        VerticalOptions="FillAndExpand"
        DrawBorders="false"
        DoubleTapToZoomEnabled="false" />

DataBinding

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

**Chart types:**

*Screenshots are currently taken from the original repository, as they render exactly the same :-)*


 - **LineChart (with legend, simple design)**
![alt tag](https://raw.github.com/PhilJay/MPChart/master/screenshots/simpledesign_linechart4.png)
 - **LineChart (with legend, simple design)**
![alt tag](https://raw.github.com/PhilJay/MPChart/master/screenshots/simpledesign_linechart3.png)

 - **LineChart (cubic lines)**
![alt tag](https://raw.github.com/PhilJay/MPChart/master/screenshots/cubiclinechart.png)

 - **LineChart (gradient fill)**
![alt tag](https://raw.github.com/PhilJay/MPAndroidChart/master/screenshots/line_chart_gradient.png)

 - **Combined-Chart (bar- and linechart in this case)**
![alt tag](https://raw.github.com/PhilJay/MPChart/master/screenshots/combined_chart.png)

 - **BarChart (with legend, simple design)**

![alt tag](https://raw.github.com/PhilJay/MPChart/master/screenshots/simpledesign_barchart3.png)

 - **BarChart (grouped DataSets)**

![alt tag](https://raw.github.com/PhilJay/MPChart/master/screenshots/groupedbarchart.png)

 - **Horizontal-BarChart**

![alt tag](https://raw.github.com/PhilJay/MPChart/master/screenshots/horizontal_barchart.png)


 - **PieChart (with selection, ...)**

![alt tag](https://raw.github.com/PhilJay/MPAndroidChart/master/screenshots/simpledesign_piechart1.png)

 - **ScatterChart** (with squares, triangles, circles, ... and more)

![alt tag](https://raw.github.com/PhilJay/MPAndroidChart/master/screenshots/scatterchart.png)

 - **CandleStickChart** (for financial data)

![alt tag](https://raw.github.com/PhilJay/MPAndroidChart/master/screenshots/candlestickchart.png)

 - **BubbleChart** (area covered by bubbles indicates the value)

![alt tag](https://raw.github.com/PhilJay/MPAndroidChart/master/screenshots/bubblechart.png)

 - **RadarChart** (spider web chart)

![alt tag](https://raw.github.com/PhilJay/MPAndroidChart/master/screenshots/radarchart.png)

# License
<p>Copyright 2018 QuachHoang
<p>Special thanks Daniel Cohen Gindi & Philipp Jahoda
