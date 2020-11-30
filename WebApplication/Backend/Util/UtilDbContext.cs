using health_clinic_class_diagram.Backend.Model.Survey;
using health_clinic_class_diagram.Backend.Model.Hospital;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;
using Model.Blog;
using Model.Hospital;
using Model.MedicalExam;
using Model.Util;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Model
{
    public class UtilDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<RoomGEA> Rooms { get; set; }
        public DbSet<BedGEA> Beds { get; set; }
        public DbSet<MedicineManufacturer> MedicineManufacturers { get; set; }
        public DbSet<MedicineType> MedicineTypes { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<MedicineGEA> MedicineGEA { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Report> Reports { get; set; }


        public UtilDbContext(DbContextOptions<UtilDbContext> options) : base(options) { }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>().HasKey(o => o.SerialNumber );
            modelBuilder.Entity<Report>().HasKey(o => o.SerialNumber);

            modelBuilder.Entity<Feedback>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Building>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Equipment>().HasKey(o => o.Id);
            modelBuilder.Entity<Floor>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<RoomGEA>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<BedGEA>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<MedicineManufacturer>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<MedicineType>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Medicine>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<MedicineGEA>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Patient>().HasAlternateKey(o => o.Id);
            modelBuilder.Ignore<Address>();
            modelBuilder.Entity<Patient>().HasData(
                 new Patient { Name = "Jelena", Surname = "Tanjic", Id = "0002", DateOfBirth = new DateTime(2017, 1, 18), Contact = "kontakt", Password = "sifra", Address = new Address("neka adresa"), ParentName = "otac", Gender = "Zensko", Email = "email", Guest = true },
                 new Patient { Name = "Sara", Surname = "Milic", Id = "0003", DateOfBirth = new DateTime(2018, 1, 18), Contact = "kontaktMica", Password = "sifraMica", Address = new Address("neka adresaMica"), ParentName = "mama", Gender = "Zensko", Email = "emailMica", Guest = true }
            );
            modelBuilder.Entity<Question>().HasKey(o => o.Id);
            modelBuilder.Entity<Question>().HasData(
                new Question { id = 1,QuestionText= "The doctor is welcoming and gentle?"},
                new Question { id = 2, QuestionText = "The doctor answered all of your questions in an understandable manner?" },
                new Question { id = 3, QuestionText = "The doctor takes care of you in a professional manner?" },
                new Question { id = 4, QuestionText = "Would you have the procedure done again by this doctor?" },
                new Question { id = 5, QuestionText = "The personal manner(courtosy,respect,sensitivity,friendliness) of the nurses and other support staff?" },
                new Question { id = 6, QuestionText = "The nursees answered all of your questions in an understandable manner?" },
                new Question { id = 7, QuestionText = "Orientation given to warn setup" },
                new Question { id = 8, QuestionText = "The nurse gave you good discharge instructions" },
                new Question { id = 9, QuestionText = "The nurse was concern for you?" },
                new Question { id = 10, QuestionText = "The comfort and cleanliness of the facility" },
                new Question { id = 11, QuestionText = "Comfort level within the procedure room?" },
                new Question { id = 12, QuestionText = "Conditions of the rooms(temperature,comfort,silence)" },
                new Question { id = 13, QuestionText = "General impression of the ambient atmosphere" },
                new Question { id = 14, QuestionText = "Do you think the clinic has the necessary equipment" },
                new Question { id = 15, QuestionText = "Do you think the clinic's farmacy has the necessary drugs?" },
                new Question { id = 16, QuestionText = "Do you think that the hospital should have more modern equipment than the current one" },
                new Question { id = 17, QuestionText = "Did you noticed broken or damaged equipment in the hospital" },
                new Question { id = 18, QuestionText = "The doctor prescribed medications that I could buy at the clinic's pharmacy" },
                new Question { id = 19, QuestionText = "Did you found it easy to use our website?" },
                new Question { id = 20, QuestionText = "Did you have found all the necessary information on our website?" },
                new Question { id = 21, QuestionText = "Overall, are you satisfied with the care you received in this facility?" },
                new Question { id = 22, QuestionText = "Would you come to this institution again" },
                new Question { id = 23, QuestionText = ">Would you recommend this facility to your friends and family" }
           );
            
            modelBuilder.Entity<Survey>().HasData(
                new Survey {
                    ID = "001",
                    DoctorName = "Pera Peric",
                    Question1 = "5",
                    Question2 = "5",
                    Question3 = "5",
                    Question4 = "5",
                    Question5 = "4",
                    Question6 = "3",
                    Question7 = "5",
                    Question8 = "5",
                    Question9 = "1",
                    Question10 = "5",
                    Question11 = "2",
                    Question12 = "5",
                    Question13 = "5",
                    Question14 = "5",
                    Question15 = "5",
                    Question16 = "5",
                    Question17 = "5",
                    Question18 = "5",
                    Question19 = "5",
                    Question20 = "5",
                    Question21 = "3",
                    Question22 = "2",
                    Question23 = "4"
                }
           );
            modelBuilder.Entity<Survey>().HasData(
               new Survey
               {
                   ID = "005",
                   DoctorName="Mika Mikic",
                   Question1 = "5",
                   Question2 = "5",
                   Question3 = "5",
                   Question4 = "5",
                   Question5 = "4",
                   Question6 = "3",
                   Question7 = "5",
                   Question8 = "5",
                   Question9 = "1",
                   Question10 = "5",
                   Question11 = "2",
                   Question12 = "5",
                   Question13 = "5",
                   Question14 = "5",
                   Question15 = "5",
                   Question16 = "5",
                   Question17 = "5",
                   Question18 = "5",
                   Question19 = "5",
                   Question20 = "5",
                   Question21 = "3",
                   Question22 = "2",
                   Question23 = "4"
               }
          );

            modelBuilder.Entity<Building>().HasData(
              new Building { SerialNumber = "10001", Name = "Cardiology", Color = "Orange", Row = 5, Column = 1, Style = "TriangleBuildingButtonStyle" },
              new Building { SerialNumber = "10002", Name = "Orthopedy", Color = "Red", Row = 5, Column = 3, Style = "UBuildingButtonStyle" }
            );
            modelBuilder.Entity<Floor>().HasData(
              new Floor { SerialNumber = "1001", Name = "Floor1", BuildingSerialNumber = "10001" },
              new Floor { SerialNumber = "1002", Name = "Floor2", BuildingSerialNumber = "10001" },
              new Floor { SerialNumber = "1003", Name = "Floor1", BuildingSerialNumber = "10002" }
            );
            modelBuilder.Entity<RoomGEA>().HasData(
                new RoomGEA { SerialNumber = "101", Name = "Examination room 101", FloorName = "Floor 1", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "102", Name = "Examination room 102", FloorName = "Floor 1", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "103", Name = "Store room 103", FloorName = "Floor 1", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "104", Name = "Examination room 104", FloorName = "Floor 1", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "105", Name = "Store room 105", FloorName = "Floor 1", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "106", Name = "Operation room 106", FloorName = "Floor 2", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "107", Name = "Operation room 107", FloorName = "Floor 2", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "108", Name = "Store room 108", FloorName = "Floor 2", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "109", Name = "Examination room 109", FloorName = "Floor 1", BuildingName = "Orthopedy" },
                new RoomGEA { SerialNumber = "110", Name = "Operation room 110", FloorName = "Floor 1", BuildingName = "Orthopedy" },
                new RoomGEA { SerialNumber = "111", Name = "Examination room 111", FloorName = "Floor 1", BuildingName = "Orthopedy" },
                new RoomGEA { SerialNumber = "112", Name = "Store room 112", FloorName = "Floor 1", BuildingName = "Orthopedy" },
                new RoomGEA { SerialNumber = "113", Name = "Examination room 113", FloorName = "Floor 1", BuildingName = "Orthopedy" },
                new RoomGEA { SerialNumber = "114", Name = "Examination room 114", FloorName = "Floor 1", BuildingName = "Orthopedy" }
            );
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { SerialNumber = "73", RoomId = "101", Name = "Bed", Id = "11" },
                new Equipment { SerialNumber = "74", RoomId = "102", Name = "Bed", Id = "12" },
                new Equipment { SerialNumber = "75", RoomId = "103", Name = "Bed", Id = "13" },
                new Equipment { SerialNumber = "76", RoomId = "101", Name = "Bed", Id = "14" },
                new Equipment { SerialNumber = "77", RoomId = "102", Name = "Bed", Id = "15" },
                new Equipment { SerialNumber = "78", RoomId = "104", Name = "Table", Id = "16" },
                new Equipment { SerialNumber = "79", RoomId = "111", Name = "Table", Id = "17" },
                new Equipment { SerialNumber = "80", RoomId = "111", Name = "Table", Id = "18" },
                new Equipment { SerialNumber = "81", RoomId = "112", Name = "Bed", Id = "19" },
                new Equipment { SerialNumber = "82", RoomId = "112", Name = "Bed", Id = "20" }

                );
            modelBuilder.Entity<MedicineManufacturer>().HasData(
                new MedicineManufacturer { SerialNumber = "1", Name = "manufacturer1"  },
                new MedicineManufacturer { SerialNumber = "2", Name = "manufacturer2"  }
                );
            modelBuilder.Entity<MedicineType>().HasData(
                    new MedicineType { SerialNumber = "11", Type = "Antibiotic" },
                    new MedicineType { SerialNumber = "12", Type = "Brufen" }
                );
            modelBuilder.Entity<MedicineGEA>().HasData(
                   new MedicineGEA { SerialNumber = "21", CopyrightName = "Brufen", GenericName = "Brufen", MedicineManufacturerId = "1", MedicineTypeId = "11" },
                   new MedicineGEA { SerialNumber = "22", CopyrightName = "Probiotic", GenericName = "Probiotic", MedicineManufacturerId = "2", MedicineTypeId = "12" }
                );
            modelBuilder.Entity<BedGEA>().HasData(
                new BedGEA
                {
                    SerialNumber = "1", 
                    BuildingSerialNumber = "10001", 
                    FloorSerialNumber = "1001", 
                    RoomSerialNumber = "101",
                    Name = "Bed 1", 
                    PatientID = "0002"
                },
                new BedGEA
                {
                    SerialNumber = "2",
                    BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1001",
                    RoomSerialNumber = "101",
                    Name = "Bed 2",
                    PatientID = "0003"
                },
                new BedGEA
                {
                    SerialNumber = "3",
                    BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1001",
                    RoomSerialNumber = "102",
                    Name = "Bed 3",
                    PatientID = null
                }
            );
        }
    }
}
