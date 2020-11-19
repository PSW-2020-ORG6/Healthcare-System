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
using System.Windows.Shapes;

namespace HCI_SIMS_PROJEKAT.Views
{
    /// <summary>
    /// Interaction logic for DeleteAppointmentDialog.xaml
    /// </summary>
    public partial class DeleteAppointmentDialog : Window
    {

        public DeleteAppointmentDialog(String styleName)
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

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<ConfirmDeleteAppointmentMessage>(new ConfirmDeleteAppointmentMessage { });
            this.Close();
        }
    }
}
