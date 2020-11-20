using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika_zdravo.Model
{
    class AccountModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _ime;
        private string _prezime;
        private string _imeRoditelja;
        private string _datumRodjenja;
        private string _jmbg;
        private string _pol;
        private string _drzava;
        private string _grad;
        private string _ulica;
        private string _brojTelefona;
        private string _eMail;
        private List<TerminiModel> _termini;
        private List<IstorijaBolestiModel> _istorijaBolesti;

        
        public static AccountModel accountModel = new AccountModel("Vladimir", "Budjen", "Aleksandar", "01.01.1939", "0101939548967", "muski", "Sremska Kamenica", "Bocke", "Gavrila principa 39a", "064/958-45-17", "vladimirbudjen@gmail.com");

        public static AccountModel getInstance()
        {
            return accountModel;
        }

        public AccountModel()
        {
        }


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public List<TerminiModel> Termini
        {
            get => _termini; set
            {
                if (value != _termini) _termini = value;
                OnPropertyChanged("Ime");
            }
        }

        public List<IstorijaBolestiModel> IstorijaBolesti
        {
            get => _istorijaBolesti; set
            {
                if (value != _istorijaBolesti) _istorijaBolesti = value;
                OnPropertyChanged("IstorijaBolesti");
            }
        }

        public string Ime
        {
            get => _ime; set
            {
                if (value != _ime) _ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Prezime
        {
            get => _prezime; set
            {
                if (value != _prezime) _prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        public string ImeRoditelja
        {
            get => _imeRoditelja; set
            {
                if (value != _imeRoditelja) _imeRoditelja = value;
                OnPropertyChanged("ImeRoditelja");
            }
        }
        public string DatumRodjenja
        {
            get => _datumRodjenja; set
            {
                if (value != _datumRodjenja) _datumRodjenja = value;
                OnPropertyChanged("DatumRodjenja");
            }
        }
        public string JMBG
        {
            get => _jmbg; set
            {
                if (value != _jmbg) _jmbg = value;
                OnPropertyChanged("JMBG");
            }
        }

        public string Pol
        {
            get => _pol; set
            {
                if (value != _pol) _pol = value;
                OnPropertyChanged("Pol");
            }
        }

        public string Drzava
        {
            get => _drzava; set
            {
                if (value != _drzava) _drzava = value;
                OnPropertyChanged("Drzava");
            }
        }

        public string Grad
        {
            get => _grad; set
            {
                if (value != _grad) _grad = value;
                OnPropertyChanged("Grad");
            }
        }

        public string Ulica
        {
            get => _ulica; set
            {
                if (value != _ulica) _ulica = value;
                OnPropertyChanged("Ulica");
            }
        }

        public string BrojTelefona
        {
            get => _brojTelefona; set
            {
                if (value != _brojTelefona) _brojTelefona = value;
                OnPropertyChanged("BrojTelefona");
            }
        }

        public string eMail
        {
            get => _eMail; set
            {
                if (value != _eMail) _eMail = value;
                OnPropertyChanged("eMail");
            }
        }

        public string Sifra
        {
            get;
            set;
        }

        public AccountModel(string ime, string prezime, string ir, string dr, string jmbg, string pol, string drzava, string grad, string ulica, string brojT, string email)
        {
            Ime = ime;
            Prezime = prezime;
            ImeRoditelja = ir;
            DatumRodjenja = dr;
            JMBG = jmbg;
            Pol = pol;
            Drzava = drzava;
            Grad = grad;
            Ulica = ulica;
            BrojTelefona = brojT;
            eMail = email;
            Termini = new List<TerminiModel>();
            IstorijaBolesti = new List<IstorijaBolestiModel>();
            Sifra = "";
        }

        public AccountModel(string ime, string prezime, string ir, string dr, string jmbg, string pol, string drzava, string grad, string ulica, string brojT, string email, string sifra)
        {
            Ime = ime;
            Prezime = prezime;
            ImeRoditelja = ir;
            DatumRodjenja = dr;
            JMBG = jmbg;
            Pol = pol;
            Drzava = drzava;
            Grad = grad;
            Ulica = ulica;
            BrojTelefona = brojT;
            eMail = email;
            Termini = new List<TerminiModel>();
            IstorijaBolesti = new List<IstorijaBolestiModel>();
            Sifra = sifra;
        }

    }
}
