function drawTable(data) {
	let table = '';
	for (i in data) {
		var dateFrom = data[i].dateFrom.split('T');
		var dateTo = data[i].dateTo.split('T');
		table += `<tr id="` + data[i].actionID +`">
			<td>`+ data[i].pharmacyName+ `</td>
			<td>`+ data[i].text + `</td>
			<td>`+ dateFrom[0] + `</td>
			<td>`+ dateTo[0] + `</td>
			<td><button id="publishButton" type='button' class = "form-style-4" >Publish</button></td>
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
	$('#actionsAndBenefitsTable').on('click','button',function () {
		var trid = $(event.target).closest('tr').attr('id');
		console.log('click')
		$.post({
			url: '../actionsandbenefits/publishActionsAndBenefits/'+trid, 
			contentType: 'multipart/form-data',
			success: function () {
				alert("Successfuly published");
			},
			error: function (message) {
				alert("Failed to publish")
			}
		})
	})
		
	});
