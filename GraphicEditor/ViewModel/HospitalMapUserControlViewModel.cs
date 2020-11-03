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
                case Constants.EMERGENCY:
                    
                    break;
                case Constants.CARDIOLOGY:

                    break;
                case Constants.ORTHOPEDICS:

                    break;
                case Constants.PEDIATRICS:

                    break;
                case Constants.DERMATOLOGY:

                    break;
                case Constants.ONCOLOGY:

                    break;
            }
        }
    }
}
