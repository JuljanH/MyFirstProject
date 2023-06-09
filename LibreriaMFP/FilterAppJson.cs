using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;

namespace LibreriaMFP
{
    public class FilterAppJson : Filter_abstract, IDataLoader, INotifyPropertyChanged
    {
        private Utenti Utenti =new Utenti();

        private ObservableCollection<Utenti>? _items = new ObservableCollection<Utenti>();

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

        public override void LoadData()
        {
            var ResourceName_MockData = Assembly.GetExecutingAssembly().GetManifestResourceNames().First(x => x == "LibreriaMFP.Resources.MOCK_DATA.json");
            string jsonFile = "";
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName_MockData))
            using (StreamReader reader = new StreamReader(stream))
            {
                jsonFile = reader.ReadToEnd(); //Make string equal to full file
            }
            //string json = System.IO.File.ReadAllText(@"C:\Users\jhoxha\OneDrive - ALTEN Group\Documents\GitHub\Esercizi\MyFirstProject\LibreriaMFP\Resources\MOCK_DATA.json");
            Items = JsonConvert.DeserializeObject<ObservableCollection<Utenti>>(jsonFile);
        }

        public override void StringFilter(string keyword, string field)
        {
            var filteredItems = new ObservableCollection<Utenti>();

            switch (field)
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
