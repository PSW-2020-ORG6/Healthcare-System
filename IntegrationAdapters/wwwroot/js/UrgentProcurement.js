var MedicineName;
var Quantity;
$(document).ready(function () {
	$("#btnProcurement").click(function () {
		var MedicineName = $("#txtMedicine").val();
		var Quantity = parseInt($("#txtQuantity").val());
		$.get({
			url: 'http://localhost:63251/medicine/getMedicine/' + MedicineName + '/' + Quantity,
			contentType: 'application/json',
			success: function (foundedMedicine) {
				var foundedMedicine = foundedMedicine.split('#');

				if (foundedMedicine == "Medicine not found") {
					$('#container').html(`<p><b>Pharmacy with wanted medication not found!</b></p>`)
				} else {
					$.post({
						url: 'http://localhost:63251/medicine/addMedicine/' + foundedMedicine[0] + '/' + foundedMedicine[1] + '/' + Quantity,
						contentType: 'application/json',
						success: function (data) {
							alert("Success procurement!");
							$('#container').html(``)
						},
						error: function (message) {
							$('#container').html(`<input class="textbox" type="text" id="${foundedMedicine}"  value="Medicine already exists!" disabled>`)
						}
					});
				}
				
			},
			error: function (message) {
				alert("Failed")
			}
		});
	});
	$("#btnProcurementGrpc").click(function () {
	    MedicineName = $("#txtMedicine").val();
	    Quantity = parseInt($("#txtQuantity").val());
		var IsPharmacyApproved = false;
		$.post({
			url: 'http://localhost:63251/medicine/sendMessageGrpc',
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
		$.get({
			url: 'http://localhost:63251/medicine/getMessageGrpc',
			contentType: 'application/json',
			success: function (data) {
					if (data == '[Pharmacy not found]') {
						$('#container').html(`<p><b>Pharmacy with wanted medication not found!</b></p>`)
					} else {
						$.post({
							url: 'http://localhost:63251/medicine/addMedicine/' + Math.random() + '/' + MedicineName + '/' + Quantity,
							contentType: 'application/json',
							success: function (data) {
								alert("Success procurement!");
								$('#container').html(``)
							},
							error: function (message) {
								$('#container').html(`<input class="textbox" type="text" id="${MedicineName}"  value="Medicine already exists!" disabled>`)
							}
						});
					}
			},
			error: function (message) {
				alert("Failed")
			}
		});
	}
});