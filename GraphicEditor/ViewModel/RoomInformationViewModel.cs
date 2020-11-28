using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using Model.Hospital;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor.ViewModel
{
    public class RoomInformationViewModel : BindableBase
    {
        private Window window;

        private List<Bed> beds = new List<Bed>();

        private Bed selectedBed;

        public MyICommand<Bed> NavCommandUpdate { get; private set; }

        public MyICommand NavCommandExit { get; private set; }

        public Bed BedInfo
        {
            get => selectedBed;
            set
            {
                if (value != null)
                    SetProperty(ref selectedBed, value);
            }
        }

        public List<Bed> Beds
        {
            get => beds;
            set
            {
                SetProperty(ref beds, value);

            }
        }

        public RoomInformationViewModel(Window _window)
        {
            NavCommandExit = new MyICommand(exitInfo);
            NavCommandUpdate = new MyICommand<Bed>(updateBedInfo);

            window = _window;

            beds.Add(new Bed("Bed 1", "bed01"));
            beds.Add(new Bed("Bed 2", "bed02"));
            beds.Add(new Bed("Bed 3", "bed03"));
            beds.Add(new Bed("Bed 4", "bed04"));
            beds.Add(new Bed("Bed 5", "bed05"));

            selectedBed = beds[0];

        }

        void updateBedInfo(Bed bedInfo)
        {
            Bed p = new Bed(BedInfo.Name, BedInfo.Id);
            BedUpdate w = new BedUpdate(p);
            w.ShowDialog();
            BedInfo.Id = p.Id;
            BedInfo.Name = p.Name;
            OnPropertyChanged("BedInfo");
        }

        void exitInfo()
        {
            window.Close();
        }
    }
}
