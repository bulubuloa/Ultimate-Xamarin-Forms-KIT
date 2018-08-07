## Xamarin Forms Custom Renderer 
I create this package for sharing all my xamarin forms custom controls

### MPAndroidChart Binding   
[![NuGet](https://img.shields.io/badge/NUGET-1.1-blue.svg)](https://www.nuget.org/packages/UltimateXF/)
<p>Add assembly references

    xmlns:ultimateChart="clr-namespace:UltimateXF.Widget.Charts;assembly=UltimateXF"

Setup for iOS project (add to AppDelegate before LoadApplication)

    UltimateXF.iOS.UltimateXF.Initialize();

Setup for Android project (add to MainActivity before LoadApplication)

    UltimateXF.Droid.UltimateXF.Initialize(this);

 **Required:**
 - ***[Xamarin.Forms](>= 3.1.0.697729)***
 - ***Install Xamarin.Swift4 package for iOS project (this app could not run on simulator - only real device)*** 
		

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

    <ultimateChart:SupportBarChart  
	    x:Name="lineChart"  
	    VerticalOptions="FillAndExpand"  
	    HorizontalOptions="FillAndExpand"  
	    Description="Renderer"  
	    IsShowLeftAxis="false"  
	    IsShowLeftAxisLine="true"  
	    IsShowLeftAxisValue="true"  
	    IsShowRightAxis="false"  
	    IsShowRightAxisLine="false"  
	    IsShowRightAxisValue="false"  
	    IsShowXAxis="false"  
	    IsShowXAxisLine="true"  
	    IsShowXAxisValue="true"  
	    XAxisPosition="BOTTOM"  />

DataBinding

    var  entries  =  new  List<EntryChart>();  
    entries.Add(new  EntryChart(0,5));  
    entries.Add(new  EntryChart(1,7));  
    entries.Add(new  EntryChart(2,10));  
    entries.Add(new  EntryChart(3,3));  
    var  dataSet  =  new  BarDataSet(entries,  "Line Chart")  
    {  
	    DataColor  =  Color.Red,  
	    DrawValue  =  false,  
    };    
    var  data  =  new  BarChartData(new  List<IBarDataSet>(){dataSet},new  List<string>());  
    lineChart.ChartData  =  data;

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
