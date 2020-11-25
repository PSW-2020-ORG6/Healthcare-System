using Backend.Controller.PhysitianControllers;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using HealthClinic.View;
using Model.Accounts;
using Model.Hospital;
using System;
using System.Windows;
using System.Windows.Input;

namespace HealthClinic.ViewModel
{
    class MedicineApprovalViewModel
    {
        private Medicine medicine;
        private String rejectionReason;

        private PhysitianMedicineController physitianMedicineController;

        private YesNoDialog approveDialog;
        private RejectMedicineDialog rejectDialog;

        public MedicineApprovalViewModel(Medicine medicine)
        {
            this.Medicine = medicine;
            Physitian loggedPhysitian = (Physitian)Application.Current.Properties["LoggedPhysitian"];
            physitianMedicineController = new PhysitianMedicineController();
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

        public ICommand ApproveMedicineCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    approveDialog = new YesNoDialog();
                    approveDialog.DataContext = this;
                    approveDialog.Owner = Application.Current.MainWindow;
                    approveDialog.ShowDialog();
                });
            }
        }

        public ICommand RejectMedicineCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    rejectDialog = new RejectMedicineDialog();
                    rejectDialog.DataContext = this;
                    rejectDialog.Owner = Application.Current.MainWindow;
                    rejectDialog.ShowDialog();
                });
            }
        }

        public ICommand YesButtonCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (approveDialog != null)
                    {
                        approveDialog.Close();
                        approveDialog = null;
                        physitianMedicineController.Approve(medicine);
                        Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "MedicineView" });
                    }
                    if (rejectDialog != null)
                    {
                        rejectDialog.Close();
                        rejectDialog = null;
                        physitianMedicineController.Reject(new Rejection(rejectionReason, medicine));
                        Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "MedicineView" });
                    }

                });
            }
        }

        public ICommand NoButtonCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (approveDialog != null)
                    {
                        approveDialog.Close();
                        approveDialog = null;
                    }
                    if (rejectDialog != null)
                    {
                        rejectDialog.Close();
                        rejectDialog = null;
                    }
                });
            }
        }

        public Medicine Medicine { get => medicine; set => medicine = value; }
    }
}
