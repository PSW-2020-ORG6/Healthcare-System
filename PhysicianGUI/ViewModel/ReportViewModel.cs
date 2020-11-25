using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using HealthClinic.util;
using HealthClinic.View;
using Model.Accounts;
using Model.MedicalExam;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace HealthClinic.ViewModel
{
    public class ReportViewModel : ViewModelBase
    {
        private String _appointmentType;
        private Patient currentPatient;
        private Report currentReport;
        private bool isNewReport;

        private YesNoDialog submitDialog;
        private YesNoDialog cancelDialog;

        public ObservableCollection<AdditionalDocument> Documents
        {
            get
            {
                ObservableListConverter<AdditionalDocument> converter = new ObservableListConverter<AdditionalDocument>();
                return converter.ToObservable(CurrentReport.AdditionalDocument);
            }
        }


        public ReportViewModel(Report report, bool isNewReport)
        {
            this.IsNewReport = isNewReport;
            AppointmentType = "Pregled kod lekara opšte prakse";
            CurrentReport = report;
        }

        public string AppointmentType { get => _appointmentType; set => _appointmentType = value; }

        public ICommand CancelReportCommand
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

        public ICommand SubmitReportCommand
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
                        Messenger.Default.Send<SubmitReportMessage>(new SubmitReportMessage { Report = currentReport });
                        return;
                    }
                    if (cancelDialog != null)
                    {
                        cancelDialog.Close();
                        Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "PatientDetailView" });
                        return;
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

        public ICommand AddPrescriptionCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "PrescriptionView" });
                });
            }
        }

        public ICommand AddSpecialistReferralCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "SpecialistReferralView" });
                });
            }
        }

        public ICommand AddFollowUpCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "FollowUpView" });
                });
            }
        }

        public ICommand AddDiagnosticReferralCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "DiagnosticReferralView" });
                });
            }
        }

        public ICommand DisplayAddedDocumentsCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<DisplayAdditionalDocumentsMessage>(new DisplayAdditionalDocumentsMessage { });
                });
            }
        }

        internal Patient CurrentPatient { get => currentPatient; set => currentPatient = value; }
        public Report CurrentReport { get => currentReport; set => currentReport = value; }
        public bool IsNewReport { get => isNewReport; set => isNewReport = value; }

        public Visibility AddDocumentButtonVisibilityMode
        {
            get
            {
                if (isNewReport)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
    }
}
