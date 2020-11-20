using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;

namespace klinika_zdravo.Pages
{
    /// <summary>
    /// Interaction logic for IstorijaBolestiStranica.xaml
    /// </summary>
    public partial class IstorijaBolestiStranica : Page
    {
        public ObservableCollection<IstorijaBolestiModel> IstorijaBolesti
        {
            set;
            get;
        }

        public IstorijaBolestiStranica()
        {
            InitializeComponent();
            this.DataContext = this;
            IstorijaBolesti = new ObservableCollection<IstorijaBolestiModel>();
            if (AccountModel.accountModel.IstorijaBolesti.Any())
            {
                foreach(IstorijaBolestiModel ib in AccountModel.accountModel.IstorijaBolesti)
                {
                    IstorijaBolesti.Add(ib);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dialogRecept.IsOpen = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (AccountModel.accountModel.Ime.Equals("Vladimir"))
            {
                dijalog1.IsOpen = true;
            }
            else
            {
                dialogNegacija.IsOpen = true;
            }
            
        }
    }
}
