using Backend.Controller.PhysitianControllers;
using Backend.Dto;
using Model.Accounts;
using Model.Hospital;
using Model.MedicalExam;
using Model.Schedule;
using Model.Util;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using HealthClinic.util;
using HealthClinic.View;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Font = iTextSharp.text.Font;

namespace HealthClinic.ViewModel
{
    class PatientDetailViewModel : ViewModelBase
    {
        private bool _dataGridRowIsSelected;

        private Patient patient;
        private ObservableCollection<Report> allReports;
        private ObservableCollection<Report> reports;
        private Report selectedReport;

        private List<Physitian> physitians;
        private List<ProcedureType> procedureTypes;
        private Physitian selectedPhysitian;
        private ProcedureType selectedProcedureType;

        private NewInpatientCareDialog newInpatientCareDialog;
        private ActiveInpatientCareDialog activeInpatientCareDialog;
        private InpatientCareHistoryDialog inpatientCareHistoryDialog;

        private List<Room> rooms;
        private List<Bed> beds;
        private Room selectedRoom;
        private Equipment selectedBed;
        private ObservableCollection<BedReservationDTO> previousInpatientCares;

        private PhysitianScheduleController physitianScheduleController;
        private PhysitianHospitalAccountsController physitianHospitalAccountsController;
        private InpatientCareController inpatientCareController;
        private ExamController examController;

        public bool IsDataGridRowSelected
        {
            get
            {
                return selectedReport != null;
            }
        }

        public PatientDetailViewModel(Patient patient)
        {
            this.patient = patient;
            
            Physitian loggedPhysitian = (Physitian)Application.Current.Properties["LoggedPhysitian"];
            physitianScheduleController = new PhysitianScheduleController(loggedPhysitian);
            physitianHospitalAccountsController = new PhysitianHospitalAccountsController(loggedPhysitian);
            inpatientCareController = new InpatientCareController(loggedPhysitian);

            ObservableListConverter<Report> converter = new ObservableListConverter<Report>();
            allReports = converter.ToObservable(physitianHospitalAccountsController.GetAllReportsForPatient(patient));
            reports = allReports;

            physitians = new List<Physitian>();
            procedureTypes = new List<ProcedureType>();

            physitians.Add(new Physitian("Svi", "Lekari", "invalid", DateTime.Today, "", "",  null, ""));
            procedureTypes.Add(new ProcedureType("Svi pregledi", 0, new Specialization("")));

            foreach(Report r in allReports)
            {
                if(!procedureTypes.Contains(r.ProcedureType))
                {
                    procedureTypes.Add(r.ProcedureType);
                }
                if(!physitians.Contains(r.Physitian))
                {
                    physitians.Add(r.Physitian);
                }
            }

            selectedPhysitian = physitians[0];
            selectedProcedureType = procedureTypes[0];

            rooms = inpatientCareController.GetAvailableRooms();
            selectedRoom = rooms[0];
            beds = inpatientCareController.GetAvailableBeds(rooms[0]);
            selectedBed = beds[0];

        }

