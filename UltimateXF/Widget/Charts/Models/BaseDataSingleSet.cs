using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models
{
    public class BaseDataSingleSet<TEntry, TInterface> : IBaseDataSingleSet<TEntry, TInterface> where TEntry : BaseEntry where TInterface : IBaseDataSet<TEntry>
    {
        public TInterface DataSetItem { set; get; }
        public List<string> TitleItems { set; get; }

        public BaseDataSingleSet(TInterface _DataSetItems, List<string> _TitleItems)
        {
            DataSetItem = _DataSetItems;
            TitleItems = _TitleItems;
        }

        public TInterface IF_GetDataSet()
        {
            return DataSetItem;
        }

        public List<string> IF_GetTitleSet()
        {
            return TitleItems;
        }
    }
}