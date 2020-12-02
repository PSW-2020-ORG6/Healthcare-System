using Model.Accounts;
using Model.Hospital;
using Model.MedicalExam;
using Model.Schedule;
using Moq;
using System;
using System.Collections.Generic;
using WebApplication.Backend.DTO;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Services;
using Xunit;

namespace WebApplicationTests
{
    public class UserSearchesTest
    {
        private List<Prescription> prescriptions = new List<Prescription>();
        private List<Report> reports = new List<Report>();

        public UserSearchesTest()
        {
            List<MedicineDosage> medicineDosages1 = new List<MedicineDosage>();
            medicineDosages1.Add(new MedicineDosage { Amount = 250.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Bruefen", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno dve tablete dnevno. Ne duze od 7dana." });
            medicineDosages1.Add(new MedicineDosage { Amount = 350.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Kafetin", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno tri tablete dnevno. Ne duze od 7dana." });
            List<MedicineDosage> medicineDosages2 = new List<MedicineDosage>();
            medicineDosages2.Add(new MedicineDosage { Amount = 250.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Bruefen", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno dve tablete dnevno. Ne duze od 7dana." });
            prescriptions.Add(new Prescription { Date = DateTime.Today, Notes = "Uzimati po potrebi dva puta dnevno", MedicineDosage = medicineDosages1 });
            prescriptions.Add(new Prescription { Date = DateTime.Today, Notes = "Jedna tableta dnevno", MedicineDosage = medicineDosages2 });

            ProcedureType procedureType = new ProcedureType { Specialization = new Specialization { Name = "ophtamologist" }, Name = "pregled" };
            Patient patient = new Patient { Name = "Leposava", Surname = "Lepic" };
            Physitian physitian1 = new Physitian { Name = "Tanja", Surname = "Drcelic" };
            Physitian physitian2 = new Physitian { Name = "Nemanja", Surname = "Drcelic" };
            reports.Add(new Report { Patient = patient, Physitian = physitian1, ProcedureType = procedureType, Findings = "Sve ok" });
            reports.Add(new Report { Patient = patient, Physitian = physitian2, ProcedureType = procedureType, Findings = "Sve ok" });
        }

