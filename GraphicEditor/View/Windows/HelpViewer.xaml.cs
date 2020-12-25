using GraphicEditor.HelpClasses;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for HelpViewer.xaml
    /// </summary>
    public partial class HelpViewer : Window
    {
        private JavaScriptControlHelper controlHelper;

        public HelpViewer(string key, Window originator)
        {
            InitializeComponent();
            string currentDirectory = Directory.GetCurrentDirectory();
            currentDirectory = currentDirectory.Replace("\\bin\\Debug\\netcore3.1", "");
            string path = String.Format("{0}/HtmlHelpPages/{1}.html", currentDirectory, key);
            if (!File.Exists(path))
            {
                key = "Error";
            }
            Uri u = new Uri(String.Format("file:///{0}/HtmlHelpPages/{1}.html", currentDirectory, key));
            controlHelper = new JavaScriptControlHelper(originator);
            wbHelp.ObjectForScripting = controlHelper;
            wbHelp.Navigate(u);

        }

        private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbHelp != null) && (wbHelp.CanGoBack));
        }

        private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbHelp.GoBack();
        }

        private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbHelp != null) && (wbHelp.CanGoForward));
        }

        private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbHelp.GoForward();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //TODO
        }

        private void wbHelp_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            //TODO
        }
    }
}
