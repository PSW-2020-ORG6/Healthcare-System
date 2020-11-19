using Backend.Controller.PhysitianControllers;
using Model.Accounts;
using Model.Hospital;
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
    class MainWindowViewModel : ViewModelBase
    {
        private bool isSideMenuEnabled;
        private AdditionalDocument selectedDocument;
        private FrameworkElement _contentControlView;
        private AddedDocumentsDialog addedDocumentsDialog;

        private Patient currentPatient;
        private Report currentReport;
        private bool displayDocument;
        private bool isNewReport;

        private Medicine selectedMedicine;

        private ExamController examController;

        public FrameworkElement ContentControlView
        {
            get { return _contentControlView; }
            set
            {
                _contentControlView = value;
                RaisePropertyChanged("ContentControlView");
            }
        }

        public bool IsDeleteButtonEnabled
        {
            get
            {
                return isNewReport && IsDocumentSelected;
            }
        }

        public MainWindowViewModel()
        {
            Messenger.Default.Register<SwitchViewMessage>(this, (switchViewMessage) =>
            {
                displayDocument = false;
                SwitchView(switchViewMessage.ViewName);
            });

            Messenger.Default.Register<SubmitReportMessage>(this, (submitReportMessage) =>
            {
                examController.CurrentReport = submitReportMessage.Report;
                examController.SaveReport();
                SwitchView("PatientDetailView");
            });

            Messenger.Default.Register<AddDocumentMessage>(this, (addDocumentMessage) =>
            {
                currentReport.AddAdditionalDocument(addDocumentMessage.document);
                SwitchView("ReportView");
            });

            Messenger.Default.Register<DisplayAdditionalDocumentsMessage>(this, (displayAdditionalDocumentsMessage) =>
            {
                addedDocumentsDialog = new AddedDocumentsDialog();
                addedDocumentsDialog.DataContext = this;
                addedDocumentsDialog.Owner = Application.Current.MainWindow;
                addedDocumentsDialog.ShowDialog();
            });

            Messenger.Default.Register<ViewPatientInfoMessage>(this, (viewPatientInfoMessage) =>
            {
                currentPatient = viewPatientInfoMessage.Patient;
                SwitchView("PatientDetailView");
            });

            Messenger.Default.Register<StartExamMessage>(this, (startExamMessage) =>
            {
                examController = new ExamController(startExamMessage.Appointment);
                currentReport = examController.CurrentReport;
                isNewReport = true;
                SwitchView("ReportView");
            });

            Messenger.Default.Register<ViewReportMessage>(this, (viewReportMessage) =>
            {
                currentReport = viewReportMessage.Report;
                isNewReport = false;
                SwitchView("ReportView");
            });

            Messenger.Default.Register<OpenMedicineApprovalViewMessage>(this, (openMedicineApprovalViewMessage) =>
            {
                selectedMedicine = openMedicineApprovalViewMessage.Medicine;
                SwitchView("MedicineApprovalView");
            });

            Messenger.Default.Register<OpenMedicineDetailViewMessage>(this, (openMedicineDetailViewMessage) =>
            {
                selectedMedicine = openMedicineDetailViewMessage.Medicine;
                SwitchView("MedicineDetailView");
            });

            SwitchView("default");
        }

        public ICommand OpenHospitalEditorCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    // TODO: Open hospital editor 
                });
            }
        }


        public ICommand ChangeCalendarViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SwitchView("CalendarDayView");

                });
            }
        }

        public ICommand ChangePatientViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SwitchView("PatientView");

                });
            }
        }

        public ICommand ChangeMedicineViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SwitchView("MedicineView");

                });
            }
        }

        public ICommand CloseAppCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Application.Current.Shutdown();
                });
            }
        }

        public ICommand CloseAdditionalDocumentsDialogCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SelectedDocument = null;
                    addedDocumentsDialog.Close();
                });
            }
        }
        public ICommand OpenDocumentCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SpecialistReferral specialistReferral = selectedDocument as SpecialistReferral;
                    DiagnosticReferral diagnosticReferral = selectedDocument as DiagnosticReferral;
                    Prescription prescription = selectedDocument as Prescription;
                    FollowUp followUp = selectedDocument as FollowUp;
                    displayDocument = true;

                    if (specialistReferral != null)
                    {
                        SwitchView("SpecialistReferralView");
                    }
                    if(diagnosticReferral != null)
                    {
                        SwitchView("DiagnosticReferralView");
                    }
                    if(prescription != null)
                    {
                        SwitchView("PrescriptionView");
                    }
                    if(followUp != null)
                    {
                        SwitchView("FollowUpView");
                    }

                    addedDocumentsDialog.Close();
                });
            }
        }

        public ICommand DeleteDocumentCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    currentReport.RemoveAdditionalDocument(selectedDocument);
                    RaisePropertyChanged("Documents");
                });
            }
        }

        public bool IsSideMenuEnabled
        {
            get
            {
                return isSideMenuEnabled;
            }
            set
            {
                isSideMenuEnabled = value;
                RaisePropertyChanged("IsSideMenuEnabled");
            }
        }

        internal Patient CurrentPatient { get => currentPatient; set => currentPatient = value; }
        public Report CurrentReport
        {
            get
            {
                return currentReport;
            }
            set
            {
                currentReport = value;
            }
        }

        public AdditionalDocument SelectedDocument
        {
            get
            {
                return selectedDocument;
            }
            set
            {
                selectedDocument = value;
                RaisePropertyChanged("IsDeleteButtonEnabled");
                RaisePropertyChanged("IsDocumentSelected");
            }
        }
        public bool IsDocumentSelected
        {
            get
            {
                return selectedDocument != null;
            }
        }

        public ObservableCollection<AdditionalDocument> Documents
        {
            get
            {
                ObservableListConverter<AdditionalDocument> converter = new ObservableListConverter<AdditionalDocument>();
                return converter.ToObservable(currentReport.AdditionalDocument);
            }
        }

        private void SwitchView(object viewName)
        {
            switch (viewName)
            {
                case "HomeView":
                    ContentControlView = new PhysitianView();
                    ContentControlView.DataContext = new PhysitianViewModel();
                    IsSideMenuEnabled = true;
                    break;

                case "CalendarView":
                    ContentControlView = new CalendarView();
                    ContentControlView.DataContext = new CalendarViewModel();
                    IsSideMenuEnabled = true;
                    break;

                case "CalendarDayView":
                    ContentControlView = new CalendarDayView();
                    ContentControlView.DataContext = new CalendarDayViewModel();
                    IsSideMenuEnabled = true;
                    break;

                case "PatientView":
                    ContentControlView = new PatientView();
                    ContentControlView.DataContext = new PatientViewModel();
                    IsSideMenuEnabled = true;
                    break;

                case "MedicineView":
                    ContentControlView = new MedicineView();
                    ContentControlView.DataContext = new MedicineViewModel();
                    IsSideMenuEnabled = true;
                    break;

                case "MedicineApprovalView":
                    ContentControlView = new MedicineApprovalView();
                    ContentControlView.DataContext = new MedicineApprovalViewModel(selectedMedicine);
                    IsSideMenuEnabled = true;
                    break;

                case "MedicineDetailView":
                    ContentControlView = new MedicineDetailView();
                    ContentControlView.DataContext = new MedicineDetailViewModel(selectedMedicine);
                    IsSideMenuEnabled = true;
                    break;

                case "PatientDetailView":
                    ContentControlView = new PatientDetailView();
                    ContentControlView.DataContext = new PatientDetailViewModel(currentPatient);
                    IsSideMenuEnabled = true;
                    break;

                case "ReportView":
                    ContentControlView = new ReportView();
                    ContentControlView.DataContext = new ReportViewModel(currentReport, isNewReport);
                    IsSideMenuEnabled = false;
                    break;

                case "PrescriptionView":
                    ContentControlView = new PrescriptionView();
                    if(displayDocument)
                    {
                        ContentControlView.DataContext = new PrescriptionViewModel(selectedDocument as Prescription);
                    } else
                    {
                        ContentControlView.DataContext = new PrescriptionViewModel();
                    }
                    IsSideMenuEnabled = false;
                    break;

                case "SpecialistReferralView":
                    ContentControlView = new SpecialistReferralView();
                    if (displayDocument)
                    {
                        ContentControlView.DataContext = new SpecialistReferralViewModel(selectedDocument as SpecialistReferral);
                    } else
                    {
                        ContentControlView.DataContext = new SpecialistReferralViewModel(currentPatient);
                    }
                    IsSideMenuEnabled = false;
                    break;

                case "FollowUpView":
                    ContentControlView = new FollowUpView();
                    if(displayDocument)
                    {
                        ContentControlView.DataContext = new FollowUpViewModel(selectedDocument as FollowUp);
                    } else
                    {
                        ContentControlView.DataContext = new FollowUpViewModel(currentPatient);
                    }
                    IsSideMenuEnabled = false;
                    break;

                case "DiagnosticReferralView":
                    ContentControlView = new DiagnosticReferralView();
                    if(displayDocument)
                    {
                        ContentControlView.DataContext = new DiagnosticReferralViewModel(selectedDocument as DiagnosticReferral);
                    } else
                    {
                        ContentControlView.DataContext = new DiagnosticReferralViewModel();
                    }
                    IsSideMenuEnabled = false;
                    break;

                default:
                    ContentControlView = new PhysitianView();
                    ContentControlView.DataContext = new PhysitianViewModel();
                    IsSideMenuEnabled = true;
                    break;
            }
        }
    }
}
