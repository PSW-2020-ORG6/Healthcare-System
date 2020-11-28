function drawTable(data) {
	let table = '';
	for (i in data) {
		console.log('bdhkcbjkxz')
		table += `<tr>
			<td>`+ data[i].text + `</td>
			<td>`+ data[i].timestamp + `</td>
			</tr>`;
	}
	$('#actionsAndBenefitsTable').html(table);

}	

$(document).ready(function () {
		$.get({
			url: '../api/actionsandbenefits',
			contentType: 'application/json',
			success: function (data) {
				drawTable(data);
			},
			error: function (message) {
				alert("Failed")
			}
		});
	});
