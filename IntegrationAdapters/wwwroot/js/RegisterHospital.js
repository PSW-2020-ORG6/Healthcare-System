$(document).ready(function () {
	$("#btnRegister").click(function () {
		var phName = $("#txtPhName").val();
		var APIkey = $("#txtAPIKey").val();
		var url = $("#txtUrl").val();
		$.post({
			url: '../api/registration',
			data: JSON.stringify({ ApiKey: APIkey, PharmacyName: phName, Url: url }),
			contentType: 'application/json',
			success: function () {
				alert("Succes registration");
				location.href = "../index.html";
			},
			error: function (message) {
				alert("Neuspjesno")
			}
		});
	});
});
