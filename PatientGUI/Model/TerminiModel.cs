using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace klinika_zdravo.Model
{
    public class TerminiModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _tip;
        private string _datum;
        private string _vreme;
        private string _doktor;
        private string _soba;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Tip
        {
            get => _tip; set
            {
                if (value != _tip) _tip = value;
                OnPropertyChanged("Tip");
            }
        }

        public string Vreme
        {

            get => _vreme; set
            {
                if (value != _vreme) _vreme = value;
                OnPropertyChanged("Vreme");
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
        public string Soba
        {
            get => _soba; set
            {
                if (value != _soba) _soba = value;
                OnPropertyChanged("Soba");
            }
        }

        public TerminiModel(string tip, string datum, string vreme, string doktor, string soba)
        {
            Tip = tip;
            Datum = datum;
            Vreme = vreme;
            Doktor = doktor;
            Soba = soba;
        }


    }
}
