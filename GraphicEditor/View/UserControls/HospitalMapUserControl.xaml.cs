using GraphicEditor.ViewModel;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for HospitalMapUserControl.xaml
    /// </summary>
    public partial class HospitalMapUserControl : UserControl
    {
        public HospitalMapUserControl()
        {
            this.DataContext = MapContentUserControlViewModel.HospitalMap;
            InitializeComponent();
        }


        //private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    /*IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);

        //    if (focusedControl is Control)
        //    {
        //        string str = HelpProvider.GetHelpKey((Control)focusedControl);
        //        HelpProvider.ShowHelp(str, this);
        //    } 
        //    else*/
        //    if (this.IsVisible && this.IsEnabled)
        //    {
        //        string str = HelpProvider.GetHelpKey(this);
        //        HelpProvider.ShowHelp(str, this);
        //    }

        //}
    }
}
