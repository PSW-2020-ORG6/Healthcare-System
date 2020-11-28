using System.ComponentModel;

namespace klinika_zdravo.Model
{
    public class IstorijaBolestiModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _datum;
        private string _doktor;
        private string _dijagnoza;
        private string _lecenje;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Datum
        {
            get => _datum; set
            {
                if (value != _datum) _datum = value;
                OnPropertyChanged("Datum");
            }
        }

        public string Doktor
        {
            get => _doktor; set
            {
                if (value != _doktor) _doktor = value;
                OnPropertyChanged("Doktor");
            }
        }

        public string Dijagnoza
        {
            get => _dijagnoza; set
            {
                if (value != _dijagnoza) _dijagnoza = value;
                OnPropertyChanged("Dijagnoza");
            }
        }

        public string Lecenje
        {
            get => _lecenje; set
            {
                if (value != _lecenje) _lecenje = value;
                OnPropertyChanged("Lecenje");
            }
        }

        public IstorijaBolestiModel(string datum, string doktor, string dijagnoza, string lecenje)
        {
            Datum = datum;
            Doktor = doktor;
            Dijagnoza = dijagnoza;
            Lecenje = lecenje;
        }
    }
}
