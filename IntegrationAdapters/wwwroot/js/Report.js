$(document).ready(function () {
	$("#btnReport").click(function () {
		var start = $("#startDate").val();
		var end = $("#endDate").val();
		$.post({
			url: '../filetransfer/report',
			data: JSON.stringify({ start: start, end: end}),
			contentType: 'application/json',
			success: function (data) {
				alert("Succes sent");
				location.href = "../index.html";
			},
			error: function (message) {
				alert("Failed sent")
			}
		});
	});
	$("#btnReportHttp").click(function () {
		var start = $("#startDate").val();
		var end = $("#endDate").val();
		$.post({
			url: '../filetransfer/reportHttp',
			data: JSON.stringify({ start: start, end: end }),
			contentType: 'application/json',
			success: function (data) {
				alert("Succes sent");
				location.href = "../index.html";
			},
			error: function (message) {
				alert("Failed sent")
			}
		});
	});
});
