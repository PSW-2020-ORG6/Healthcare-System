using klinika_zdravo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace klinika_zdravo.Pages
{
    /// <summary>
    /// Interaction logic for BrzoZakazivanjeStranica.xaml
    /// </summary>
    public partial class BrzoZakazivanjeStranica : Page, INotifyPropertyChanged
    {
        public BrzoZakazivanjeStranica()
        {
            InitializeComponent();
            //boxDatum.DataContext = this;
            boxVreme.DataContext = this;
            boxTip.DataContext = this;
            boxSoba.DataContext = this;
            boxDoktor.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _datum;

        public string Datum
        {
            get { return _datum; }
            set
            {
                if (value != _datum)
                {
                    _datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }

        private string _vreme;

        public string Vreme
        {
            get { return _vreme; }
            set
            {
                if (value != _vreme)
                {
                    _vreme = value;
                    OnPropertyChanged("Vreme");
                }
            }
        }
        private string _tip;

        public string Tip
        {
            get { return _tip; }
            set
            {
                if (value != _tip)
                {
                    _tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        private string _doktor;

        public string Doktor
        {
            get { return _doktor; }
            set
            {
                if (value != _doktor)
                {
                    _doktor = value;
                    OnPropertyChanged("Doktor");
                }
            }
        }

        private string _prostorija;

        public string Prostorija
        {
            get { return _prostorija; }
            set
            {
                if (value != _prostorija)
                {
                    _prostorija = value;
                    OnPropertyChanged("Prostorija");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(doktor.Text == "")
            {
                dialogNemaDr.IsOpen = true;
            }
            else
            {
                Datum = boxDatum.Text;
                Vreme = "12:00";
                Prostorija = "504";
                Tip = "Pregled";
                Doktor = doktor.Text;
                dijalog.IsOpen = true;
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AccountModel.accountModel.Termini.Add(new TerminiModel(boxTip.Text, boxDatum.Text, boxVreme.Text, boxDoktor.Text, boxSoba.Text));
            dijalog.IsOpen = false;
            dialogPotvrda.IsOpen = true;
        }
    }
}
