$(document).ready(function () {
	$("#btnProcurement").click(function () {
		var MedicineName = $("#txtMedicine").val();
		var Quantity = parseInt($("#txtQuantity").val());
		$.get({
			url: '../medicine/getMedicine/' + MedicineName + '/' + Quantity,
			contentType: 'application/json',
			success: function (foundedMedicine) {
				var foundedMedicine = foundedMedicine.split('#');

				if (foundedMedicine == "Medicine not found") {
					$('#container').html(`<input class="textbox" type="text" id="${foundedMedicine}"  value="Medicine not found!" disabled>`)
				} else {
					$.post({
						url: '../medicine/addMedicine/' + foundedMedicine[0] + '/' + foundedMedicine[1] + '/' + Quantity,
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
});