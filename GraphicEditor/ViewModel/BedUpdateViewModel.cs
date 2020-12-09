using GraphicEditor.HelpClasses;
using System.Windows;
using HealthClinicBackend.Backend.Model.Hospital;

namespace GraphicEditor.ViewModel
{
    public class BedUpdateViewModel : BindableBase
    {
        private Window _window;
        private Bed _bed;
        private Bed _bedOriginal;
        private DialogAnswerListener<Bed> _bedUpdateAnswerListener;

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

        public BedUpdateViewModel(Window window, Bed _bedInfo, DialogAnswerListener<Bed> bedUpdateAnswerListener)
        {
            _window = window;
            _bed = _bedInfo;
            _bedUpdateAnswerListener = bedUpdateAnswerListener;
            _bedOriginal = new Bed(_bed.Name, _bed.Id);

            NavCommandExit = new MyICommand(exitInfo);
            NavCommandUpdate = new MyICommand(updateRoomInfo);
        }


        void updateRoomInfo()
        {
            _bedUpdateAnswerListener.onConfirmUpdate(BedInfo);
            _window.Close();
        }

        void exitInfo()
        {
            _window.Close();
        }

    }
}
