Vue.component("search", {
    data: function () {
        return {
            yes: false,
            row: 0,
            second: false,
            third: false,
            fourth: false,
            search:null
        }
    },
    breforeMount() {
    },
    template:
    `
        <div class= "container">
            <br/><h3 class="text">Search - prescription and report</h3><br/>
            <ul class="nav nav-tabs" role="tablist">
                <li class="nav-item">
                    <a class=" nav-link active" data-toggle="tab" href="#simpleSearch">Simple</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" data-toggle="tab" href="#advancedSearch">Advanced</a>
                </li>
            </ul>
            <div>
                <div class="tab-content">
                    <div id="simpleSearch" class="container tab-pane active"><br/>
                        <div class="container">              
                        </div>
                    </div>
                    <div id="advancedSearch" class="container tab-pane fade">
                        <div class="container"><br/>
                                <div class="row">
                                    <table id="prescription" style="width: 100%">
                                        <colgroup>
                                           <col style="width: 20%;">
                                           <col style="width: 40%;">
                                           <col style="width: 35%;">
                                           <col style="width: 5%;">
                                        </colgroup>
                                        <tbody>
                                            <tr>
                                                <td align="center"><label>Search</label></td>                                    
                                                <td><input id="text1" type="text" class="col"/></td>
                                                <td><label>in &nbsp</label>
                                                    <select class="col" id="select1">
                                                        <option disabled>Please select one</option>
                                                        <option>All</option>
                                                        <option>Medicine name</option>
                                                        <option>Medicine type</option>
                                                        <option>Procedure type</option>
                                                        <option>Patient reports</option>
                                                        <option>Specialist reports</option>
                                                        <option>Doctor reports</option>
                                                    </select>
                                                 </td>
                                                 <td></td>
                                             </tr>
                                        <tr v-if="second">
                                            <td>
                                                <select class="col" id="select21">
                                                    <option disabled>Please select one</option>
                                                    <option>AND</option>
                                                    <option>OR</option>
                                                    <option>AND NOT</option>
                                                 </select>
                                            </td>                                    
                                            <td><input id="text2" type="text" class="col"/></td>
                                            <td><label>in &nbsp</label>
                                                <select class="col" id="select22">
                                                    <option disabled>Please select one</option>
                                                    <option>All</option>
                                                    <option>Medicine name</option>
                                                    <option>Medicine type</option>
                                                    <option>Procedure type</option>
                                                    <option>Patient reports</option>
                                                    <option>Specialist reports</option>
                                                    <option>Doctor reports</option>
                                                </select>
                                            </td>
                                            <td>
                                                <button class="circledelete" v-on:click="DeleteRow(), second=false"><i class="fa fa-close""></i></button>                           
                                            </td>
                                        </tr>
                                        <tr v-if="third">
                                            <td>
                                                <select class="col" id="select31">
                                                    <option disabled>Please select one</option>
                                                    <option>AND</option>
                                                    <option>OR</option>
                                                    <option>AND NOT</option>
                                                </select>
                                            </td>                                    
                                            <td><input id="text3" type="text" class="col"/></td>
                                            <td><label>in &nbsp</label>
                                                <select class="col" id="select32">
                                                    <option disabled>Please select one</option>
                                                    <option>All</option>
                                                    <option>Medicine name</option>
                                                    <option>Medicine type</option>
                                                    <option>Procedure type</option>
                                                    <option>Patient reports</option>
                                                    <option>Specialist report</option>
                                                    <option>Doctor reports</option>
                                                </select>
                                            </td>
                                            <td>
                                                <button class="circledelete" v-on:click="DeleteRow(), third=false"><i class="fa fa-close""></i></button>                           
                                            </td>
                                        </tr>
                                        <tr v-if="fourth">
                                            <td>
                                                <select class="col" id="select41">
                                                    <option disabled>Please select one</option>
                                                    <option>AND</option>
                                                    <option>OR</option>
                                                    <option>AND NOT</option>
                                                </select>
                                             </td>                                    
                                             <td><input id="text4" type="text" class="col"/></td>
                                             <td><label>in &nbsp</label>
                                                <select class="col" id="select42">
                                                    <option disabled>Please select one</option>
                                                    <option>All</option>
                                                    <option>Medicine name</option>
                                                    <option>Medicine type</option>
                                                    <option>Procedure type</option>
                                                    <option>Patient reports</option>
                                                    <option>Specialist reports</option>
                                                    <option>Doctor reports</option>
                                                </select>
                                              </td>
                                            <td>
                                                <button class="circledelete" v-on:click="DeleteRow(), fourth=false"><i class="fa fa-close""></i></button>                           
                                            </td>
                                       </tr>
                                   </tbody>
                                </table>
                            </div>
                            <button v-if="row<3" class="circleadd" v-on:click="AddRow()"><i class="fa fa-plus"></i></button><br/><br/>
                        </div><br/><br/>
                        <div class="row">
                            <label>&nbsp&nbsp Date from &nbsp&nbsp</label><input id="dateFrom" type="date" value="20-1-2011"></input>
                            <label>&nbsp&nbsp to &nbsp&nbsp</label><input id="dateTo" type="date"></input>
                        </div><br/><br/>
                        <button class="btnSearch btn-info btn-lg" v-on:click="AdvancedSearch()">Search</button>
                        <div class="container"><br/><hr/><br/>
                         <div class="row">
                            <h4>Search result:</h4>                      
                         </div><br/>
                         <div class="row"  style="width:300px">
                             <label>Sort by date:&nbsp&nbsp</label>
                             <select id="sort" style="height:30px" v-on:change="Sort()">
                                <option selected disabled>Select sort</option>
                                <option>Ascending</option>
                                <option>Descending</option>
                             </select>
                         </div>
                         <table style = "width: 100%" v-for="s in search" >
                            <th>{{s.type}} - {{s.date}}</th>
                            <tr>{{s.text.split(";")[0]}}</tr>
                            <tr>{{s.text.split(";")[1]}}</tr>
                            <tr>{{s.text.split(";")[2]}}</tr>
                         </table >
                    </div>
                    </div>
                </div>
            </div><br/>
        </div> 
	`,
    methods: {
        AddRow: function () {
            if (!this.second)
                this.second = true
            else if (!this.third)
                this.third = true
            else if (!this.fourth)
                this.fourth = true
            this.row += 1

        },
        DeleteRow: function () {
            this.row -= 1
        },
        AdvancedSearch: function () {
            var date = "'" + document.getElementById("dateFrom").value + "' and '" + document.getElementById("dateTo").value + "'"
            if (this.Validate()) {
                var prescriptionSearch = this.PrescriptionSearch()
                var reportSearch = this.ReportSearch()
                axios
                    .get('http://localhost:49900/user/advancedSearch', { params: { prescriptionSearch: prescriptionSearch, reportSearch: reportSearch, date: date } })
                    .then(response => {
                        this.search = response.data
                    })
                    .catch(error => {
                        alert(error)
                    })
            }
        },
        PrescriptionSearch: function () {
            var advanced = '';
            if (document.getElementById("select1").value == 'Medicine name' || document.getElementById("select1").value == 'Medicine type' || document.getElementById("select1").value == 'All')
                advanced += " ,"+document.getElementById("text1").value + "," + document.getElementById("select1").value
            if (this.second && (document.getElementById("select22").value == 'Medicine name' || document.getElementById("select22").value == 'Medicine type' || document.getElementById("select22").value == 'All')) {
                if (advanced == '')
                    advanced += "," + document.getElementById("text2").value + "," + document.getElementById("select22").value
                else
                    advanced += ";" + document.getElementById("select21").value + "," + document.getElementById("text2").value + "," + document.getElementById("select22").value
        }
            if (this.third && (document.getElementById("select32").value == 'Medicine name' || document.getElementById("select32").value == 'Medicine type' || document.getElementById("select32").value == 'All')) {
                if (advanced == '')
                    advanced += "," + document.getElementById("text3").value + "," + document.getElementById("select32").value
                else
                    if (advanced == '')
                        advanced += "," + document.getElementById("text3").value + "," + document.getElementById("select32").value
                    else
                        advanced += ";" + document.getElementById("select31").value + "," + document.getElementById("text3").value + "," + document.getElementById("select32").value
            }
            if (this.fourth && (document.getElementById("select42").value == 'Medicine name' || document.getElementById("select42").value == 'Medicine type' || document.getElementById("select42").value == 'All')) {
                if (advanced == '')
                    advanced += ";" + document.getElementById("select41").value + "," + document.getElementById("text4").value + "," + document.getElementById("select42").value
                else
                    advanced += ";" + document.getElementById("select41").value + "," + document.getElementById("text4").value + "," + document.getElementById("select42").value
            }
            return advanced
        },
        ReportSearch: function () {
            var advanced = '';
            if (document.getElementById("select1").value == 'Procedure type' || document.getElementById("select1").value == 'Patient reports' || document.getElementById("select1").value == 'Specialist reports' || document.getElementById("select1").value == 'Doctor reports' || document.getElementById("select1").value == 'All')
                advanced += " ,"+document.getElementById("text1").value + "," + document.getElementById("select1").value
            if (this.second && (document.getElementById("select22").value == 'Procedure type' || document.getElementById("select22").value == 'Patient reports' || document.getElementById("select22").value == 'Specialist reports' || document.getElementById("select22").value == 'Doctor reports' || document.getElementById("select22").value == 'All')) {
                if (advanced == '')
                    advanced += "," + document.getElementById("text2").value + "," + document.getElementById("select22").value
                else
                    advanced += ";" + document.getElementById("select21").value + "," + document.getElementById("text2").value + "," + document.getElementById("select22").value
            }
            if(this.third && (document.getElementById("select32").value == 'Procedure type' || document.getElementById("select32").value == 'Patient reports' || document.getElementById("select32").value == 'Specialist reports' || document.getElementById("select32").value == 'Doctor reports' || document.getElementById("select32").value == 'All')){
                if (advanced == '')
                    advanced += "," + document.getElementById("text3").value + "," + document.getElementById("select32").value
                else
                        advanced += ";" + document.getElementById("select31").value + "," + document.getElementById("text3").value + "," + document.getElementById("select32").value
            }
            if (this.fourth && (document.getElementById("select42").value == 'Procedure type' || document.getElementById("select42").value == 'Patient reports' || document.getElementById("select42").value == 'Specialist reports' || document.getElementById("select42").value == 'Doctor reports' || document.getElementById("select42").value == 'All')) {

                if (advanced == '')
                    advanced += "," + document.getElementById("text4").value + "," + document.getElementById("select42").value
                else
                    advanced += ";" + document.getElementById("select41").value + "," + document.getElementById("text4").value + "," + document.getElementById("select42").value
            }
            return advanced
        },
        Validate: function () {
            if (document.getElementById("text1").value == "")
                alert("All fields must be filled!")
            else if (this.second) {
                if (document.getElementById("text2").value == "")
                    alert("All fields must be filled!")
            } else if (this.third) {
                if (document.getElementById("text3").value == "")
                    alert("All fields must be filled!")
            } else if (this.fourth) {
                if (document.getElementById("text4").value == "")
                    alert("All fields must be filled!")
            }else
                return true
            return false
        },
        Sort: function () {
            var sort = document.getElementById("sort").value;
            var sorted = this.search
            if (sort == "Ascending") {
                for (var i = 0; i < sorted.length - 1; i++) {
                    for (var j = i + 1; j < sorted.length; j++) {
                        if (sorted[i].date.split(",")[1].split(" ")[2] > sorted[j].date.split(",")[1].split(" ")[2]) {
                            let tmp = sorted[i]
                            sorted[i] = sorted[j]
                            sorted[j] = tmp
                        } else if (sorted[i].date.split(",")[1].split("-")[2] == sorted[j].date.split(",")[1].split("-")[2] && sorted[i].date.split(",")[1].split(" ")[1] > sorted[j].date.split(",")[1].split(" ")[1]) {
                            let tmp = sorted[i]
                            sorted[i] = sorted[j]
                            sorted[j] = tmp
                            break
                        } else if (sorted[i].date.split(",")[1].split(" ")[1] == sorted[j].date.split(",")[1].split(" ")[1] && sorted[i].date.split(",")[1].split(",")[0] > sorted[j].date.split(" ")[1].split("-")[0]) {
                            let tmp = sorted[i]
                            sorted[i] = sorted[j]
                            sorted[j] = tmp
                        }
                    }
                }
            } else {
                for (var i = 0; i < sorted.length - 1; i++) {
                    for (var j = i + 1; j < sorted.length; j++) {
                        if (sorted[i].date.split(",")[1].split(" ")[2] < sorted[j].date.split(",")[1].split(" ")[2]) {
                            let tmp = sorted[i]
                            sorted[i] = sorted[j]
                            sorted[j] = tmp
                        } else if (sorted[i].date.split(",")[1].split(" ")[2] == sorted[j].date.split(",")[1].split(" ")[2] && sorted[i].date.split(",")[1].split(" ")[1] < sorted[j].date.split(",")[1].split(" ")[1]) {
                            let tmp = sorted[i]
                            sorted[i] = sorted[j]
                            sorted[j] = tmp
                        } else if (sorted[i].date.split(",")[1].split(" ")[1] == sorted[j].date.split(",")[1].split(" ")[1] && sorted[i].date.split(",")[1].split(" ")[0] < sorted[j].date.split(",")[1].split(" ")[0]) {
                            let tmp = sorted[i]
                            sorted[i] = sorted[j]
                            sorted[j] = tmp
                        }
                    }
                }
            }
            this.search = null
            this.search = sorted
        }
    }
});