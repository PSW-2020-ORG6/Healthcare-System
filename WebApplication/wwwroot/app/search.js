Vue.component("search", {
    data: function () {
        return {
            yes: false,
            rowAdvanced: 0,
            rowSimple: 0,
            advancedSearches: [false,false,false],
            simpleSearches: [false,false,false],
            search: null
        }
    },
    template:
    `
    <div id="search">
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
                    <div id="simpleSearch" class="container tab-pane active">
                        <div class="container">
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
                                                <td><input id="textSimple1" type="text" class="col"/></td>
                                                <td><label>in &nbsp</label>
                                                    <select class="col" id="selectSimple1">
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
                                             </tr>
                                        <tr v-if="simpleSearches[0]">   
                                            <td></td> 
                                            <td><input id="textSimple2" type="text" class="col"/></td>
                                            <td><label>in &nbsp</label>
                                                <select class="col" id="selectSimple2">
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
                                                <button class="circledelete" v-on:click="DeleteRowSimple(), simpleSearches[0]=false"><i class="fa fa-close""></i></button>                           
                                            </td>
                                        </tr>
                                        <tr v-if="simpleSearches[1]">
                                            <td></td>                                    
                                            <td><input id="textSimple3" type="text" class="col"/></td>
                                            <td><label>in &nbsp</label>
                                                <select class="col" id="selectSimple3">
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
                                                <button class="circledelete" v-on:click="DeleteRowSimple(), simpleSearches[1]=false"><i class="fa fa-close""></i></button>                           
                                            </td>
                                        </tr>
                                        <tr v-if="simpleSearches[2]">
                                            <td></td>                                    
                                             <td><input id="textSimple4" type="text" class="col"/></td>
                                             <td><label>in &nbsp</label>
                                                <select class="col" id="selectSimple4">
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
                                                <button class="circledelete" v-on:click="DeleteRowSimple(), simpleSearches[2]=false"><i class="fa fa-close""></i></button>                           
                                            </td>
                                        </tr>
                                        <tr>
                                            <button v-if="rowSimple<3" class="circleadd" v-on:click="AddRowSimple()"><i class="fa fa-plus"></i></button><br/><br/>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div><br/><br/>
                        <div class="row">
                            <label>&nbsp&nbsp Date from &nbsp&nbsp</label><input id="dateSimpleFrom" type="date"></input>
                            <label>&nbsp&nbsp to &nbsp&nbsp</label><input id="dateSimpleTo" type="date"></input>
                        </div><br/><br/>
                        <table>
                            <button class="btnSearch btn-info btn-lg" v-on:click="SearchSimple()">Search</button>
                        </table>
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
                                                <td><input id="textAdvanced1" type="text" class="col"/></td>
                                                <td><label>in &nbsp</label>
                                                    <select class="col" id="selectAdvanced1">
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
                                        <tr v-if="advancedSearches[0]">
                                            <td>
                                                <select class="col">
                                                    <option disabled>Please select one</option>
                                                    <option>AND</option>
                                                    <option>OR</option>
                                                    <option>AND NOT</option>
                                                 </select>
                                            </td>                                    
                                            <td><input id="textAdvanced2" type="text" class="col"/></td>
                                            <td><label>in &nbsp</label>
                                                <select class="col" id="selectAdvanced22">
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
                                                <button class="circledelete" v-on:click="DeleteRowAdvanced(), advancedSearches[0]=false"><i class="fa fa-close""></i></button>                           
                                            </td>
                                        </tr>
                                        <tr v-if="advancedSearches[1]">
                                            <td>
                                                <select class="col"  id="selectAdvanced31">
                                                    <option disabled>Please select one</option>
                                                    <option>AND</option>
                                                    <option>OR</option>
                                                    <option>AND NOT</option>
                                                </select>
                                            </td>                                    
                                            <td><input id="textAdvanced3" type="text" class="col"/></td>
                                            <td><label>in &nbsp</label>
                                                <select class="col" id="selectAdvanced32">
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
                                                <button class="circledelete" v-on:click="DeleteRowAdvanced(), advancedSearches[1]=false"><i class="fa fa-close""></i></button>                           
                                            </td>
                                        </tr>
                                        <tr v-if="advancedSearches[2]">
                                            <td>
                                                <select class="col" id="selectAdvanced41">
                                                    <option disabled>Please select one</option>
                                                    <option>AND</option>
                                                    <option>OR</option>
                                                    <option>AND NOT</option>
                                                </select>
                                             </td>                                    
                                             <td><input id="textAdvanced4" type="text" class="col"/></td>
                                             <td><label>in &nbsp</label>
                                                <select class="col" id="selectAdvanced42">
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
                                                <button class="circledelete" v-on:click="DeleteRowAdvanced(), advancedSearches[2]=false"><i class="fa fa-close""></i></button>                           
                                            </td>                                           
                                        </tr>
                                        <tr>
                                            <button v-if="rowAdvanced<3" class="circleadd" v-on:click="AddRowAdvanced()"><i class="fa fa-plus"></i></button><br/><br/>
                                        </tr>
                                   </tbody>
                                </table>
                            </div>
                        </div><br/><br/>
                        <div class="row">
                            <label>&nbsp&nbsp Date from &nbsp&nbsp</label><input id="dateAdvancedFrom" type="date"></input>
                            <label>&nbsp&nbsp to &nbsp&nbsp</label><input id="dateAdvancedTo" type="date"></input>
                        </div><br/><br/>
                        <table>
                            <button class="btnSearch btn-info btn-lg" v-on:click="AdvancedSearch()">Search</button>
                        </table>
                    </div>
                </div>
            </div>
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
                 </div><br/>
                 <table style = "width: 100%" v-for="s in search" >
                       <th>{{s.type}} - {{s.date}}</th>
                       <tr>{{s.text.split(";")[0]}}</tr>
                       <tr>{{s.text.split(";")[1]}}</tr>
                       <tr>{{s.text.split(";")[2]}}</tr><br/>
                 </table>
            </div><br/>
        </div> 
</div>
	`,
    methods: {
        AddRowAdvanced: function () {
            if (!this.advancedSearches[0])
                this.advancedSearches[0] = true
            else if (!this.advancedSearches[1])
                this.advancedSearches[1] = true
            else if (!this.advancedSearches[2])
                this.advancedSearches[2] = true
            this.rowAdvanced += 1
        },
        AddRowSimple: function () {
            if (!this.simpleSearches[0])
                this.simpleSearches[0] = true
            else if (!this.simpleSearches[1])
                this.simpleSearches[1] = true
            else if (!this.simpleSearches[2])
                this.simpleSearches[2] = true
            this.rowSimple += 1
        },
        DeleteRowAdvanced: function () {
            this.rowAdvanced -= 1
        },
        DeleteRowSimple: function () {
            this.rowSimple -= 1
        },
        AdvancedSearch: function () {
            var date = "'" + document.getElementById("dateAdvancedFrom").value + "' and '" + document.getElementById("dateAdvancedTo").value + "'"
            if (this.ValidateAdvancedSearch()) {
                var prescriptionSearch = this.PrescriptionAdvancedSearch()
                var reportSearch = this.ReportAdvancedSearch()
                axios
                    .get('/user/advancedSearch', { params: { prescriptionSearch: prescriptionSearch, reportSearch: reportSearch, date: date } })
                    .then(response => {
                        this.search = response.data
                    })
                    .catch(error => {
                        alert(error)
                    })
            }
        },
        PrescriptionAdvancedSearch: function () {
            var advanced = '';
            if (document.getElementById("selectAdvanced1").value == 'Medicine name' || document.getElementById("selectAdvanced1").value == 'Medicine type' || document.getElementById("selectAdvanced1").value == 'All')
                advanced += " ," + document.getElementById("textAdvanced1").value + "," + document.getElementById("selectAdvanced1").value
            if (this.advancedSearches[0] && (document.getElementById("selectAdvanced22").value == 'Medicine name' || document.getElementById("selectAdvanced22").value == 'Medicine type' || document.getElementById("selectAdvanced22").value == 'All')) {
                if (advanced == '')
                    advanced += "," + document.getElementById("textAdvanced2").value + "," + document.getElementById("selectAdvanced22").value
                else
                    advanced += ";" + document.getElementById("selectAdvanced21").value + "," + document.getElementById("textAdvanced2").value + "," + document.getElementById("selectAdvanced1").value
            }
            if (this.advancedSearches[1] && (document.getElementById("selectAdvanced32").value == 'Medicine name' || document.getElementById("selectAdvanced32").value == 'Medicine type' || document.getElementById("selectAdvanced32").value == 'All')) {
                if (advanced == '')
                        advanced += "," + document.getElementById("textAdvanced3").value + "," + document.getElementById("selectAdvanced32").value
                else
                        advanced += ";" + document.getElementById("selectAdvanced31").value + "," + document.getElementById("textAdvanced3").value + "," + document.getElementById("selectAdvanced32").value
            }
            if (this.advancedSearches[2] && (document.getElementById("selectAdvanced42").value == 'Medicine name' || document.getElementById("selectAdvanced42").value == 'Medicine type' || document.getElementById("selectAdvanced42").value == 'All')) {
                if (advanced == '')
                    advanced += ";" + document.getElementById("selectAdvanced41").value + "," + document.getElementById("textAdvanced4").value + "," + document.getElementById("selectAdvanced42").value
                else
                    advanced += ";" + document.getElementById("selectAdvanced41").value + "," + document.getElementById("textAdvanced4").value + "," + document.getElementById("selectAdvanced42").value
            }
            return advanced
        },
        ReportAdvancedSearch: function () {
            var advanced = '';
            if (document.getElementById("selectAdvanced1").value == 'Procedure type' || document.getElementById("selectAdvanced1").value == 'Patient reports' || document.getElementById("selectAdvanced1").value == 'Specialist reports' || document.getElementById("selectAdvanced1").value == 'Doctor reports' || document.getElementById("selectAdvanced1").value == 'All')
                advanced += " ," + document.getElementById("textAdvanced1").value + "," + document.getElementById("selectAdvanced1").value
            if (this.advancedSearches[0] && (document.getElementById("selectAdvanced22").value == 'Procedure type' || document.getElementById("selectAdvanced22").value == 'Patient reports' || document.getElementById("selectAdvanced22").value == 'Specialist reports' || document.getElementById("selectAdvanced22").value == 'Doctor reports' || document.getElementById("selectAdvanced22").value == 'All')) {
                if (advanced == '')
                    advanced += "," + document.getElementById("textAdvanced2").value + "," + document.getElementById("selectAdvanced22").value
                else
                    advanced += ";" + document.getElementById("selectAdvanced21").value + "," + document.getElementById("textAdvanced2").value + "," + document.getElementById("selectAdvanced22").value
            }
            if (this.advancedSearches[1] && (document.getElementById("selectAdvanced32").value == 'Procedure type' || document.getElementById("selectAdvanced32").value == 'Patient reports' || document.getElementById("selectAdvanced32").value == 'Specialist reports' || document.getElementById("selectAdvanced32").value == 'Doctor reports' || document.getElementById("selectAdvanced32").value == 'All')) {
                if (advanced == '')
                    advanced += "," + document.getElementById("textAdvanced3").value + "," + document.getElementById("selectAdvanced32").value
                else
                    advanced += ";" + document.getElementById("selectAdvanced31").value + "," + document.getElementById("textAdvanced3").value + "," + document.getElementById("selectAdvanced32").value
            }
            if (this.advancedSearches[2] && (document.getElementById("selectAdvanced42").value == 'Procedure type' || document.getElementById("selectAdvanced42").value == 'Patient reports' || document.getElementById("selectAdvanced42").value == 'Specialist reports' || document.getElementById("selectAdvanced42").value == 'Doctor reports' || document.getElementById("selectAdvanced42").value == 'All')) {
                if (advanced == '')
                    advanced += "," + document.getElementById("textAdvanced4").value + "," + document.getElementById("selectAdvanced42").value
                else
                    advanced += ";" + document.getElementById("selectAdvanced41").value + "," + document.getElementById("textAdvanced4").value + "," + document.getElementById("selectAdvanced42").value
            }
            return advanced
        },
        ValidateAdvancedSearch: function () {
            if (document.getElementById("textAdvanced1").value == "")
                alert("All fields must be filled!")
            else if (this.advancedSearches[0] && document.getElementById("textAdvanced2").value == "")
                 alert("All fields must be filled!")
            else if (this.advancedSearches[1] && document.getElementById("textAdvanced3").value == "")
                alert("All fields must be filled!")
            else if (this.advancedSearches[2] && document.getElementById("textAdvanced4").value == "")
                alert("All fields must be filled!")
            else
                return true
            return false
        },
        ValidateSimpleSearch: function () {
            if (document.getElementById("textSimple1").value == "")
                alert("All fields must be filled!")
            else if (this.simpleSearches[0] && document.getElementById("textSimple2").value == "")
                alert("All fields must be filled!")
            else if (this.simpleSearches[1] && document.getElementById("textSimple3").value == "")
                 alert("All fields must be filled!")
            else if (this.simpleSearches[2] && document.getElementById("textSimple4").value == "")
                 alert("All fields must be filled!")
            else
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
        },
        SearchSimple: function () {
            var date = "'" + document.getElementById("dateSimpleFrom").value + "' and '" + document.getElementById("dateSimpleTo").value + "'"
            if (this.ValidateSimpleSearch()) {
                var prescriptionSimpleSearch = this.PrescriptionSimpleSearch()
                var reportSimpleSearch = this.ReportSimpleSearch()
                axios
                    .get('/user/advancedSearch', { params: { prescriptionSearch: prescriptionSimpleSearch, reportSearch: reportSimpleSearch, date: date } })
                    .then(response => {
                        this.search = response.data
                    })
                    .catch(error => {
                        alert(error)
                    })
            }
        },
        PrescriptionSimpleSearch: function () {
            var simple = '';
            if (document.getElementById("selectSimple1").value == 'Medicine name' || document.getElementById("selectSimple1").value == 'Medicine type' || document.getElementById("selectSimple1").value == 'All')
                simple += " ," + document.getElementById("textSimple1").value + "," + document.getElementById("selectSimple1").value
            if (this.simpleSearches[0] && (document.getElementById("selectSimple2").value == 'Medicine name' || document.getElementById("selectSimple2").value == 'Medicine type' || document.getElementById("selectSimple2").value == 'All')) {
                if (simple == '')
                    simple += "," + document.getElementById("textSimple2").value + "," + document.getElementById("selectSimple2").value
                else
                    simple += ";" + "AND" + "," + document.getElementById("textSimple2").value + "," + document.getElementById("selectSimple2").value
            }
            if (this.simpleSearches[1] && (document.getElementById("selectSimple3").value == 'Medicine name' || document.getElementById("selectSimple3").value == 'Medicine type' || document.getElementById("selectSimple3").value == 'All')) {
                if (simple == '')
                    simple += "," + document.getElementById("textSimple3").value + "," + document.getElementById("selectSimple3").value
                else
                        simple += ";" + "AND" + "," + document.getElementById("textSimple3").value + "," + document.getElementById("selectSimple3").value
            }
            if (this.simpleSearches[2] && (document.getElementById("selectSimple4").value == 'Medicine name' || document.getElementById("selectSimple4").value == 'Medicine type' || document.getElementById("selectSimple4").value == 'All')) {
                if (simple == '')
                    simple += ";" + "AND" + "," + document.getElementById("textSimple4").value + "," + document.getElementById("selectSimple4").value
                else
                    simple += ";" + "AND" + "," + document.getElementById("textSimple4").value + "," + document.getElementById("selectSimple4").value
            }
            return simple
        },
        ReportSimpleSearch: function () {
            var simple = '';
            if (document.getElementById("selectSimple1").value == 'Procedure type' || document.getElementById("selectSimple1").value == 'Patient reports' || document.getElementById("selectSimple1").value == 'Specialist reports' || document.getElementById("selectSimple1").value == 'Doctor reports' || document.getElementById("selectSimple1").value == 'All')
                simple += " ," + document.getElementById("textSimple1").value + "," + document.getElementById("selectSimple1").value
            if (this.simpleSearches[0] && (document.getElementById("selectSimple2").value == 'Procedure type' || document.getElementById("selectSimple2").value == 'Patient reports' || document.getElementById("selectSimple2").value == 'Specialist reports' || document.getElementById("selectSimple2").value == 'Doctor reports' || document.getElementById("selectSimple2").value == 'All')) {
                if (simple == '')
                    simple += "," + document.getElementById("textSimple2").value + "," + document.getElementById("selectSimple2").value
                else
                    simple += ";" + "AND" + "," + document.getElementById("textSimple2").value + "," + document.getElementById("selectSimple2").value
            }
            if (this.simpleSearches[1] && (document.getElementById("selectSimple3").value == 'Procedure type' || document.getElementById("selectSimple3").value == 'Patient reports' || document.getElementById("selectSimple3").value == 'Specialist reports' || document.getElementById("selectSimple3").value == 'Doctor reports' || document.getElementById("selectSimple3").value == 'All')) {
                if (simple == '')
                    simple += "," + document.getElementById("textSimple3").value + "," + document.getElementById("selectSimple3").value
                else
                    simple += ";" + "AND" + "," + document.getElementById("textSimple3").value + "," + document.getElementById("selectSimple3").value
            }
            if (this.simpleSearches[2] && (document.getElementById("selectSimple4").value == 'Procedure type' || document.getElementById("selectSimple4").value == 'Patient reports' || document.getElementById("selectSimple4").value == 'Specialist reports' || document.getElementById("selectSimple4").value == 'Doctor reports' || document.getElementById("selectSimple4").value == 'All')) {

                if (simple == '')
                    simple += "," + document.getElementById("textSimple4").value + "," + document.getElementById("selectSimple4").value
                else
                    simple += ";" + "AND" + "," + document.getElementById("textSimple4").value + "," + document.getElementById("selectSimple4").value
            }
            return simple
        },
    }
});