        public ICommand ChangeToHomeViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "default" });
                });
            }
        }

        public ICommand NewReportCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Appointment appointment = physitianHospitalAccountsController.GetTodaysAppointmentForPatient(patient);
                    Messenger.Default.Send<StartExamMessage>(new StartExamMessage { Appointment = appointment });
                });
            }
        }

        public ICommand OpenReportCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<ViewReportMessage>(new ViewReportMessage { Report = selectedReport });
                });
            }
        }

        
        public ICommand GeneratePDFCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Document document = new Document(iTextSharp.text.PageSize.A4, 100, 10, 50, 10);
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("Izvestaj.pdf", FileMode.Create));
                    document.Open();
                    Font heading1 = new Font(Font.FontFamily.TIMES_ROMAN, 26);
                    Font heading2 = new Font(Font.FontFamily.TIMES_ROMAN, 22);
                    Font heading3 = new Font(Font.FontFamily.TIMES_ROMAN, 18);
                    Font paragraph = new Font(Font.FontFamily.TIMES_ROMAN, 16);
                    Paragraph blankLine = new Paragraph("\n");

                    Paragraph p1 = new Paragraph("Izveštaj " + SelectedReport.Date.ToString("dd.MM.yyyy."), heading1);
                    Paragraph p2 = new Paragraph(SelectedReport.ProcedureType.ToString(), heading2);
                    Paragraph p3 = new Paragraph("Lekar: " + SelectedReport.Physitian, heading3);
                    Paragraph p4 = new Paragraph("Pacijent: " + patient.Name + " " + patient.Surname, heading3);
                    Paragraph p5 = new Paragraph("JMBG: " + patient.Id, heading3);
                    
                    
                    Paragraph p6 = new Paragraph("Osnovne informacije:", heading3);
                    Paragraph p7 = new Paragraph(SelectedReport.PatientConditions, paragraph);
                    Paragraph p8 = new Paragraph("Nalaz:", heading3);
                    Paragraph p9 = new Paragraph(SelectedReport.Findings, paragraph);
                    document.Add(p1);
                    document.Add(p2);
                    document.Add(blankLine);
                    document.Add(p3);
                    document.Add(blankLine);
                    document.Add(p4);
                    document.Add(p5);
                    document.Add(blankLine);
                    document.Add(p6);
                    document.Add(p7);
                    document.Add(blankLine);
                    document.Add(p8);
                    document.Add(p9);
                    document.Add(blankLine);

                    foreach(AdditionalDocument additionalDocument in selectedReport.AdditionalDocument)
                    {
                        Paragraph adp1 = new Paragraph(additionalDocument.ToString(), heading2);
                        document.Add(adp1);
                        List<Paragraph> adps = getAdditionalDocumentDetails(additionalDocument);
                        foreach(Paragraph adp in adps)
                        {
                            document.Add(adp);
                        }
                        document.Add(blankLine);
                    }

                    document.Close();
                    System.Diagnostics.Process.Start("Izvestaj.pdf");
                });
            }
        }

        private List<Paragraph> getAdditionalDocumentDetails(AdditionalDocument additionalDocument)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();
            Font heading3 = new Font(Font.FontFamily.TIMES_ROMAN, 18);
            Font paragraph = new Font(Font.FontFamily.TIMES_ROMAN, 16);
            SpecialistReferral specialistReferral = additionalDocument as SpecialistReferral;
            if(specialistReferral != null)
            {
                Paragraph p1 = new Paragraph("Lekar kod kog je zakazan pregled: " + specialistReferral.Physitian, heading3);
                Paragraph p2 = new Paragraph("Razlog: " + specialistReferral.Notes, paragraph);
                paragraphs.Add(p1);
                paragraphs.Add(p2);
            }

            DiagnosticReferral diagnosticReferral = additionalDocument as DiagnosticReferral;
            if(diagnosticReferral != null)
            {
                Paragraph p1 = new Paragraph("Izdat uput za tip dijagnostike: " + diagnosticReferral.DiagnosticType.ToString(), heading3);
                Paragraph p2 = new Paragraph("Razlog: " + diagnosticReferral.Notes, paragraph);
                paragraphs.Add(p1);
                paragraphs.Add(p2);
            }

            Prescription prescription = additionalDocument as Prescription;
            if(prescription != null)
            {
                foreach(MedicineDosage md in prescription.MedicineDosage)
                {
                    Paragraph p = new Paragraph(md.Medicine + ": " + md.Amount + ", " + md.Note, paragraph);
                    paragraphs.Add(p);
                }
            }

            FollowUp followUp = additionalDocument as FollowUp;
            if(followUp != null)
            {
                Paragraph p1 = new Paragraph("Lekar kod kog je zakazana kontrola: " + followUp.Physitian, heading3);
                Paragraph p2 = new Paragraph("Razlog: " + followUp.Notes, paragraph);
                paragraphs.Add(p1);
                paragraphs.Add(p2);
            }
            return paragraphs;
        }

        public ICommand OpenNewInpatientCareDialogCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    newInpatientCareDialog = new NewInpatientCareDialog();
                    newInpatientCareDialog.DataContext = this;
                    newInpatientCareDialog.Owner = Application.Current.MainWindow;
                    newInpatientCareDialog.Show();
                });
            }
        }
        public ICommand CancelInpatientCare
        {
            get
            {
                return new RelayCommand(() =>
                {
                    newInpatientCareDialog.Close();
                });
            }
        }
        public ICommand AddInpatientCare
        {
            get
            {
                return new RelayCommand(() =>
                {
                    BedReservationDTO res = new BedReservationDTO();
                    res.Bed = selectedBed as Bed;
                    res.Patient = patient;
                    DateTime start = DateTime.Now;
                    res.TimeInterval = new TimeInterval(start, start.AddDays(10));
                    inpatientCareController.StartInpatientCare(res);
                    RaisePropertyChanged("IsInpatientCareActive");
                    RaisePropertyChanged("IsInpatientCareNotActive");
                    Rooms = inpatientCareController.GetAvailableRooms();
                    newInpatientCareDialog.Close();
                });
            }
        }
        
        public ICommand OpenActiveInpatientCareDialogCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    activeInpatientCareDialog = new ActiveInpatientCareDialog();
                    activeInpatientCareDialog.DataContext = this;
                    activeInpatientCareDialog.Owner = Application.Current.MainWindow;
                    activeInpatientCareDialog.Show();
                });
            }
        }
        public ICommand CloseActiveInpatientCareDialogCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    activeInpatientCareDialog.Close();
                });
            }
        }
        public ICommand DischargePatientCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    inpatientCareController.DischargeParient(patient);
                    RaisePropertyChanged("IsInpatientCareActive");
                    RaisePropertyChanged("IsInpatientCareNotActive");
                    Rooms = inpatientCareController.GetAvailableRooms();
                    activeInpatientCareDialog.Close();
                });
            }
        }
        public ICommand OpenInpatientCareHistoryDialogCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    inpatientCareHistoryDialog = new InpatientCareHistoryDialog();
                    inpatientCareHistoryDialog.DataContext = this;
                    inpatientCareHistoryDialog.Owner = Application.Current.MainWindow;
                    inpatientCareHistoryDialog.Show();
                });
            }
        }
        public ICommand CloseInpatientCareHistoryDialog
        {
            get
            {
                return new RelayCommand(() =>
                {
                    inpatientCareHistoryDialog.Close();
                });
            }
        }

        public Patient Patient { get => patient; set => patient = value; }
        public ObservableCollection<Report> Reports
        {
            get
            {
                return reports;
            }
            set
            {
                reports = value;
                RaisePropertyChanged("Reports");
            }
        }
        public bool IsNewReportEnabled
        {
            get
            {
                return physitianHospitalAccountsController.IsPatientScheduledToday(patient);
            }
        }
        public Report SelectedReport
        {
            get
            {
                return selectedReport;
            }
            set
            {
                selectedReport = value;
                RaisePropertyChanged("SelectedReport");
                RaisePropertyChanged("IsDataGridRowSelected");
            }
        }
        public String PatientConditions
        {
            get
            {
                Report lastReport = physitianHospitalAccountsController.GetLastReportForPatient(patient);
                if(lastReport == null)
                {
                    return "";
                }
                return lastReport.PatientConditions;
            }
        }

        public List<Physitian> Physitians { get => physitians; set => physitians = value; }
        public List<ProcedureType> ProcedureTypes { get => procedureTypes; set => procedureTypes = value; }
        public int SelectedPhysitian
        {
            get
            {
                for(int i = 0; i < physitians.Count; i++)
                {
                    if(selectedPhysitian.Equals(physitians[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                selectedPhysitian = physitians[value];
                Reports = filterReports();
                RaisePropertyChanged("SelectedPhysitian");
            }
        }
        public int SelectedProcedureType
        {
            get
            {
                for (int i = 0; i < procedureTypes.Count; i++)
                {
                    if (selectedProcedureType.Equals(procedureTypes[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                selectedProcedureType = procedureTypes[value];
                Reports = filterReports();
                RaisePropertyChanged("SelectedProcedureType");
            }
        }
        public List<Room> Rooms
        {
            get
            {
                return rooms;
            }
            set
            {
                rooms = value;
                SelectedRoom = 0;
                RaisePropertyChanged("Rooms");
            }
        }
        public List<Bed> Beds
        {
            get
            {
                return beds;
            }
            set
            {
                beds = value;
                SelectedBed = 0;
                RaisePropertyChanged("Beds");
            }
        }
        public int SelectedRoom
        {
            get
            {
                for(int i=0; i < rooms.Count; i++)
                {
                    if(selectedRoom.Equals(rooms[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                selectedRoom = rooms[value];
                Beds = inpatientCareController.GetAvailableBeds(selectedRoom);
                RaisePropertyChanged("SelectedRoom");
            }
        }
        public int SelectedBed
        {
            get
            {
                for(int i=0; i < beds.Count; i++)
                {
                    if(selectedBed.Equals(beds[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                if(value < 0 || value >= beds.Count)
                {
                    value = 0;
                }
                selectedBed = beds[value];
                RaisePropertyChanged("SelectedBed");
            }
        }
        public bool IsInpatientCareActive
        {
            get
            {
                return inpatientCareController.getActiveInpatientCare(patient) != null;
            }
        }
        public bool IsInpatientCareNotActive
        {
            get
            {
                return inpatientCareController.getActiveInpatientCare(patient) == null;
            }
        }
        public BedReservation ActiveInpatientCare
        {
            get
            {
                return inpatientCareController.getActiveInpatientCare(patient);
            }
        }

        public ObservableCollection<InpatientCare> PreviousInpatientCares
        {
            get
            {
                ObservableListConverter<InpatientCare> converter = new ObservableListConverter<InpatientCare>();
                return converter.ToObservable(inpatientCareController.getPreviousInpatientCares(patient));
            }
        }

        private ObservableCollection<Report> filterReports()
        {
            ObservableCollection<Report> result = new ObservableCollection<Report>();

            foreach(Report r in allReports)
            {
                if(SelectedProcedureType != 0 && !selectedProcedureType.Equals(r.ProcedureType))
                {
                    continue;
                }

                if(SelectedPhysitian == 0 || selectedPhysitian.Equals(r.Physitian))
                {
                    result.Add(r);
                }
            }

            return result;
        }
    }
}
