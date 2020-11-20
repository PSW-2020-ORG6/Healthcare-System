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
using klinika_zdravo.Model;

namespace klinika_zdravo.Pages
{
    /// <summary>
    /// Interaction logic for ProfilnaStranica.xaml
    /// </summary>
    public partial class ProfilnaStranica : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _name2 = AccountModel.getInstance().Ime;

        public string ImeTxt
        {
            get { return AccountModel.getInstance().Ime; }
            set
            {
                if (value != AccountModel.getInstance().Ime)
                {
                    AccountModel.getInstance().Ime = value;
                    OnPropertyChanged("ImeTxt");
                }

            }
        }

        public string PrezimeTxt
        {
            get { return AccountModel.getInstance().Prezime; }
            set
            {
                if (value != AccountModel.getInstance().Prezime)
                {
                    AccountModel.getInstance().Prezime = value;
                    OnPropertyChanged("PrezimeTxt");
                }

            }
        }

        public string RoditeljTxt
        {
            get { return AccountModel.getInstance().ImeRoditelja; }
            set
            {
                if (value != AccountModel.getInstance().ImeRoditelja)
                {
                    AccountModel.getInstance().ImeRoditelja = value;
                    OnPropertyChanged("RoditeljTxt");
                }

            }
        }

        public string DatumTxt
        {
            get { return AccountModel.getInstance().DatumRodjenja; }
            set
            {
                if (value != AccountModel.getInstance().DatumRodjenja)
                {
                    AccountModel.getInstance().DatumRodjenja = value;
                    OnPropertyChanged("DatumTxt");
                }

            }
        }

        public string JmbgTxt
        {
            get { return AccountModel.getInstance().JMBG; }
            set
            {
                if (value != AccountModel.getInstance().JMBG)
                {
                    AccountModel.getInstance().JMBG = value;
                    OnPropertyChanged("JmbgTxt");
                }

            }
        }

        public string PolTxt
        {
            get { return AccountModel.getInstance().Pol; }
            set
            {
                if (value != AccountModel.getInstance().Pol)
                {
                    AccountModel.getInstance().Pol = value;
                    OnPropertyChanged("PolTxt");
                }

            }
        }

        public string DrzavaTxt
        {
            get { return AccountModel.getInstance().Drzava; }
            set
            {
                if (value != AccountModel.getInstance().Drzava)
                {
                    AccountModel.getInstance().Drzava = value;
                    OnPropertyChanged("DrzavaTxt");
                }

            }
        }

        public string GradTxt
        {
            get { return AccountModel.getInstance().Grad; }
            set
            {
                if (value != AccountModel.getInstance().Grad)
                {
                    AccountModel.getInstance().Grad = value;
                    OnPropertyChanged("GradTxt");
                }

            }
        }

        public string UlicaTxt
        {
            get { return AccountModel.getInstance().Ulica; }
            set
            {
                if (value != AccountModel.getInstance().Ulica)
                {
                    AccountModel.getInstance().Ulica = value;
                    OnPropertyChanged("UlicaTxt");
                }

            }
        }

        public string BrojTxt
        {
            get { return AccountModel.getInstance().BrojTelefona; }
            set
            {
                if (value != AccountModel.getInstance().BrojTelefona)
                {
                    AccountModel.getInstance().BrojTelefona = value;
                    OnPropertyChanged("BrojTxt");
                }

            }
        }

        public string EmailTxt
        {
            get { return AccountModel.getInstance().eMail; }
            set
            {
                if (value != AccountModel.getInstance().eMail)
                {
                    AccountModel.getInstance().eMail = value;
                    OnPropertyChanged("EmailTxt");
                }

            }
        }

        public ProfilnaStranica()
        {
            InitializeComponent();
            tekstIme.DataContext = this;
            tekstPrezime.DataContext = this;
            tekstRoditelj.DataContext = this;
            tekstDatum.DataContext = this;
            tekstJmbg.DataContext = this;
            tekstPol.DataContext = this;
            tekstDrzava.DataContext = this;
            tekstGrad.DataContext = this;
            tekstUlica.DataContext = this;
            tekstBroj.DataContext = this;
            tekstEmail.DataContext = this;

            boxIme.DataContext = this;
            boxPrezime.DataContext = this;
            boxRoditelj.DataContext = this;
            boxDatum.DataContext = this;
            boxJmbg.DataContext = this;
            boxDrzava.DataContext = this;
            boxGrad.DataContext = this;
            boxUlica.DataContext = this;
            boxBroj.DataContext = this;
            boxEmail.DataContext = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImeTxt = boxIme.Text;
            PrezimeTxt = boxPrezime.Text;
            RoditeljTxt = boxRoditelj.Text;
            DatumTxt = boxDatum.Text;
            JmbgTxt = boxJmbg.Text;
            DrzavaTxt = boxDrzava.Text;
            GradTxt = boxGrad.Text;
            UlicaTxt = boxUlica.Text;
            BrojTxt = boxBroj.Text;
            EmailTxt = boxEmail.Text;
        }
    }
}
