function drawTableOffer(data) {
   
    let table = '';
    for (i in data) {
        table += `<tr id="` + data[i].companyEmail + `">
		    <td>`+ data[i].tenderName + `</td>
			<td>`+ data[i].companyName + `</td>
            <td>`+ data[i].companyEmail + `</td>
			<td>`+ data[i].unitPrice + `</td>
            <td><input name="accept" id="accept"  type = 'button' style = "background-color:lightgreen" class="btn btn-primary" value="Accept offer" ></input >
                <input name="refuse" id="refuse"  type = 'button' style = "background-color:pink" class="btn btn-primary" value="Refuse offer" ></input ></br></td >
			</tr>`;
    }
    $('#offersTable').html(table);
}

$(document).ready(function () {
    $.get({
        url: '../tender/getAllOffers',
        contentType: 'application/json',
        success: function (data) {
            drawTableOffer(data);
        },
        error: function (message) {
            alert("Failed")
        }
    })
});
