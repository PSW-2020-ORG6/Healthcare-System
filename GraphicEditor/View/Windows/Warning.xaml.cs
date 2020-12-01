using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for Warning.xaml
    /// </summary>
    public partial class Warning : Window
    {
        public string TypeOfUser { get; private set; }
        public Warning()
        {
            this.DataContext = this;
            TypeOfUser = MainWindow.TypeOfUser.ToString();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
