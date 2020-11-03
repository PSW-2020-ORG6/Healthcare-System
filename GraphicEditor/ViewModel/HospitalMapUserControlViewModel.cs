using GraphicEditor.HelpClasses;
using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace GraphicEditor.ViewModel
{
    public class HospitalMapUserControlViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }

        public HospitalMapUserControlViewModel()
        {
            NavCommand = new MyICommand<string>(ChooseHospital);
        }

        private void ChooseHospital(string destination)
        {
            switch (destination)
            {
                case "emergency":
                    
                    break;
                case "cardiology":
                    
                    break;
                case "orthopedy":

                    break;
                case "pediatry":

                    break;
                case "dermatology":

                    break;
                case "oncology":

                    break;
            }
        }
    }
}
