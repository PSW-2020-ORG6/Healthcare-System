function drawTable(data) {
    let table = '';
    for (i in data) {
        var finishdate = data[i].finishDate.split('T');
        table += `<tr id="` + data[i].tenderName + `">
		    <td>`+ data[i].tenderName + `</td>
			<td>`+ data[i].medicineName + `</td>
			<td>`+ data[i].quantity + `</td>
			<td>`+ finishdate[0] + `</td>
			<td ><button id="offerButton" type='button' style="background-color:coral" class="btn btn-primary" >Make offer</button></td>
			</tr>`;
    }
    $('#tenderTable').html(table);
}	
$(document).ready(function () {
    var modal = document.getElementById('modal-make-offer');
    var span = document.getElementsByClassName("close")[0];

    span.onclick = function () {
        modal.style.display = "none";
    }

    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

    $('#tenderTable').on('click', 'button', function (event) {
        modal.style.display = "block";
    })

    $.get({
        url: '../tender/getAllTenders',
        contentType: 'application/json',
        success: function (data) {
            drawTable(data);
        },
        error: function (message) {
            alert("Failed")
        }
    })
    $("#btnPublishTender").click(function () {
        var TenderName = $("#txtTenderName").val();
        var FinishDate = $("#txtFinishDate").val();
        var MedicineName = $("#txtMedicineName").val();
        var Quantity = parseInt($("#txtQuantity").val());
        $.post({
            url: '../tender/createTender',
            data: JSON.stringify({ TenderName: TenderName, MedicineName: MedicineName, Quantity: Quantity, FinishDate: FinishDate }),
            contentType: 'application/json',
            success: function () {
                alert("Succesfully published tender");
                location.href = "../index.html";
            },
            error: function (message) {
                alert("Failed to publish tender")
            }
        });
    });

});