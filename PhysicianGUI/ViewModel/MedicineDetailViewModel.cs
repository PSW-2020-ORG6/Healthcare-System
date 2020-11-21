using Model.Hospital;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using System.Windows.Input;

namespace HealthClinic.ViewModel
{
    class MedicineDetailViewModel : ViewModelBase
    {
        private Medicine medicine;
        public MedicineDetailViewModel(Medicine medicine)
        {
            this.Medicine = medicine;
        }

        public ICommand GoBackCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "MedicineView" });
                });
            }
        }

        public Medicine Medicine { get => medicine; set => medicine = value; }
    }
}