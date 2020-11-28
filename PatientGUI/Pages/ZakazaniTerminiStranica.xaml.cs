using klinika_zdravo.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace klinika_zdravo.Pages
{
    /// <summary>
    /// Interaction logic for ZakazaniTerminiStranica.xaml
    /// </summary>
    public partial class ZakazaniTerminiStranica : Page
    {
        public ObservableCollection<TerminiModel> Termini
        {
            get;
            set;
        }

        public ZakazaniTerminiStranica()
        {
            InitializeComponent();
            this.DataContext = this;
            Termini = new ObservableCollection<TerminiModel>();

            if (AccountModel.accountModel.Termini.Any())
            {
                foreach (TerminiModel tm in AccountModel.accountModel.Termini)
                {
                    Termini.Add(tm);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AccountModel.accountModel.Termini.Any())
            {
                AccountModel.accountModel.Termini.RemoveAt(dataGridTermini.SelectedIndex);
                Termini.RemoveAt(dataGridTermini.SelectedIndex);

            }
        }
    }
}
