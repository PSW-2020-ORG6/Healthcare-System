using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView(String styleName)
        {
            InitializeComponent();
            switch (styleName)
            {
                case "SkyBlue":
                    Resources["panelStyle"] = Application.Current.Resources["WhitePanel"];
                    Resources["textBlockStyle"] = Application.Current.Resources["TextBlockWhite"];
                    Application.Current.Resources["textStyle"] = Application.Current.Resources["WhiteLabelForText"];
                    break;
                case "DarkPurple":
                    Resources["panelStyle"] = Application.Current.Resources["DarkPanel"];
                    Resources["textBlockStyle"] = Application.Current.Resources["TextBlockDark"];
                    Application.Current.Resources["textStyle"] = Application.Current.Resources["DarkLabelForText"];
                    break;
            }
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RichTextBox_TextLoad()
        {
       
        }
    }
}
