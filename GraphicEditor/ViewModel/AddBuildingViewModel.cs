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

        public string NameText { get; set; }

        public Color MyButtonColor { get; set; }

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
            switch (Shapes)
            {
                case 0:
                    SettingButtonLook("TriangleBuildingButtonStyle");
                    break;
                case 1:
                    SettingButtonLook("UBuildingButtonStyle");
                    break;
                case 2:
                    SettingButtonLook("OctagonBuildingButtonStyle");
                    break;
                case 3:
                    SettingButtonLook("DermatologyBuildingButtonStyle");
                    break;
                case 4:
                    SettingButtonLook("RectangleBuildingButtonStyle");
                    break;
            }
            Window.Close();
        }

        private void SettingButtonLook(string buildingButtonStyle)
        {
            Button.Style = (Style)myResourceDictionary[buildingButtonStyle];
            Button.Background = new SolidColorBrush(MyButtonColor); 
            Button.Name = NameText;
        }
    }
}
