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

	$("#btnCheckWithPharmacyHttp").click(function () {
		var MedicineName = $("#txtMedicine").val();
		var Quantity = parseInt($("#txtQuantity").val());
		$.get({
			url: '../medicine/getPharmacies/' + MedicineName + '/' + Quantity,
			contentType: 'application/json',
			success: function (foundedPharmacy) {
				$('#container').html('');
				var foundedPharmacy = foundedPharmacy.substring(0, foundedPharmacy.length - 1)
				var foundedPharmacyArray = foundedPharmacy.split('#');
				
				for (var value of foundedPharmacyArray) {
						if (value == 'Pharmacy not foun') {
							$('#container').append(`<input class="textbox" type="text" id="${value}"  value="Pharmacy not found" disabled>`)
							$('#btnPrescribe').attr("disabled", true);
						} else {
							$('#container')
								.append(`<input type="checkbox" id="${value}" name="interest" value="${value}">`)
								.append(`<label for="${value}">${value}</label></div>`)
								.append(`<br>`);
						}
					}
				},
				
			error: function (message) {
				alert("Failed")
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

	$("#btnCheckWithPharmacy").click(function () {
		var MedicineName = $("#txtMedicine").val();
		var Quantity = parseInt($("#txtQuantity").val());
		var IsPharmacyApproved = false;
		$.post({
			url: '../medicine/sendMessageGrpc',
			data: JSON.stringify({ MedicineName: MedicineName, Quantity: Quantity, IsPharmacyApproved: IsPharmacyApproved }),
			contentType: "application/json",
			success: function () {
				sleep(3000);
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

		$('#container').html('');
		$.get({
			url: '../medicine/getMessageGrpc',
			contentType: 'application/json',
			success: function (data) {
				foundedPharmacy = data;
				foundedPharmacy = foundedPharmacy.replace('[', '');
				foundedPharmacy = foundedPharmacy.replace(']', '');
				var foundedPharmacyArray = foundedPharmacy.split(',');
				for (var value of foundedPharmacyArray) {
					if (value == 'Pharmacy not found') {
						$('#container').append(`<input class="textbox" type="text" id="${value}"  value="${value}" disabled>`)
						$('#btnPrescribe').attr("disabled", true);
					} else {
						$('#container')
							.append(`<input type="checkbox" id="${value}" name="interest" value="${value}">`)
							.append(`<label for="${value}">${value}</label></div>`)
							.append(`<br>`);
					}
				}
			},
			error: function (message) {
				alert("Failed")
			}
		});
	}
});
