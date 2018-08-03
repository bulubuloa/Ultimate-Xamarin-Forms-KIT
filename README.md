# Xamarin Forms Custom Renderer 
I create this package for sharing all my xamarin forms custom controls

## MPAndroidChart Binding
add assembly references

    xmlns:ultimateChart="clr-namespace:UltimateXF.Widget.Charts;assembly=UltimateXF"

 
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
