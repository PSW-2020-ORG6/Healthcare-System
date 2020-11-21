using Model.MedicalExam;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using HealthClinic.util;
using HealthClinic.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HealthClinic.ViewModel
{
    public class PrescriptionViewModel : ViewModelBase
    {
        private bool _dataGridRowIsSelected;
        private YesNoDialog submitDialog;
        private YesNoDialog cancelDialog;
        private Prescription prescription;
        private bool isNewDocument;

        public ObservableCollection<MedicineDosage> AllMedicineDosage
        {
            get;
            set;
        }

        public bool DataGridRowIsSelected
        {
            get
            {
                return _dataGridRowIsSelected;
            }
            set
            {
                _dataGridRowIsSelected = value;
                RaisePropertyChanged("DataGridRowIsSelected");
            }
        }

        public PrescriptionViewModel()
        {
            AllMedicineDosage = new ObservableCollection<MedicineDosage>();
            this.isNewDocument = true;

            Messenger.Default.Register<AddMedicineDosageMessage>(this, (addMedicineDosageMessage) =>
            {
                AllMedicineDosage.Add(addMedicineDosageMessage.medicineDosage);
                RaisePropertyChanged("IsSubmitEnabled");
            });

            Messenger.Default.Register<DeleteMedicineDosageMessage>(this, (deleteMedicineDosageMessage) =>
            {
                AllMedicineDosage.Remove(deleteMedicineDosageMessage.medicineDosage);
                RaisePropertyChanged("IsSubmitEnabled");
            });

            Messenger.Default.Register<DataGridSelectionChangedMessage>(this, (dataGridSelectionChangedMessage) =>
            {
                DataGridRowIsSelected = dataGridSelectionChangedMessage.dataGridRowIsSelected;
            });
        }

        public PrescriptionViewModel(Prescription prescription)
        {
            this.prescription = prescription;
            this.isNewDocument = false;
            ObservableListConverter<MedicineDosage> converter = new ObservableListConverter<MedicineDosage>();
            AllMedicineDosage = converter.ToObservable(prescription.MedicineDosage);
        }

        public ICommand CancelPrescriptionCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    cancelDialog = new YesNoDialog();
                    cancelDialog.DataContext = this;
                    cancelDialog.Owner = Application.Current.MainWindow;
                    cancelDialog.ShowDialog();
                });
            }
        }

        public ICommand SubmitPrescriptionCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    submitDialog = new YesNoDialog();
                    submitDialog.DataContext = this;
                    submitDialog.Owner = Application.Current.MainWindow;
                    submitDialog.ShowDialog();
                });
            }
        }

        public ICommand YesButtonCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (submitDialog != null)
                    {
                        submitDialog.Close();
                        Prescription prescription = new Prescription(DateTime.Today, "");
                        foreach(MedicineDosage md in AllMedicineDosage)
                        {
                            prescription.AddMedicineDosage(md);
                        }
                        Messenger.Default.Send<AddDocumentMessage>(new AddDocumentMessage { document = prescription});
                    }
                    if(cancelDialog != null)
                    {
                        cancelDialog.Close();
                        Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "ReportView" });
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
                    if (submitDialog != null)
                    {
                        submitDialog.Close();
                    }
                    if (cancelDialog != null)
                    {
                        cancelDialog.Close();
                    }
                });
            }
        }

        public bool IsNewDocument { get => isNewDocument; }

        public bool IsSubmitEnabled
        {
            get
            {
                return isNewDocument && AllMedicineDosage.Count != 0;
            }
        }
    }
}
