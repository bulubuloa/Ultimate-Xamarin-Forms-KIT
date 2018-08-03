using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models
{
    public class BaseDataSet<TEntry> : IBaseDataSet<TEntry>  where TEntry : BaseEntry
    {
        protected List<TEntry> EntryItems { set; get; }
        protected string Title { set; get; }
        public Color DataColor { set; private get; }
        public bool DrawValue { set; private get; }

        public BaseDataSet(List<TEntry> _EntryItems,string _Title)
        {
            EntryItems = _EntryItems;
            Title = _Title;
            DataColor = Color.Black;
            DrawValue = true;
        }

        public List<TEntry> IF_GetEntry()
        {
            return EntryItems;
        }

        public string IF_GetTitle()
        {
            return Title;
        }

        public Color IF_GetDataColor()
        {
            return DataColor;
        }

        public bool IF_GetDrawValue()
        {
            return DrawValue;
        }
    }
}