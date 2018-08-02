using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models
{
    public class BaseDataSet<TEntry> : IBaseDataSet<TEntry>  where TEntry : BaseEntry
    {
        private List<TEntry> EntryItems { set; get; }
        private string Title { set; get; }

        public BaseDataSet(List<TEntry> _EntryItems,string _Title)
        {
            EntryItems = _EntryItems;
            Title = _Title;
        }

        public List<TEntry> IF_GetEntry()
        {
            return EntryItems;
        }

        public string IF_GetTitle()
        {
            return Title;
        }
    }

    public interface IBaseDataSet<TEntry>
    {
        List<TEntry> IF_GetEntry();
        string IF_GetTitle();
    }
}