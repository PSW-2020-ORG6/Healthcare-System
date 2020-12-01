using GraphicEditor.HelpClasses;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    class AddBuildingViewModel : BindableBase
    {
        public MyICommand<object> AddCommand { get; private set; }

        public Window Window { get; set; }

        ResourceDictionary myResourceDictionary = new ResourceDictionary();

        public int Shapes { get; set; }

        public string nameText { get; set; }

        public System.Windows.Media.Color MyButtonColor { get; set; }

        public Button Button { get; set; }
        public AddBuildingViewModel(Window window, Button but)
        {
            Window = window;
            Button = but;
            AddCommand = new MyICommand<object>(AddBuilding);
            myResourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);
        }

        private void AddBuilding(object obj)
        {
            Button.Name = nameText;
            switch (Shapes)
            {
                case 0:
                    Button.Style = (Style)myResourceDictionary["TriangleBuildingButtonStyle"];
                    Button.Background = new SolidColorBrush(MyButtonColor);
                    break;
                case 1:
                    Button.Style = (Style)myResourceDictionary["UBuildingButtonStyle"];
                    Button.Background = new SolidColorBrush(MyButtonColor);
                    break;
                case 2:
                    Button.Style = (Style)myResourceDictionary["OctagonBuildingButtonStyle"];
                    Button.Background = new SolidColorBrush(MyButtonColor);
                    break;
                case 3:
                    Button.Style = (Style)myResourceDictionary["DermatologyBuildingButtonStyle"];
                    Button.Background = new SolidColorBrush(MyButtonColor);
                    break;
                case 4:
                    Button.Style = (Style)myResourceDictionary["RectangleBuildingButtonStyle"];
                    Button.Background = new SolidColorBrush(MyButtonColor);
                    break;
            }
            Window.Close();
        }

    }
}
