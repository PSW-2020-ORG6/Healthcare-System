
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

namespace WebApplicationsTests
{
    public class UserSearchesTest
    {
        public PrescriptionService ReportService { get; private set; }

        [Fact]
        public void Find_prescriptions_and()
        {
            var stubRepositorty = new Mock<IPrescriptionRepository>();
            List<Prescription> prescriptions = new List<Prescription>();
            List<MedicineDosage> medicineDosages1 = new List<MedicineDosage>();
            medicineDosages1.Add(new MedicineDosage { Amount = 250.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Bruefen", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno dve tablete dnevno. Ne duze od 7dana." });
            medicineDosages1.Add(new MedicineDosage { Amount = 350.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Kafetin", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno tri tablete dnevno. Ne duze od 7dana." });
            List<MedicineDosage> medicineDosages2 = new List<MedicineDosage>();
            medicineDosages2.Add(new MedicineDosage { Amount = 250.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Bruefen", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno dve tablete dnevno. Ne duze od 7dana." });

            prescriptions.Add(new Prescription { Date = DateTime.Today, Notes = "Uzimati po potrebi dva puta dnevno", MedicineDosage = medicineDosages1 });
            prescriptions.Add(new Prescription { Date = DateTime.Today, Notes = "Jedna tableta dnevno", MedicineDosage = medicineDosages2 });
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty(SearchProperty.All, "Analgetik", "'20-11-05' and '20-11-12'", false)).Returns(prescriptions);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty(SearchProperty.MedicineName, "Brufen", "'20-11-05' and '20-11-12'",false)).Returns(prescriptions);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Analgetik,All;AND,Brufen,Medicine name", "'20-11-05' and '20-11-12'");
            Assert.NotNull(searchEntityDTOs);
        }
        [Fact]
        public void Find_report_and()
        {
            var stubRepositorty = new Mock<IReportRepository>();
            List<Report> reports = new List<Report>();
            ProcedureType procedureType = new ProcedureType { Specialization = new Specialization { Name = "ophtamologist" }, Name = "pregled" };
            Patient patient = new Patient { Name = "Leposava", Surname = "Lepic" };
            Physitian physitian1 = new Physitian { Name = "Tanja", Surname = "Drcelic" };
            Physitian physitian2 = new Physitian { Name = "Nemanja", Surname = "Drcelic" };
            reports.Add(new Report { Patient = patient, Physitian = physitian1, ProcedureType = procedureType, Findings = "Sve ok" });
            reports.Add(new Report { Patient = patient, Physitian = physitian2, ProcedureType = procedureType, Findings = "Sve ok" });
            stubRepositorty.Setup(m => m.GetReportsByProperty(SearchProperty.All, "Tanja", "'20-11-05' and '20-11-12'", false)).Returns(reports);
            stubRepositorty.Setup(n => n.GetReportsByProperty(SearchProperty.Doctor, "Drcelic", "'20-11-05' and '20-11-12'", false)).Returns(reports);

            ReportService reportService= new ReportService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = reportService.GetSearchedReport(",Tanja,All;AND,Drcelic,Doctor reports", "'20-11-05' and '20-11-12'");
            Assert.NotNull(searchEntityDTOs);
        }
        [Fact]
        public void Find_prescriptions_or()
        {
            var stubRepositorty = new Mock<IPrescriptionRepository>();
            List<Prescription> prescriptions = new List<Prescription>();
            List<MedicineDosage> medicineDosages1 = new List<MedicineDosage>();
            medicineDosages1.Add(new MedicineDosage { Amount = 250.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Bruefen", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno dve tablete dnevno. Ne duze od 7dana." });
            medicineDosages1.Add(new MedicineDosage { Amount = 350.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Kafetin", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno tri tablete dnevno. Ne duze od 7dana." });
            List<MedicineDosage> medicineDosages2 = new List<MedicineDosage>();
            medicineDosages2.Add(new MedicineDosage { Amount = 250.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Bruefen", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno dve tablete dnevno. Ne duze od 7dana." });

            prescriptions.Add(new Prescription { Date = DateTime.Today, Notes = "Uzimati po potrebi dva puta dnevno", MedicineDosage = medicineDosages1 });
            prescriptions.Add(new Prescription { Date = DateTime.Today, Notes = "Jedna tableta dnevno", MedicineDosage = medicineDosages2 });
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty(SearchProperty.All, "Analgetik", "'20-11-05' and '20-11-12'",false)).Returns(prescriptions);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty(SearchProperty.MedicineName, "Brufen", "'20-11-05' and '20-11-12'",false)).Returns(prescriptions);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs=prescriptionService.GetSearchedPrescription(",Analgetik,All;OR,Brufen,Medicine name", "'20-11-05' and '20-11-12'");
            Assert.NotNull(searchEntityDTOs);
        }
        [Fact]
        public void Find_report_or()
        {
            var stubRepositorty = new Mock<IReportRepository>();
            List<Report> reports = new List<Report>();
            ProcedureType procedureType = new ProcedureType { Specialization = new Specialization { Name = "ophtamologist" }, Name = "pregled" };
            Patient patient = new Patient { Name = "Leposava", Surname = "Lepic" };
            Physitian physitian1 = new Physitian { Name = "Tanja", Surname = "Drcelic" };
            Physitian physitian2 = new Physitian { Name = "Nemanja", Surname = "Drcelic" };
            reports.Add(new Report { Patient = patient, Physitian = physitian1, ProcedureType = procedureType, Findings = "Sve ok" });
            reports.Add(new Report { Patient = patient, Physitian = physitian2, ProcedureType = procedureType, Findings = "Sve ok" });
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
            List<Prescription> prescriptions1 = new List<Prescription>();
            List<Prescription> prescriptions2 = new List<Prescription>();
            List<MedicineDosage> medicineDosages1 = new List<MedicineDosage>();
            List<MedicineDosage> medicineDosages2 = new List<MedicineDosage>();
            medicineDosages1.Add(new MedicineDosage { Amount = 250.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Bruefen", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno dve tablete dnevno. Ne duze od 7dana." });
            medicineDosages2.Add(new MedicineDosage { Amount = 350.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Kafetin", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno tri tablete dnevno. Ne duze od 7dana." });

            prescriptions1.Add(new Prescription { Date = DateTime.Today, Notes = "Uzimati po potrebi dva puta dnevno", MedicineDosage = medicineDosages1 });
            prescriptions2.Add(new Prescription { Date = DateTime.Today, Notes = "Uzimati po potrebi dva puta dnevno", MedicineDosage = medicineDosages2 });
            
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty(SearchProperty.MedicineName, "Panadol", "'20-11-05' and '20-11-12'",false)).Returns(prescriptions1);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty(SearchProperty.MedicineType, "Kafetin", "'20-11-05' and '20-11-12'",false)).Returns(prescriptions2);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Panadol,Medicine name;AND,Kafetin,Medicine type", "'20-11-05' and '20-11-12'");
            Assert.Null(searchEntityDTOs);
        }
        [Fact]
        public void Find_no_report_and()
        {
            var stubRepositorty = new Mock<IReportRepository>();
            List<Report> reports1 = new List<Report>();
            List<Report> reports2 = new List<Report>();
            ProcedureType procedureType = new ProcedureType { Specialization = new Specialization { Name = "ophtamologist" }, Name = "pregled" };
            Patient patient = new Patient { Name = "Leposava", Surname = "Lepic" };
            Physitian physitian1 = new Physitian { Name = "Tanja", Surname = "Drcelic" };
            Physitian physitian2 = new Physitian { Name = "Nemanja", Surname = "Drcelic" };
            reports1.Add(new Report { Patient = patient, Physitian = physitian1, ProcedureType = procedureType, Findings = "Sve ok" });
            reports2.Add(new Report { Patient = patient, Physitian = physitian2, ProcedureType = procedureType, Findings = "Sve ok" });
            stubRepositorty.Setup(m => m.GetReportsByProperty(SearchProperty.All, "Tanja", "'20-11-05' and '20-11-12'", false)).Returns(reports1);
            stubRepositorty.Setup(n => n.GetReportsByProperty(SearchProperty.Doctor, "Nemanja", "'20-11-05' and '20-11-12'", false)).Returns(reports2);

            ReportService reportService = new ReportService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = reportService.GetSearchedReport(",Tanja,All;AND,Nemanja,Doctor reports", "'20-11-05' and '20-11-12'");
            Assert.Null(searchEntityDTOs);
        }
        [Fact]
        public void Find_no_prescriptions_and_not()
        {
            var stubRepositorty = new Mock<IPrescriptionRepository>();
            List<Prescription> prescriptions1 = new List<Prescription>();
            List<Prescription> prescriptions2 = new List<Prescription>();
            List<MedicineDosage> medicineDosages1 = new List<MedicineDosage>();
            List<MedicineDosage> medicineDosages2 = new List<MedicineDosage>();
            medicineDosages1.Add(new MedicineDosage { Amount = 250.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Bruefen", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno dve tablete dnevno. Ne duze od 7dana." });
            medicineDosages2.Add(new MedicineDosage { Amount = 350.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Kafetin", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno tri tablete dnevno. Ne duze od 7dana." });

            prescriptions1.Add(new Prescription { Date = DateTime.Today, Notes = "Uzimati po potrebi dva puta dnevno", MedicineDosage = medicineDosages1 });
            prescriptions2.Add(new Prescription { Date = DateTime.Today, Notes = "Uzimati po potrebi dva puta dnevno", MedicineDosage = medicineDosages2 });

            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty(SearchProperty.MedicineName, "Panadol", "'20-11-05' and '20-11-12'",false)).Returns(prescriptions1);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty(SearchProperty.MedicineType, "Panadol", "'20-11-05' and '20-11-12'",true)).Returns(prescriptions2);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Panadol,Medicine name;AND NOT,Panadol,Medicine type", "'20-11-05' and '20-11-12'");
            Assert.Null(searchEntityDTOs);
        }
        [Fact]
        public void Find_no_report_and_not()
        {
            var stubRepositorty = new Mock<IReportRepository>();
            List<Report> reports1 = new List<Report>();
            List<Report> reports2 = new List<Report>();
            ProcedureType procedureType = new ProcedureType { Specialization = new Specialization { Name = "ophtamologist" }, Name = "pregled" };
            Patient patient = new Patient { Name = "Leposava", Surname = "Lepic" };
            Physitian physitian1 = new Physitian { Name = "Tanja", Surname = "Drcelic" };
            Physitian physitian2 = new Physitian { Name = "Nemanja", Surname = "Drcelic" };
            reports1.Add(new Report { Patient = patient, Physitian = physitian1, ProcedureType = procedureType, Findings = "Sve ok" });
            reports2.Add(new Report { Patient = patient, Physitian = physitian2, ProcedureType = procedureType, Findings = "Sve ok" });
            stubRepositorty.Setup(m => m.GetReportsByProperty(SearchProperty.All, "Tanja", "'20-11-05' and '20-11-12'", false)).Returns(reports1);
            stubRepositorty.Setup(n => n.GetReportsByProperty(SearchProperty.Doctor, "Tanja", "'20-11-05' and '20-11-12'", false)).Returns(reports2);

            ReportService reportService = new ReportService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = reportService.GetSearchedReport(",Tanja,All;AND NOT,Tanja,Doctor reports", "'20-11-05' and '20-11-12'");
            Assert.Null(searchEntityDTOs);
        }
        [Fact]
        public void Find_prescriptions_or_and()
        {
            var stubRepositorty = new Mock<IPrescriptionRepository>();
            List<Prescription> prescriptions1 = new List<Prescription>();
            List<Prescription> prescriptions2 = new List<Prescription>();
            List<MedicineDosage> medicineDosages1 = new List<MedicineDosage>();
            medicineDosages1.Add(new MedicineDosage { Amount = 250.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Bruefen", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno dve tablete dnevno. Ne duze od 7dana." });
            medicineDosages1.Add(new MedicineDosage { Amount = 350.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Kafetin", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno tri tablete dnevno. Ne duze od 7dana." });
            List<MedicineDosage> medicineDosages2 = new List<MedicineDosage>();
            medicineDosages2.Add(new MedicineDosage { Amount = 250.00, Medicine = new Medicine { CopyrightName = "Galenika", GenericName = "Bruefen", MedicineType = new MedicineType { Type = "Analgetik" } }, Note = "Maksimalno dve tablete dnevno. Ne duze od 7dana." });

            Prescription prescription1= new Prescription { Date = DateTime.Today, Notes = "Uzimati po potrebi dva puta dnevno", MedicineDosage = medicineDosages1 };
            Prescription prescription2= new Prescription { Date = DateTime.Today, Notes = "Jedna tableta dnevno", MedicineDosage = medicineDosages2 };
            prescriptions1.Add(prescription1);
            prescriptions2.Add(prescription1);
            prescriptions2.Add(prescription2);
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty(SearchProperty.All, "Analgetik", "'20-11-05' and '20-11-12'",false)).Returns(prescriptions1);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty(SearchProperty.MedicineName, "Brufen", "'20-11-05' and '20-11-12'",false)).Returns(prescriptions2);
            stubRepositorty.Setup(l => l.GetPrescriptionsByProperty(SearchProperty.MedicineName, "Kafetin", "'20-11-05' and '20-11-12'",false)).Returns(prescriptions2);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Analgetik,All;OR,Brufen,Medicine name;AND,Kafetin,Medicine name", "'20-11-05' and '20-11-12'");
            Assert.NotNull(searchEntityDTOs);
        }
        [Fact]
        public void Find_report_or_and()
        {
            var stubRepositorty = new Mock<IReportRepository>();
            List<Report> reports1 = new List<Report>();
            List<Report> reports2 = new List<Report>();
            ProcedureType procedureType = new ProcedureType { Specialization = new Specialization { Name = "ophtamologist" }, Name = "pregled" };
            Patient patient = new Patient { Name = "Leposava", Surname = "Lepic" };
            Physitian physitian1 = new Physitian { Name = "Tanja", Surname = "Drcelic" };
            Physitian physitian2 = new Physitian { Name = "Nemanja", Surname = "Drcelic" };
            reports1.Add(new Report { Patient = patient, Physitian = physitian1, ProcedureType = procedureType, Findings = "Sve ok" });
            reports2.Add(new Report { Patient = patient, Physitian = physitian2, ProcedureType = procedureType, Findings = "Sve ok" });
            stubRepositorty.Setup(m => m.GetReportsByProperty(SearchProperty.All, "Tanja", "'20-11-05' and '20-11-12'", false)).Returns(reports1);
            stubRepositorty.Setup(n => n.GetReportsByProperty(SearchProperty.Doctor, "Nemanja", "'20-11-05' and '20-11-12'", false)).Returns(reports2);
            stubRepositorty.Setup(n => n.GetReportsByProperty(SearchProperty.Doctor, "Tanja", "'20-11-05' and '20-11-12'", false)).Returns(reports1);

            ReportService reportService = new ReportService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = reportService.GetSearchedReport(",Tanja,All;OR,Nemanja,Doctor reports;AND,Tanja,Doctor reports", "'20-11-05' and '20-11-12'");
            Assert.NotNull(searchEntityDTOs);
        }
    }
}
