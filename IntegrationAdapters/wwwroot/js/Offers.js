function drawTableOffer(data) {
    let table = '';
    let pomArrayEmail = new Array();
    let pomArrayTender = new Array();
    for (i in data) {
        if (pomArrayEmail.includes(data[i].companyEmail) && pomArrayTender.includes(data[i].tenderName)) {
            continue;
        }
        else {
            table += `<tr >
		    <td>`+ data[i].tenderName + `</td>
			<td>`+ data[i].companyName + `</td>
            <td>`+ data[i].companyEmail + `</td>
			<td><input name="offerButton" id="` + data[i].companyEmail + ";" + data[i].tenderName + `"  type = 'button' class="btn btn-primary" style="background-color:coral"  value="Offer" ></input >
            <td><input name="accept" id="accept` + data[i].companyEmail + ";" + data[i].tenderName + `" type = 'button' style = "background-color:lightgreen" class="btn btn-primary" value="Accept offer" ></input >
              </td >
			</tr>`;
            pomArrayEmail.push(data[i].companyEmail);
            pomArrayTender.push(data[i].tenderName);
        }
    }
    $('#offersTable').html(table);

    $("input:button[name=accept]").click(function () {
        id = this.id
        $.get({
            url: '../tender/acceptOffer/' + this.id,
            contentType: 'application/json',
            success: function (data) {
                alert("Success sent email!")
                $.get({
                    url: '../tender/clearAll/' + id,
                    contentType: 'application/json',
                    success: function () {
                        location.href = "Offers.html";

                    },
                    error: function (message) {
                        alert("Failed")
                    }
                });
            },
            error: function (message) {
                alert("Failed")
            }
        })

    });
}

function drawSpecificOfferTable(data) {
    let table = '';
    for (i in data) {
        table += `<tr>
			<td>`+ data[i].medicineName + `</td>
            <td>`+ data[i].quantity + `</td>
            <td>`+ data[i].price + `</td>
			</tr>`;
    }
    $('#modalOfferTable').html(table);
}
$(document).ready(function () {

    var modalMedicines = document.getElementById('modal-medicines')
    var spanMedicine = document.getElementsByClassName("closeMedicine")[0];
    spanMedicine.onclick = function () {
        modalMedicines.style.display = "none";
    }
    window.onclick = function (event) {
        if (event.target == modalMedicines) {
            modalMedicines.style.display = "none";
        }
    }
    $('#offersTable').on('click', 'input:button[name=offerButton]', function (event) {
        emailAndTender = this.id;
        $.get({
            url: '../tender/getAllOffersByEmailAndTender/' + emailAndTender,
            contentType: 'application/json',
            success: function (data) {
                drawSpecificOfferTable(data);
            },
            error: function (message) {
                alert("Failed")
            }
        })
        modalMedicines.style.display = "block";
    })

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
