using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;
using Model.Hospital;
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

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for RoomUpdate.xaml
    /// </summary>
    public partial class RoomUpdate : Window
    {
        public RoomUpdate(Room room, DialogAnswerListener<Room> dialogAnswerListener)
        {
            this.DataContext = new RoomUpdateViewModel(this, room, dialogAnswerListener);
            InitializeComponent();
        }
    }
}
