using GraphicEditor.HelpClasses;
using Model.Hospital;
using System.Windows;

namespace GraphicEditor.ViewModel
{
    public class BedUpdateViewModel : BindableBase
    {
        private Window _window;
        private Bed _bed;
        private Bed _bedOriginal;

        public MyICommand NavCommandUpdate { get; private set; }

        public MyICommand NavCommandExit { get; private set; }

        public Bed BedInfo
        {
            get => _bed;
            set
            {
                if (value != null)
                    SetProperty(ref _bed, value);
            }
        }

        public BedUpdateViewModel(Window window, Bed _bedInfo)
        {
            _window = window;
            _bed = _bedInfo;
            _bedOriginal = new Bed(_bed.Name, _bed.Id);

            NavCommandExit = new MyICommand(exitInfo);
            NavCommandUpdate = new MyICommand(updateRoomInfo);
        }


        void updateRoomInfo()
        {
            _window.Close();
        }

        void exitInfo()
        {
            BedInfo.Id = _bedOriginal.Id;
            BedInfo.Name = _bedOriginal.Name;
            OnPropertyChanged("BedInfo");
            _window.Close();
        }

    }
}
