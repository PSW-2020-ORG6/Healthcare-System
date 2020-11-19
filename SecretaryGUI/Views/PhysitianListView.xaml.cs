using GalaSoft.MvvmLight.Messaging;
using HCI_SIMS_PROJEKAT.Messages;
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

namespace HCI_SIMS_PROJEKAT.Views
{
    /// <summary>
    /// Interaction logic for PhysitianListView.xaml
    /// </summary>
    public partial class PhysitianListView : UserControl
    {
        public PhysitianListView(String styleName)
        {
            InitializeComponent();
            switch (styleName)
            {
                case "SkyBlue":
                    Resources["panelStyle"] = Application.Current.Resources["WhitePanel"];
                    Resources["tableStyle"] = Application.Current.Resources["tableWhite"];
                    Resources["textStyle"] = Application.Current.Resources["WhiteLabelForText"];
                    break;
                case "DarkPurple":
                    Resources["panelStyle"] = Application.Current.Resources["DarkPanel"];
                    Resources["tableStyle"] = Application.Current.Resources["tableDark"];
                    Resources["textStyle"] = Application.Current.Resources["DarkLabelForText"];
                    break;
            }

        }

        private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scrollViewerPhysitian.ScrollToVerticalOffset(scrollViewerPhysitian.VerticalOffset - e.Delta);
        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Messenger.Default.Send<SearchPhysitianMessage>(new SearchPhysitianMessage { Pretraga = SearchText.Text });
        }
    }
}
