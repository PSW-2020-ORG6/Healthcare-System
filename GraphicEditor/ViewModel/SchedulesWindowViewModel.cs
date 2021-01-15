using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;

namespace GraphicEditor.ViewModel
{
    public class SchedulesWindowViewModel : BindableBase
    {
        private SchedulesWindow _window;

        public SchedulesWindowViewModel(SchedulesWindow window)
        {
            _window = window;
        }
    }
}
