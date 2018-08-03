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

# License
<p>Copyright 2018 QuachHoang
<p>Special thanks Daniel Cohen Gindi & Philipp Jahoda
