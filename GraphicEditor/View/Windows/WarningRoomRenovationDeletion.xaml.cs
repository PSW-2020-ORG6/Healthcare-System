using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for WarningRoomRenovationDeletion.xaml
    /// </summary>
    public partial class WarningRoomRenovationDeletion : Window
    {
        public WarningRoomRenovationDeletion()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
