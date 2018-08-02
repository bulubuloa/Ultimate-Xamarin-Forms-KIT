using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models
{
    public class BaseData<TEntry> : IBaseData<TEntry> where TEntry : BaseEntry
    {
        public List<IBaseDataSet<TEntry>> DataSetItems { set; get; }
        public List<string> TitleItems { set; get; }

        public BaseData(List<IBaseDataSet<TEntry>> _DataSetItems, List<string> _TitleItems)
        {
            DataSetItems = _DataSetItems;
            TitleItems = _TitleItems;
        }

        public List<IBaseDataSet<TEntry>> IF_GetDataSet()
        {
            return DataSetItems;
        }

        public List<string> IF_GetTitleSet()
        {
            return TitleItems;
        }
    }

    public interface IBaseData<TEntry>
    {
        List<IBaseDataSet<TEntry>> IF_GetDataSet();
        List<string> IF_GetTitleSet();
    }
}