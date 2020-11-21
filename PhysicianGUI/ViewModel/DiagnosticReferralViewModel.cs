using Backend.Controller.PhysitianControllers;
using Model.Accounts;
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
using health_clinic_class_diagram.Backend.Controller.PhysitianControllers;

namespace HealthClinic.ViewModel
{
    class DiagnosticReferralViewModel : ViewModelBase
    {
        private YesNoDialog submitDialog;
        private YesNoDialog cancelDialog;

        private DiagnosticType diagnosticType;
        private string notes;
        private bool urgency;

        private ObservableCollection<DiagnosticType> diagnosticTypes;
        private bool isNewDocument;

        private PhysitianHospitalController physitianHospitalController;

        public int DiagnosticType
        {
            get
            {
                for(int i = 0; i < diagnosticTypes.Count; i++)
                {
                    if(diagnosticType.Equals(diagnosticTypes[i]))
                    {
                        return i;
                    }
                }

                return 0;
            }
            set
            {
                diagnosticType = diagnosticTypes[value];
                RaisePropertyChanged("DiagnosticType");
            }
        }
        public string Notes { get => notes; set => notes = value; }
        public ObservableCollection<DiagnosticType> DiagnosticTypes { get => diagnosticTypes; set => diagnosticTypes = value; }

        public DiagnosticReferralViewModel()
        {
            isNewDocument = true;
            Physitian loggedPhysitian = (Physitian)Application.Current.Properties["LoggedPhysitian"];
            physitianHospitalController = new PhysitianHospitalController();

            ObservableListConverter<DiagnosticType> converter = new ObservableListConverter<DiagnosticType>();
            diagnosticTypes = converter.ToObservable(physitianHospitalController.GetDiagnosticTypes());
            diagnosticType = diagnosticTypes[0];
        }

        public DiagnosticReferralViewModel(DiagnosticReferral diagnosticReferral)
        {
            isNewDocument = false;
            Physitian loggedPhysitian = (Physitian)Application.Current.Properties["LoggedPhysitian"];
            physitianHospitalController = new PhysitianHospitalController();

            ObservableListConverter<DiagnosticType> converter = new ObservableListConverter<DiagnosticType>();
            diagnosticTypes = converter.ToObservable(physitianHospitalController.GetDiagnosticTypes());

            this.diagnosticType = diagnosticReferral.DiagnosticType;
            this.notes = diagnosticReferral.Notes;
        }

        public ICommand CancelCommand
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
        public ICommand SubmitCommand
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
                        //TODO: zakaciti uput na report
                        DiagnosticReferral diagnosticReferral = new DiagnosticReferral(DateTime.Today, notes, diagnosticType);
                        //examController.NewDiagnosticReferral(diagnosticReferral);
                        Messenger.Default.Send<AddDocumentMessage>(new AddDocumentMessage { document = diagnosticReferral });
                    }
                    if (cancelDialog != null)
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

        public bool Urgency { get => urgency; set => urgency = value; }
        public bool IsNewDocument { get => isNewDocument; }
    }
}
