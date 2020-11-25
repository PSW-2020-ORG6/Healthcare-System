using System;
using System.Windows;
using System.Windows.Controls;

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
