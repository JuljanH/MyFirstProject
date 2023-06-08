using System.Collections.ObjectModel;

namespace LibreriaMFP
{
    public abstract class Filter_abstract: IDataLoader
    {
        public abstract DataLoader LoadData();
        public abstract void GenderFilter();
        public abstract void StringFilter(string keyword, string field);
        public abstract void IdFilter();
        
    }
}