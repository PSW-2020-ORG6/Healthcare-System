using GraphicEditor.HelpClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.ViewModel
{
    public class HospitalMapUserControlViewModel : BindableBase
    {
        private string _text = "AutoHook WORKS!!!!";

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
