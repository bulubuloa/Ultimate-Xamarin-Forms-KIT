using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.LineChart
{
    public class LineDataSet : BaseDataSet<EntryChart>, ILineDataSet
    {
        public LineDataSetMode? DrawMode { set; private get; }
        public float? CircleRadius { set; private get; }
        public float? CircleHoleRadius { set; private get; }
        public bool? DrawCircle { set; private get; }
        public List<Color> CircleColors { set; private get; }

        public int? LineWidth { set; private get; }
        public bool? DrawFilled { set; private get; }

        public LineDataSet(List<EntryChart> _EntryItems, string _Title) : base(_EntryItems,_Title)
        {
            CircleColors = new List<Color>();
        }

        public LineDataSetMode? IF_GetDrawMode()
        {
            return DrawMode;
        }

        public float? IF_GetCircleRadius()
        {
            return CircleRadius;
        }

        public float? IF_GetCircleHoleRadius()
        {
            return CircleHoleRadius;
        }

        public bool? IF_GetDrawCircle()
        {
            return DrawCircle;
        }

        public List<Color> IF_GetCircleColors()
        {
            return CircleColors;
        }

        public bool? IF_GetDrawFilled()
        {
            return DrawFilled;
        }

        public int? IF_GetLineWidth()
        {
            return LineWidth;
        }
    }
}