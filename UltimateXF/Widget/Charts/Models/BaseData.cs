using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models
{
    public class BaseData<TEntry,TInterface> : IBaseData<TEntry,TInterface> where TEntry : BaseEntry where TInterface : IBaseDataSet<TEntry>
    {
        public List<TInterface> DataSetItems { set; get; }
        public List<string> TitleItems { set; get; }

        public BaseData(List<TInterface> _DataSetItems, List<string> _TitleItems)
        {
            DataSetItems = _DataSetItems;
            TitleItems = _TitleItems;
        }

        public List<TInterface> IF_GetDataSet()
        {
            return DataSetItems;
        }

        public List<string> IF_GetTitleSet()
        {
            return TitleItems;
        }
    }
}