INSERT INTO public."ActionAndBenefitMessage"(
	"SerialNumber", "ActionID", "PharmacyName", "Text", "DateFrom", "DateTo")
	VALUES ('1', '4B900A74-E2D9-4837-B9A4-9E828752716E', 'Benu', 'Natural wealth supplements 20% off', '1-1-2021', '2-2-2021');
	
INSERT INTO public."MedicineManufacturer"(
	"SerialNumber", "Name")
	VALUES ('1', 'Hemofarm'), ('2', 'Galenika');
	
INSERT INTO public."MedicineType"(
	"SerialNumber", "Type")
	VALUES ('1', 'Antibiotik'), ('2', 'Analgetik');
	
INSERT INTO public."Medicine"(
	"SerialNumber", "CopyrightName", "GenericName", "MedicineManufacturerSerialNumber", "MedicineTypeSerialNumber", "IsApproved")
	VALUES ('1', 'Panklav', 'Panklav', '1', '1', 'true'), ('2', 'Amikacin', 'Amikacin', '2', '1', 'false');
	
INSERT INTO public."Rejection"(
	"SerialNumber", "Reason", "MedicineSerialNumber")
	VALUES ('1', 'Nije dobro zavedeno genericko ime', '2');

INSERT INTO public."Country"(
	"SerialNumber", "Name")
	VALUES ('1', 'England');

INSERT INTO public."City"(
	"SerialNumber", "Name", "CountrySerialNumber", "PostalCode")
	VALUES ('1', 'Hertfordshire', '1', '123123');

INSERT INTO public."Address"(
	"SerialNumber", "Street", "CitySerialNumber")
	VALUES ('1', 'Bridgewater Pines', '1'), ('2', 'Moorland Royd', '1'), ('3', 'Keats Beeches', '1');

INSERT INTO public."Specialization"(
	"SerialNumber", "Name")
	VALUES ('1', 'Infectology'), ('2', 'General practitioner'), ('3', 'Cardiology');

INSERT INTO public."Physician"(
	"SerialNumber", "Name", "Surname", "Id", "DateOfBirth", "Contact", "Email", "AddressSerialNumber", "Password", "WorkSchedule_Start", "WorkSchedule_End", "WorkSchedule_Id")
	VALUES ('1', 'Gregory', 'House', '666', '6-6-1960', '123123', 'flamycane@gmail.com', '1', '123456', '2001-09-28 10:00', '2001-09-28 18:00', '1'),
	('2', 'Meredith', 'Gray', '123', '6-6-1960', '123123', 'mrsmcdreamy@gmail.com', '3', '123456', '2001-09-28 08:00', '2001-09-28 16:00', '1'),
	('3', 'Cristina', 'Yang', '456', '6-6-1960', '123123', 'cardiogod@gmail.com', '2', '123456', '2001-09-28 10:00', '2001-09-28 18:00', '1');

INSERT INTO public."PhysicianSpecialization"(
	"PhysicianSerialNumber", "SpecializationSerialNumber")
	VALUES ('1', '1'),('1', '2'), ('2', '2'), ('3', '3');

INSERT INTO public."Patient"(
	"SerialNumber", "Name", "Surname", "Id", "DateOfBirth", "Contact", "Email", "AddressSerialNumber", "Password", "ParentName", "PlaceOfBirth", "MunicipalityOfBirth", "StateOfBirth", "PlaceOfResidence", "MunicipalityOfResidence", "StateOfResidence", "Citizenship", "Nationality", "Profession", "EmploymentStatus", "MaritalStatus", "HealthInsuranceNumber", "FamilyDiseases", "PersonalDiseases", "Gender", "Image", "Guest", "EmailConfirmed", "PhysicianSerialNumber", "IsMalicious", "IsBlocked")
	VALUES ('1', 'Maddy', 'Barr', '111', '12-12-1970', '111111', 'maddybarr@mail.com', '1', '123456', 'Jenn', 'Derbyshire', 'Derbyshire', 'Derbyshire', 'Hertfordshire', 'Hertfordshire', 'Hertfordshire', 'english', 'english', 'life coach', 'self-employed', 'single', '1111111', 'cholesterol', 'asthma', 'female', null, 'true', 'true', '2', 'true', 'false'),
	('2', 'Harland', 'Dickman', '222', '12-12-1970', '222222', 'dick@mail.com', '1', '123456', 'Katelin', 'Derbyshire', 'Derbyshire', 'Derbyshire', 'Hertfordshire', 'Hertfordshire', 'Hertfordshire', 'english', 'english', 'Space Lawyer', 'unemployed', 'single', '22222', 'none', 'cholesterol', 'male', null, 'true', 'true', '2', 'false', 'false'),
	('3', 'Erika', 'Caulfield', '333', '12-12-1970', '333333', 'caulfield@mail.com', '1', '123456', 'Tracie', 'Derbyshire', 'Derbyshire', 'Derbyshire', 'Hertfordshire', 'Hertfordshire', 'Hertfordshire', 'english', 'english', 'Penguinologist', 'employed', 'single', '3333', 'hair cancer', 'none', 'female', null, 'true', 'true', '2', 'true', 'true');

