using GraphicEditor.HelpClasses;
using System;

namespace GraphicEditor.ViewModel
{
    public class HospitalMapUserControlViewModel : BindableBase
    {
        private string _text = "AutoHook WORKS!!!!Changed colour :))";

        public String RandomText
        {
            get => _text;
            set
            {
                OnPropertyChanged(RandomText);
            }
        }
    }
}
