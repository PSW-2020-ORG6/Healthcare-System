
using Model.Hospital;
using Model.MedicalExam;
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
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty("All", "Analgetik", false)).Returns(prescriptions);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty("Medicine name", "Brufen", false)).Returns(prescriptions);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Analgetik,All;AND,Brufen,Medicine name");
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
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty("All", "Analgetik", false)).Returns(prescriptions);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty("Medicine name", "Brufen", false)).Returns(prescriptions);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs=prescriptionService.GetSearchedPrescription(",Analgetik,All;OR,Brufen,Medicine name");
            Assert.NotNull(searchEntityDTOs);
        }
        [Fact]
        public void Find_no_prescriptions_or()
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
            
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty("Medicine name", "Panadol", false)).Returns(prescriptions1);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty("Medicine type", "Kafetin", false)).Returns(prescriptions2);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Panadol,Medicine name;OR,Kafetin,Medicine type");
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

            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty("Medicine name", "Panadol", false)).Returns(prescriptions1);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty("Medicine type", "Panadol", true)).Returns(prescriptions2);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Panadol,Medicine name;AND NOT,Panadol,Medicine type");
            Assert.NotNull(searchEntityDTOs);
        }
        [Fact]
        public void Find_prescriptions_and_or_and_not()
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
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty("All", "Analgetik", false)).Returns(prescriptions1);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty("Medicine name", "Brufen", false)).Returns(prescriptions2);
            stubRepositorty.Setup(l => l.GetPrescriptionsByProperty("Medicine name", "Kafetin", false)).Returns(prescriptions2);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Analgetik,All;OR,Brufen,Medicine name;AND,Kafetin,Medicine name");
            Assert.NotNull(searchEntityDTOs);
        }
        [Fact]
        public void Find_no_prescriptions_and_or()
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


            List<Prescription> emptyList=null;
            stubRepositorty.Setup(m => m.GetPrescriptionsByProperty("All", "Panadol", false)).Returns(emptyList);
            stubRepositorty.Setup(n => n.GetPrescriptionsByProperty("Medicine name", "Brufen", false)).Returns(prescriptions);
            stubRepositorty.Setup(l => l.GetPrescriptionsByProperty("Medicine name", "Brufen", false)).Returns(prescriptions);

            PrescriptionService prescriptionService = new PrescriptionService(stubRepositorty.Object);
            List<SearchEntityDTO> searchEntityDTOs = prescriptionService.GetSearchedPrescription(",Panadol,All;AND,Brufen,Medicine name;OR,Brufen,Medincine name");
            Assert.Null(searchEntityDTOs);
        }
    }
}