INSERT INTO public."Building"(
	"SerialNumber", "Name", "Color", "Row", "Column", "Style")
	VALUES ('1', 'Cardiology', 'Blue', '0', '0', 'Rectangle'),
	('2', 'Pediatrics', 'Green', '2', '5', 'Triangle'),
	('3', 'General', 'Red', '4', '3', 'Rectangle'),
	('4', 'Orthopedics', 'Yellow', '2', '3', 'Square');

INSERT INTO public."Floor"(
	"SerialNumber", "Name", "BuildingSerialNumber")
	VALUES ('1', 'First floor', '1'), ('2', 'Second floor', '1'), ('3', 'Ground floor', '2'), ('4', 'First floor', '2'),
	('5', 'First floor', '3'), ('6', 'Basement level', '3'), ('7', 'First floor', '4'), ('8', 'Second floor', '4');

INSERT INTO public."RoomType"(
	"SerialNumber", "Name")
	VALUES ('1', 'ICU'), ('2', 'Exam room'), ('3', 'Operation room'), ('4', 'Storage room');

INSERT INTO public."Room"(
	"SerialNumber", "Name", "Id", "FloorSerialNumber", "BuildingSerialNumber", "RoomTypeSerialNumber", "Row", "Column", "RowSpan", "ColumnSpan", "Style")
	VALUES ('1', 'ICU 1', '101', '1', '1', '1', '2', '3', '5', '3', 'Rectangle'),
	('2', 'OR 1', '201', '2', '1', '3', '4', '3', '2', '3', 'Rectangle'),
	('3', 'Storage room', '43', '3', '2', '4', '2', '3', '5', '3', 'Rectangle'),
	('4', 'ICU 1', '1', '5', '3', '1', '2', '3', '5', '3', 'Rectangle');
	
INSERT INTO public."Equipment"(
	"SerialNumber", "Name", "Id", "RoomId", "BuildingSerialNumber", "FloorSerialNumber", "RoomSerialNumber")
	VALUES ('1', 'Syringe', '123', '201', '1', '2', '2'),
	('2', 'N95 mask', '431', '201', '1', '2', '2'),
	('3', 'Scalpel', '111', '201', '1', '2', '2');
	
INSERT INTO public."Bed"(
	"SerialNumber", "Name", "Id", "RoomId", "BuildingSerialNumber", "FloorSerialNumber", "RoomSerialNumber", "PatientSerialNumber", "RoomSerialNumber2")
	VALUES ('1', 'Bed 1', '10', '1', '1', '1', '1', '1', '1'),
	('2', 'Bed 2', '10', '11', '1', '1', '1', '1', '3');

INSERT INTO public."ProcedureType"(
	"SerialNumber", "SpecializationSerialNumber", "Name", "EstimatedTimeInMinutes")
	VALUES ('1', '1', 'Gallstones removal', '120'),
	('2', '2', 'Bone fracture repair', '60'),
	('3', '3', 'Bypass', '120'),
	('4', '2', 'General practice exam', '30'),
	('5', '1', 'COVID exam', '30');

INSERT INTO public."Appointment"(
	"SerialNumber", "RoomSerialNumber", "PhysicianSerialNumber", "PatientSerialNumber", "TimeInterval_Start", "TimeInterval_End", "TimeInterval_Id", "ProcedureTypeSerialnumber", "Urgency", "Date", "Active", "IsSurveyDone")
	VALUES ('1', '1', '1', '1', '12-12-2020 12:00', '12-12-2020 14:00', '1', '1', true, '12-12-2020', 'true', 'true'),
	('2', '3', '2', '2', '12-12-2020 12:00', '12-12-2020 13:00', '2', '1', true, '12-12-2020', 'true', 'false'),
	('3', '4', '2', '3', '12-12-2020 10:30', '12-12-2020 12:30', '3', '1', false, '12-12-2020', 'true', 'true'),
	('4', '2', '3', '2', '12-12-2020 10:00', '12-12-2020 10:30', '4', '1', false, '12-12-2020', 'true', 'false'),
	('5', '1', '1', '1', '12-12-2020 10:00', '12-12-2020 10:30', '5', '1', true, '12-12-2020', 'true', 'false');
	
INSERT INTO public."Prescription"(
	"SerialNumber", "Date", "Notes")
	VALUES ('1', '6-12-2020', 'Prescribed for laryngitis.');

INSERT INTO public."MedicineDosage"(
	"SerialNumber", "MedicineSerialNumber", "Amount", "Note", "PrescriptionSerialNumber")
	VALUES ('1', '1', 5, 'Every 12 hours. Before meal.', '1'),
	('2', '2', 5, 'Every 6 hours. After meal.', '1');
	
INSERT INTO public."Question"(
	"SerialNumber", "QuestionText", "Id")
	VALUES ('1', 'How satisfied are you with our hospitality?', '1');
	
INSERT INTO public."Survey"(
	"SerialNumber", "PatientId", "ReportDate", "DoctorName")
	VALUES ('1', '1', '12-12-2020', 'Meredith Gray');

INSERT INTO public."Feedback"(
	"SerialNumber", "PatientId", "Text", "Date", "Approved")
	VALUES ('1', '2', 'Great staff! Very professional.', '3-3-2020', 'true'),
	('2', '3', 'Very helpfull and professional', '5-6-2020', 'true'),
	('3', '1', 'Wonderful doctors!', '3-3-2020', 'false');