        [Fact]
        public void Find_prescriptions_and()
        {
            var stubRepositorty = new Mock<IPrescriptionRepository>();
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty(SearchProperty.All, "Analgetik", "'20-11-05' and '20-11-12'", false)).Returns(prescriptions);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty(SearchProperty.MedicineName, "Brufen", "'20-11-05' and '20-11-12'", false)).Returns(prescriptions);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Analgetik,All;AND,Brufen,Medicine name", "'20-11-05' and '20-11-12'");
            Assert.NotNull(searchEntityDTOs);
        }

        [Fact]
        public void Find_report_and()
        {
            var stubRepositorty = new Mock<IReportRepository>();
            stubRepositorty.Setup(m => m.GetReportsByProperty(SearchProperty.All, "Tanja", "'20-11-05' and '20-11-12'", false)).Returns(reports);
            stubRepositorty.Setup(n => n.GetReportsByProperty(SearchProperty.Doctor, "Drcelic", "'20-11-05' and '20-11-12'", false)).Returns(reports);

            ReportService reportService = new ReportService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = reportService.GetSearchedReport(",Tanja,All;AND,Drcelic,Doctor reports", "'20-11-05' and '20-11-12'");
            Assert.NotNull(searchEntityDTOs);
        }

        [Fact]
        public void Find_prescriptions_or()
        {
            var stubRepositorty = new Mock<IPrescriptionRepository>();
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty(SearchProperty.All, "Analgetik", "'20-11-05' and '20-11-12'", false)).Returns(prescriptions);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty(SearchProperty.MedicineName, "Brufen", "'20-11-05' and '20-11-12'", false)).Returns(prescriptions);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Analgetik,All;OR,Brufen,Medicine name", "'20-11-05' and '20-11-12'");
            Assert.NotNull(searchEntityDTOs);
        }

        [Fact]
        public void Find_report_or()
        {
            var stubRepositorty = new Mock<IReportRepository>();
            stubRepositorty.Setup(m => m.GetReportsByProperty(SearchProperty.All, "Tanja", "'20-11-05' and '20-11-12'", false)).Returns(reports);
            stubRepositorty.Setup(n => n.GetReportsByProperty(SearchProperty.Doctor, "Drcelic", "'20-11-05' and '20-11-12'", false)).Returns(reports);

            ReportService reportService = new ReportService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = reportService.GetSearchedReport(",Tanja,All;OR,Drcelic,Doctor reports", "'20-11-05' and '20-11-12'");
            Assert.NotNull(searchEntityDTOs);
        }

        [Fact]
        public void Find_no_prescriptions_and()
        {
            var stubRepositorty = new Mock<IPrescriptionRepository>();
            List<Prescription> prescriptions2 = new List<Prescription>();
            List<MedicineDosage> medicineDosages = new List<MedicineDosage>();
            medicineDosages.Add(new MedicineDosage { Amount = 250.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Panadol", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno dve tablete dnevno. Ne duze od 7dana." });
            prescriptions2.Add(new Prescription { Date = DateTime.Today, Notes = "Uzimati po potrebi dva puta dnevno", MedicineDosage = medicineDosages });
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty(SearchProperty.MedicineName, "Brufen", "'20-11-05' and '20-11-12'", false)).Returns(prescriptions);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty(SearchProperty.MedicineName, "Panadol", "'20-11-05' and '20-11-12'", false)).Returns(prescriptions2);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Brufen,Medicine name;AND,Panadol,Medicine name", "'20-11-05' and '20-11-12'");
            Assert.Null(searchEntityDTOs);
        }

        [Fact]
        public void Find_no_report_and()
        {
            var stubRepositorty = new Mock<IReportRepository>();
            List<Report> reports1 = new List<Report>();
            ProcedureType procedureType = new ProcedureType { Specialization = new Specialization { Name = "ophtamologist" }, Name = "pregled" };
            reports1.Add(new Report { Patient = new Patient { Name = "Leposava", Surname = "Lepic" }, Physitian = new Physitian { Name = "Aleksandra", Surname = "Milijevic" }, ProcedureType = procedureType, Findings = "Sve ok" });
            stubRepositorty.Setup(m => m.GetReportsByProperty(SearchProperty.All, "anja", "'20-11-05' and '20-11-12'", false)).Returns(reports);
            stubRepositorty.Setup(n => n.GetReportsByProperty(SearchProperty.Doctor, "Aleksandra", "'20-11-05' and '20-11-12'", false)).Returns(reports1);

            ReportService reportService = new ReportService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = reportService.GetSearchedReport(",anja,All;AND,Aleksandra,Doctor reports", "'20-11-05' and '20-11-12'");
            Assert.Null(searchEntityDTOs);
        }

        [Fact]
        public void Find_no_prescriptions_and_not()
        {
            var stubRepositorty = new Mock<IPrescriptionRepository>();
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty(SearchProperty.MedicineType, "Analgetik", "'20-11-05' and '20-11-12'", false)).Returns(prescriptions);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty(SearchProperty.MedicineType, "Probiotik", "'20-11-05' and '20-11-12'", true)).Returns(prescriptions);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Panadol,Medicine type;AND NOT,Probiotik,Medicine type", "'20-11-05' and '20-11-12'");
            Assert.Null(searchEntityDTOs);
        }

        [Fact]
        public void Find_no_report_and_not()
        {
            var stubRepositorty = new Mock<IReportRepository>();
            List<Report> reports1 = new List<Report>();
            ProcedureType procedureType = new ProcedureType { Specialization = new Specialization { Name = "ophtamologist" }, Name = "pregled" };
            Patient patient = new Patient { Name = "Leposava", Surname = "Lepic" };
            Physitian physitian = new Physitian { Name = "Aleksandra", Surname = "Milijevic" };
            reports1.Add(new Report { Patient = patient, Physitian = physitian, ProcedureType = procedureType, Findings = "Sve ok" });
            stubRepositorty.Setup(m => m.GetReportsByProperty(SearchProperty.All, "anja", "'20-11-05' and '20-11-12'", false)).Returns(reports);
            stubRepositorty.Setup(n => n.GetReportsByProperty(SearchProperty.Doctor, "Tanja", "'20-11-05' and '20-11-12'", false)).Returns(reports);

            ReportService reportService = new ReportService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = reportService.GetSearchedReport(",anja,All;AND NOT,Tanja,Doctor reports", "'20-11-05' and '20-11-12'");
            Assert.Null(searchEntityDTOs);
        }

        [Fact]
        public void Find_prescriptions_or_and()
        {
            var stubRepositorty = new Mock<IPrescriptionRepository>();
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty(SearchProperty.All, "Ana", "'20-11-05' and '20-11-12'", false)).Returns(prescriptions);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty(SearchProperty.MedicineName, "A", "'20-11-05' and '20-11-12'", false)).Returns(prescriptions);
            stubRepositorty.Setup(l => l.GetPrescriptionsByProperty(SearchProperty.MedicineType, "Analgetik", "'20-11-05' and '20-11-12'", false)).Returns(prescriptions);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Ana,All;OR,A,Medicine name;AND,Analgetik,Medicine type", "'20-11-05' and '20-11-12'");
            Assert.NotNull(searchEntityDTOs);
        }

        [Fact]
        public void Find_report_or_and()
        {
            var stubRepositorty = new Mock<IReportRepository>();
            stubRepositorty.Setup(m => m.GetReportsByProperty(SearchProperty.All, "anja", "'20-11-05' and '20-11-12'", false)).Returns(reports);
            stubRepositorty.Setup(n => n.GetReportsByProperty(SearchProperty.ProcedureType, "pregled", "'20-11-05' and '20-11-12'", false)).Returns(reports);
            stubRepositorty.Setup(n => n.GetReportsByProperty(SearchProperty.Specialist, "ophtamologist", "'20-11-05' and '20-11-12'", false)).Returns(reports);

            ReportService reportService = new ReportService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = reportService.GetSearchedReport(",anja,All;OR,pregled,Procedure type;AND,ophtamologist,Specialist reports", "'20-11-05' and '20-11-12'");
            Assert.NotNull(searchEntityDTOs);
        }
    }
}

