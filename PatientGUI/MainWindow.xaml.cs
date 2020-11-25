using klinika_zdravo.Model;
using klinika_zdravo.Pages;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace klinika_zdravo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PocetnaStranica pocetnaStranica = new PocetnaStranica();
        private ProfilnaStranica profilnaStranica = new ProfilnaStranica();
        private BlogStranica blogStranica = new BlogStranica();
        private KontaktiStranica kontaktiStranica = new KontaktiStranica();
        private GraphicEditor.MainWindow map = new GraphicEditor.MainWindow();
        private ZakazivanjePregledaStranica zakazivanjePregledaStranica = new ZakazivanjePregledaStranica();
        private ZakazaniTerminiStranica zakazaniTerminiStranica = new ZakazaniTerminiStranica();
        private ZdravstveniKartonStranica zdravstveniKartonStranica = new ZdravstveniKartonStranica();
        private IstorijaBolestiStranica istorijaBolestiStranica = new IstorijaBolestiStranica();
        private DemoSajtaStranica demoSajtaStranica = new DemoSajtaStranica();
        private PodesavanjeStranica podesavanjeStranica = new PodesavanjeStranica();

        private List<AccountModel> registrovani = new List<AccountModel>();

        bool ulogovan = false;

        public MainWindow()
        {
            InitializeComponent();
            registrovani.Add(new AccountModel("Vladimir", "Budjen", "Aleksandar", "01.01.1939", "0101939548967", "muski", "Sremska Kamenica", "Bocke", "Gavrila principa 39a", "064/958-45-17", "vladimirbudjen@gmail.com", "sifra"));
            registrovani.Add(new AccountModel("Pera", "Peric", "Petar", "01.02.1995", "1524885615485", "Muski", "Srbija", "Novi Sad", "Rumenacka 5", "064/8546-2525", "peraperic@gmail.com", "sifra"));
            AccountModel.accountModel = registrovani[0];
            AccountModel.accountModel.Termini.Add(new TerminiModel("pregled", "01.02.2020.", "15.45", "Gregory House", "415"));
            AccountModel.accountModel.Termini.Add(new TerminiModel("pregled", "01.02.2020.", "15.10", "ASD House", "415"));
            AccountModel.accountModel.Termini.Add(new TerminiModel("asdgb", "01.02.2020.", "15.45", "Gregory House", "415"));
            AccountModel.accountModel.IstorijaBolesti.Add(new IstorijaBolestiModel("10.12.2016", "Dr Gregory House", "Influencae", "Piti dosta caja"));

        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PocetnaClick(object sender, RoutedEventArgs e)
        {

            MainFrame.Content = pocetnaStranica;


        }

        private void ProfilClick(object sender, RoutedEventArgs e)
        {
            if (ulogovan)
            {
                MainFrame.Content = new ProfilnaStranica();
            }
            else
            {
                dijalogUpozorenje.IsOpen = true;
            }

        }

        private void BlogClick(object sender, RoutedEventArgs e)
        {
            if (ulogovan)
            {
                MainFrame.Content = blogStranica;
            }
            else
            {
                dijalogUpozorenje.IsOpen = true;
            }
        }

        private void KontaktiClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = kontaktiStranica;
        }

        private void MapClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            map.ShowDialog();
        }

        private void MenuOpen(object sender, RoutedEventArgs e)
        {
            ButtonOpen.Visibility = Visibility.Hidden;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void MenuClose(object sender, RoutedEventArgs e)
        {
            ButtonOpen.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Hidden;
        }



        /*private void FocusOnSearch(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
        }

        private void LostFocusOnSearch(object sender, RoutedEventArgs e)
        {
            if(SearchTextBox.Text == "")
            {
                SearchTextBox.Text = "pretraga";
            }
        }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ulogovan)
            {
                MainFrame.Content = zakazivanjePregledaStranica;
            }
            else
            {
                dijalogUpozorenje.IsOpen = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ulogovan)
            {
                //MainFrame.Content = zakazaniTerminiStranica;
                MainFrame.Content = new ZakazaniTerminiStranica();
            }
            else
            {
                dijalogUpozorenje.IsOpen = true;
            }
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (ulogovan)
            {
                //MainFrame.Content = istorijaBolestiStranica;
                MainFrame.Content = new IstorijaBolestiStranica();
            }
            else
            {
                dijalogUpozorenje.IsOpen = true;
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            MainFrame.Content = demoSajtaStranica;

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (ulogovan)
            {
                MainFrame.Content = podesavanjeStranica;
            }
            else
            {
                dijalogUpozorenje.IsOpen = true;
            }
        }

        private void prihvatiBTN_Click(object sender, RoutedEventArgs e)
        {
            /*odjavaBTN.Visibility = Visibility.Visible;
            prihvatiBTN.Visibility = Visibility.Hidden;
            pogresanMailDialog.IsOpen = true;
            ulogovan = true;*/
            //BoxEmailPrijava
            //BoxSifraPrijava
            bool moze1 = false;
            bool moze2 = false;
            foreach (AccountModel ac in registrovani)
            {
                if (ac.eMail.Equals(BoxEmailPrijava.Text))
                {
                    AccountModel.accountModel = ac;
                    moze1 = true;
                    if (ac.Sifra.Equals(BoxSifraPrijava.Text))
                    {
                        moze2 = true;
                    }
                    break;
                }
            }
            if (moze1 && moze2)
            {
                odjavaBTN.Visibility = Visibility.Visible;
                prihvatiBTN.Visibility = Visibility.Hidden;
                prviDijalog.IsOpen = false;
                ulogovan = true;
            }
            else if (!moze1)
            {
                pogresanMailDialog.IsOpen = true;
                return;
            }
            else if (!moze2)
            {
                pogresnaSifraDialog.IsOpen = true;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            odjavaBTN.Visibility = Visibility.Hidden;
            prihvatiBTN.Visibility = Visibility.Visible;
            ulogovan = false;
            MainFrame.Content = pocetnaStranica;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            dijalogRegistracija.IsOpen = true;
            prviDijalog.IsOpen = false;

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            string pol = "";
            if (radioMusko.IsChecked == true)
            {
                pol = "Musko";
            }
            if (radioZensko.IsChecked == true)
            {
                pol = "Zensko";
            }

            bool unetiPodaci = true;
            if (radioZensko.IsChecked == false && radioMusko.IsChecked == false)
            {
                polTextblock.Background = Brushes.LightBlue;
                unetiPodaci = false;
            }
            if (boxIme.Text.Equals(""))
            {
                boxIme.Background = Brushes.LightBlue;
                unetiPodaci = false;
            }
            if (boxPrezime.Text.Equals(""))
            {
                boxPrezime.Background = Brushes.LightBlue;
                unetiPodaci = false;
            }
            if (boxRoditelj.Text.Equals(""))
            {
                boxRoditelj.Background = Brushes.LightBlue;
                unetiPodaci = false;
            }
            if (boxDatum.Text.Equals(""))
            {
                boxDatum.Background = Brushes.LightBlue;
                unetiPodaci = false;
            }
            if (boxJmbg.Text.Equals(""))
            {
                boxJmbg.Background = Brushes.LightBlue;
                unetiPodaci = false;
            }
            if (boxDrzava.Text.Equals(""))
            {
                boxDrzava.Background = Brushes.LightBlue;
                unetiPodaci = false;
            }
            if (boxGrad.Text.Equals(""))
            {
                boxGrad.Background = Brushes.LightBlue;
                unetiPodaci = false;
            }
            if (boxUlica.Text.Equals(""))
            {
                boxUlica.Background = Brushes.LightBlue;
                unetiPodaci = false;
            }
            if (boxBroj.Text.Equals(""))
            {
                boxBroj.Background = Brushes.LightBlue;
                unetiPodaci = false;
            }
            if (boxEmail.Text.Equals(""))
            {
                boxEmail.Background = Brushes.LightBlue;
                unetiPodaci = false;
            }
            if (boxSifra.Text.Equals(""))
            {
                boxSifra.Background = Brushes.LightBlue;
                unetiPodaci = false;

            }
            if (unetiPodaci)
            {
                ulogovan = true;
                MainFrame.Content = pocetnaStranica;
                registrovani.Add(new AccountModel(boxIme.Text, boxPrezime.Text, boxRoditelj.Text, boxDatum.Text, boxJmbg.Text, pol, boxDrzava.Text, boxGrad.Text, boxUlica.Text, boxBroj.Text, boxEmail.Text, "sifra"));
                AccountModel.accountModel = new AccountModel(boxIme.Text, boxPrezime.Text, boxRoditelj.Text, boxDatum.Text, boxJmbg.Text, pol, boxDrzava.Text, boxGrad.Text, boxUlica.Text, boxBroj.Text, boxEmail.Text);
                odjavaBTN.Visibility = Visibility.Visible;
                prihvatiBTN.Visibility = Visibility.Hidden;
                dijalogRegistracija.IsOpen = false;
            }
            else
            {
                pogresniPodaciRegistracija.IsOpen = true;
            }
        }

        private void FocusOnEmail(object sender, RoutedEventArgs e)
        {
            if (BoxEmailPrijava.Text == "e-mail")
            {
                BoxEmailPrijava.Text = "";
            }
        }

        private void FocusOnPassword(object sender, RoutedEventArgs e)
        {
            if (BoxSifraPrijava.Text == "sifra")
            {
                BoxSifraPrijava.Text = "";
            }
        }

        private void LostFocusOnPassword(object sender, RoutedEventArgs e)
        {
            if (BoxSifraPrijava.Text == "")
            {
                BoxSifraPrijava.Text = "sifra";
            }
        }

        private void LostFocusOnEmail(object sender, RoutedEventArgs e)
        {
            if (BoxEmailPrijava.Text == "")
            {
                BoxEmailPrijava.Text = "e-mail";
            }
        }

        private void prijaviSeBtnClick(object sender, RoutedEventArgs e)
        {
            BoxSifraPrijava.Text = "sifra";
            BoxEmailPrijava.Text = "e-mail";
        }


        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (ulogovan)
            {
                MainFrame.Content = new BrzoZakazivanjeStranica();
            }
            else
            {
                dijalogUpozorenje.IsOpen = true;
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = demoSajtaStranica;
            dijalogUpozorenje.IsOpen = false;
        }
    }
}
