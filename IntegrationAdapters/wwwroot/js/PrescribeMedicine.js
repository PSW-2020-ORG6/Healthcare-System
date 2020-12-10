﻿$(document).ready(function () {
	$("#btnGetMedicineSpecification").click(function () {
		var MedicineName = $("#txtMedicine").val();
		$.get({
			url: '../medicine/getMedicineSpecification/' + MedicineName,
			contentType: 'application/json',
			success: function (MedicineName) {
				console.log(MedicineName);
				if (MedicineName != "")
					alert('Specification found!');
				else {
					$("#btnAskPharmaciesForSpecification").attr("disabled", false);
					$("#btnGetMedicineSpecification").attr("disabled", true);
					alert('Specification not found!Ask pharmacy!');
				}
			},
			error: function (message) {
				alert("Failed")
			}
		});
	});

	$("#btnAskPharmaciesForSpecification").click(function () {
		var MedicineName = $("#txtMedicine").val();
		$.get({
			url: '../medicine/getSpecification/' + MedicineName,
			contentType: 'application/json',
			success: function () {
				alert('Success found specification in pharmacy');
	
			},
			error: function (message) {
				$("#btnAskPharmaciesForSpecification").attr("disabled", true);
				$("#btnGetMedicineSpecification").attr("disabled", false);
				alert('Specification not found in phmarmacy');
			}
		});
	});

	$("#btnPrescribe").click(function () {
		var PatientName = $("#txtPatientName").val();
		var PatientSurName = $("#txtPatientSurname").val();
		var Medicine = $("#txtMedicine").val();
		var Quantity = parseInt($("#txtQuantity").val());
		var PharmacyName = $("#txtPharmacyName").val();
		var Note = $("#txtNote").val();
		$.post({
			url: '../medicine/prescribeMedicine',
			data: JSON.stringify({ PatientName: PatientName, PatientSurName: PatientSurName, Medicine: Medicine, Quantity: Quantity, PharmacyName: PharmacyName, Note: Note }),
			contentType: 'application/json',
			success: function (data) {
				alert("Succes sent prescription");
				location.href = "../index.html";
			},
			error: function (message) {
				alert("Failed sent")
			}
		});
	});
});
