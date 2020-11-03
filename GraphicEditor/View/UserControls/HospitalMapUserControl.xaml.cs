using GraphicEditor.HelpClasses;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for HospitalMapUserControl.xaml
    /// </summary>
    public partial class HospitalMapUserControl : UserControl
    {
        public HospitalMapUserControl()
        {
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
