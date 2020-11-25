using GalaSoft.MvvmLight.Messaging;
using HCI_SIMS_PROJEKAT.Messages;
using System;
using System.Windows;

namespace HCI_SIMS_PROJEKAT.Views
{
    /// <summary>
    /// Interaction logic for DeletePatientDialog.xaml
    /// </summary>
    public partial class DeletePatientDialog : Window
    {
        public DeletePatientDialog(String styleName)
        {
            InitializeComponent();

            switch (styleName)
            {
                case "SkyBlue":
                    Resources["buttonStyle"] = Application.Current.Resources["MenuButton"];
                    Resources["panelStyle"] = Application.Current.Resources["WhitePanel"];
                    Resources["textStyle"] = Application.Current.Resources["WhiteLabelForText"];
                    break;
                case "DarkPurple":
                    Resources["buttonStyle"] = Application.Current.Resources["DarkMenuButton"];
                    Resources["panelStyle"] = Application.Current.Resources["DarkPanel"];
                    Resources["textStyle"] = Application.Current.Resources["DarkLabelForText"];
                    break;
            }
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<ConfirmDeletePatientMessage>(new ConfirmDeletePatientMessage { });
            this.Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
