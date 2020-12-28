function drawTableMedicine(data) {

    let table = '';
    for (i in data) {
        table += `<tr id="` + data[i].id + `">
			<td>`+ data[i].medicineName + `</td>
            <td>`+ data[i].quantity + `</td>
			</tr>`;
    }
    $('#medicineTable').html(table);
}
function drawModalMedicineTable(data) {

    let table = '';
    for (i in data) {
        table += `<tr id="` + data[i].id + `">
			<td>`+ data[i].medicineName + `</td>
            <td>`+ data[i].quantity + `</td>
			</tr>`;
    }
    $('#modalMedicineTable').html(table);
}
var x = 0;
var tenderName = '';
function drawMedicineForOfferTable(data) {
    let table = '';
    x = 0;
    for (i in data) {
        table += `<tr id="` + data[i].id  + `">
			<td style="color:coral" id="` + x + `">`+ data[i].medicineName + `</td>
            <td ><input class="textbox" type="text" placeholder="Quantity offer..." id="Q` + x + `" ></td>
            <td ><input class="textbox" type="text"  placeholder="Price offer..." id="P` + x + `"></td>
			</tr>`;
            x++;
    }
    $('#table-make-offer').html(table);
}
function drawTable(data) {
    let table = '';
    for (i in data) {
        if (data[i].isActive == true) {
            var finishdate = data[i].finishDate.split('T');
            table += `<tr id="` + data[i].tenderName + `">
		    <td>`+ data[i].tenderName + `</td>
			<td>`+ finishdate[0] + `</td>
            <td ><input name="medicinesButton" id="`+ data[i].tenderName + `"  type = 'button' style = "background-color:coral" class="btn btn-primary" value="Medicines" ></input ></td >
			<td ><input name="offerButton" id="`+ data[i].tenderName + `"  type = 'button' style = "background-color:coral" class="btn btn-primary" value="Make offer" ></input ></td >
			</tr>`;
        }
    }
    $('#tenderTable').html(table);
    $("input:button[name=medicinesButton]").click(function () {
        $.get({
            url: '../tender/getAllMedicines/' + this.id,
            contentType: 'application/json',
            success: function (data) {
                drawModalMedicineTable(data);
            },
            error: function (message) {
                alert("Failed")
            }
        })

    });
}

$(document).ready(function () {
    $("#btnAddMedicine").click(function () {
        var Id = Math.floor(Math.random() * 100).toString();
        var TenderName = $("#txtTenderName").val();
        var MedicineName = $("#txtMedicineName").val();
        var Quantity = parseInt($("#txtQuantity").val());
        $.post({
            url: '../tender/addMedicine',
            data: JSON.stringify({ Id: Id, TenderName: TenderName, MedicineName: MedicineName, Quantity: Quantity }),
            contentType: 'application/json',
            success: function () {
                $.get({
                    url: '../tender/getAllMedicines/' + TenderName,
                    contentType: 'application/json',
                    success: function (data) {
                        drawTableMedicine(data);
                        location.href = "#";
                    },
                    error: function (message) {
                        alert("Failed")
                    }
                })
            },
            error: function (message) {
                alert("Failed to add medicine")
            }
        });
    });
    $("#btnPublishTender").click(function () {
        var TenderName = $("#txtTenderName").val();
        var FinishDate = $("#txtFinishDate").val();
        var IsActive = true;
        $.post({
            url: '../tender/createTender',
            data: JSON.stringify({ TenderName: TenderName, FinishDate: FinishDate, IsActive: IsActive }),
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
   
    var modal = document.getElementById('modal-make-offer');
    var modalMedicines = document.getElementById('modal-medicines')
    var spanMedicine = document.getElementsByClassName("closeMedicine")[0];
    var span = document.getElementsByClassName("close")[0];
    span.onclick = function () {
        modal.style.display = "none";
    }
   
   
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
    spanMedicine.onclick = function () {
        modalMedicines.style.display = "none";
    }
    window.onclick = function (event) {
        if (event.target == modalMedicines) {
            modalMedicines.style.display = "none";
        }
    }
    spanMedicine.onclick = function () {
        modalMedicines.style.display = "none";
    }
    window.onclick = function (event) {
        if (event.target == modalMedicines) {
            modalMedicines.style.display = "none";
        }
    }

    $('#tenderTable').on('click', 'input:button[name=offerButton]', function (event) {
        tenderName = this.id;
        $.get({
            url: '../tender/getAllMedicines/' + this.id,
            contentType: 'application/json',
            success: function (data) {
                drawMedicineForOfferTable(data);
            },
            error: function (message) {
                alert("Failed")
            }
        })
        modal.style.display = "block";
    })

    $('#tenderTable').on('click', 'input:button[name=medicinesButton]', function (event) {
        modalMedicines.style.display = "block";
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
    });
   
    $('#buttonSendOffer').click(function () {
        var CompanyName = $('#txtCompanyName').val();
        var CompanyEmail = $('#txtEmail').val();
        var TenderName = tenderName;
        for (i = 0; i < x; i++) {
            if ($('#Q' + i).val() == '' || $('#P' + i).val()=='' ) {
                continue;
            }
            var Quantity = parseInt($('#Q' + i).val());
            var Price = parseInt($('#P' + i).val());
            var MedicineName = document.getElementById(i).innerText;
            var Id = Math.floor(Math.random() * 100).toString();       
            $.post({
                url: '../tender/addOffer',
                data: JSON.stringify({ Id: Id, CompanyEmail: CompanyEmail, CompanyName: CompanyName, TenderName: TenderName, MedicineName: MedicineName, Quantity: Quantity, Price: Price }),
                contentType: 'application/json',
                success: function () {
                    modal.style.display = "none";
                    alert("Succesfully added offer")
                },
                error: function (message) {
                    alert("Failed to add offer")
                }
            });
        }
    }   
    )
});