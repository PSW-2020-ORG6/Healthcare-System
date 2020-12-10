var foundedPharmacy = '';
$(document).ready(function () {
	$("#btnGetMedicineSpecification").click(function () {
		var MedicineName = $("#txtMedicine").val();
		$.get({
			url: '../medicine/getMedicineSpecification/' + MedicineName,
			contentType: 'application/json',
			success: function (MedicineName) {
					alert('Specification found!');

			},
			error: function (message) {
				alert('Waiting for check in pharmacy...');
				$.get({
					url: '../medicine/getSpecification/' + MedicineName,
					contentType: 'application/json',
					success: function () {
						alert('Success found specification in pharmacy');

					},
					error: function (message) {
						alert('Specification not found in phmarmacy');
					}
				});
			}
		});
	});

	$("#btnAskPharmaciesForSpecification").click(function () {
		var MedicineName = $("#txtMedicine").val();
		
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
	$("#btnCheckWithPharmacy").click(function () {
		var MedicineName = $("#txtMedicine").val();
		var Quantity = parseInt($("#txtQuantity").val());
		var IsPharmacyApproved = false;
		$.post({
			url: '../medicine/sendMessageGrpc',
			data: JSON.stringify({ MedicineName: MedicineName, Quantity: Quantity, IsPharmacyApproved: IsPharmacyApproved }),
			contentType: "application/json",
			success: function () {
				sleep(5000);
				getMessageGrpc();
			},
			error: function (message) {
				alert("Failed ")
			}
		});
	});
	function sleep(milliseconds) {
		const date = Date.now();
		let currentDate = null;
		do {
			currentDate = Date.now();
		} while (currentDate - date < milliseconds);
	}

	
	function getMessageGrpc() {
		$.get({
			url: '../medicine/getMessageGrpc',
			contentType: 'application/json',
			success: function (data) {
				foundedPharmacy = data;
				if (foundedPharmacy == undefined)
					document.getElementById('txtPharmacyName').value = 'Pharmacy not found';
				else
					document.getElementById('txtPharmacyName').value= foundedPharmacy;
			},
			error: function (message) {
				alert("Failed")
			}
		});
	}
});
