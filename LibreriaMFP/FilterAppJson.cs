using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LibreriaMFP
{
    public class FilterAppJson : Filter_abstract, IDataLoader, INotifyPropertyChanged
    {
        private ObservableCollection<Utenti> _items;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Utenti> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }

        public override void GenderFilter()
        {
            throw new NotImplementedException();
        }

        public override void IdFilter()
        {
            throw new NotImplementedException();
        }

        public override DataLoader LoadData()
        {
            string json = System.IO.File.ReadAllText(@"\Resources\MOCK_DATA.json");
            Items = JsonConvert.DeserializeObject<ObservableCollection<Utenti>>(json);
            return Items;
        }

        public override void StringFilter(string keyword, string field)
        {
            var filteredItems = new ObservableCollection<Utenti>();

            switch (field.ToLower())
            {
                case "firstname":
                    filteredItems = new ObservableCollection<Utenti>(Items.Where(item => item.FirstName.Contains(keyword)));
                    break;
                case "lastname":
                    filteredItems = new ObservableCollection<Utenti>(Items.Where(item => item.LastName.Contains(keyword)));
                    break;
                case "ipaddress":
                    filteredItems = new ObservableCollection<Utenti>(Items.Where(item => item.Ip.Contains(keyword)));
                    break;
                default:
                    throw new ArgumentException("Invalid field specified.");
            }

            Items = filteredItems;
        }
    }
}
