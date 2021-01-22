$(document).ready(function () {
	$("#btnReport").click(function () {
		var start = $("#startDate").val();
		var end = $("#endDate").val();
		$.post({
			url: 'http://localhost:63251/filetransfer/report/' + start + '/' + end,
			contentType: 'application/json',
			success: function (data) {
				alert("Succes sent");
				location.href = "../index.html";
			},
			error: function (message) {
				alert("Failed sent. Maybe it's a problem with server. Please try later...")
			}
		});
	});
});
