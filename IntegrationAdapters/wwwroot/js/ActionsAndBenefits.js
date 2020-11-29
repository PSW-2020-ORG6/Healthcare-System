function drawTable(data) {
	let table = '';
	for (i in data) {
		var dateFrom = data[i].dateFrom.split('T');
		var dateTo = data[i].dateTo.split('T');
		table += `<tr>
			<td>`+ data[i].pharmacyName+ `</td>
			<td>`+ data[i].text + `</td>
			<td>`+ dateFrom[0] + `</td>
			<td>`+ dateTo[0] + `</td>
			<td><button id="publishButton" type='button'>Publish</button></td>
			</tr>`;
	}
	$('#actionsAndBenefitsTable').html(table);

}	

$(document).ready(function () {
		$.get({
			url: '../actionsandbenefits/getActionsAndBenefits',
			contentType: 'application/json',
			success: function (data) {
				drawTable(data);
			},
			error: function (message) {
				alert("Failed")
			}
		});

	/*$('#').click(function () {
		$.post({
			url: '../api/registration',
			data: JSON.stringify({ Key: Key, PharmacyName: PharmacyName, Url: Url, Subscribed: Subscribed }),
			contentType: 'application/json',
			success: function () {
				alert("Successfuly published");
			},
			error: function (message) {
				alert("Failed to publish")
			}
		})
	})*/

		
	});
