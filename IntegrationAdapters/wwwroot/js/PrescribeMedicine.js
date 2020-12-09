$(document).ready(function () {
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
});
