using GalaSoft.MvvmLight.Messaging;
using HCI_SIMS_PROJEKAT.Messages;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
