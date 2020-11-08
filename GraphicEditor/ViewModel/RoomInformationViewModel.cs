using GraphicEditor.HelpClasses;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace GraphicEditor.ViewModel
{
    public class RoomInformationViewModel:BindableBase
    {
        public MyICommand<ComboBox> ComboCommand { get; private set; }

        private static RoomInformationViewModel _instance;

        private List<string> beds=new List<string>();

        private string selectedBed;

        private string bedInfo;

        public string BedInfo
        {
            get => bedInfo;
            set
            {
                SetProperty(ref bedInfo, value);

            }
        }
        public string SelectedBed
        {
            get => selectedBed;
            set
            {
                SetProperty(ref selectedBed, value);
                if (value.Equals("Bed1"))
                {
                    BedInfo = "Pacijent: \n ime :Petar \nPrezime: Petrovic \n Lezao: 2 dana \n Bolest: prehlada";
                }else if (value.Equals("Bed2"))
                {
                    BedInfo = "Pacijent: \n ime :Dusan \nPrezime: Lazarevic \n Lezao: 3 dana \n Bolest: prehlada";
                }
                else if (value.Equals("Bed3"))
                {
                    BedInfo = "Pacijent: \n ime :Marko \nPrezime: Markovic\n Lezao: 4 dana \n Bolest: prehlada";
                }
            }

        }
        public List<string> Beds
        {
            get => beds;
            set
            {
                SetProperty(ref beds, value);
                
            }
        }


        public static RoomInformationViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RoomInformationViewModel();
            }
            return _instance;
        }

        public void changedSelection(ComboBox comboBox)
        {
            Console.WriteLine("promenaaaa :"+comboBox.Text);
        }
        private RoomInformationViewModel()
        {
            ComboCommand = new MyICommand<ComboBox>(changedSelection);
            beds.Add("Bed1");
            beds.Add("Bed2");
            beds.Add("Bed3");
            SelectedBed = beds[0];
        }
    }
}
