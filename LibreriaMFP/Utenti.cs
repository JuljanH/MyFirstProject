using System.ComponentModel;
using System.Text.Json.Serialization;

namespace LibreriaMFP
{
    public class Utenti : INotifyPropertyChanged
    {
        [JsonPropertyName("id")]
        private int _id;
        public int Id {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        [JsonPropertyName("first_name")]
        private string? _firstname;
        public string FirstName
        {
            get { return _firstname; }
            set { 
                _firstname = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        [JsonPropertyName("last_name")]
        private string _lastname;
        public string LastName
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        [JsonPropertyName("email")]
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        [JsonPropertyName("gender")]
        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public enum gender : int
        {
            Male = 0,
            Female = 1
        };

        [JsonPropertyName("ip_address")]
        private string _ip;
        public string Ip
        {
            get { return _ip; }
            set
            {
                _ip = value;
                OnPropertyChanged(nameof(Ip));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}