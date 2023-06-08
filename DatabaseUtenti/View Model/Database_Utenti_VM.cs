using DatabaseUtenti;
using LibreriaMFP;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

public class Database_Utenti_VM : INotifyPropertyChanged
{
    private string _inputStringa;

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public string InputStringa
    {
        get { return _inputStringa; }
        set
        {
            _inputStringa = value;
            OnPropertyChanged(nameof(InputStringa));
        }
    }

    public ICommand PassaStringaCommand { get; }
    public Database_Utenti_VM()
    {
        PassaStringaCommand = new RelayCommand(PassaStringa);
    }
    private void PassaStringa()
    {
        FilterAppJson.StringFilter(InputStringa, "firstname");
    }
}

