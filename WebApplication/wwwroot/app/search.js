Vue.component("search", {
    data: function () {
        return {
            yes: false,
            row: 0,
            second: false,
            third: false,
            fourth: false
        }
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
                    <a class="nav-link" data-toggle="tab" href="#advancedSearch">Advinced</a>
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
                        
                        <input id="check" type="checkbox"/>
                        <label>Approximate search</label>
                        </div><br/><br/>
                        <div class="row">
                            <label>&nbsp&nbsp Date from &nbsp&nbsp</label><input id="dateFrom" type="date"></input>
                            <label>&nbsp&nbsp to &nbsp&nbsp</label><input id="dateTo" type="date"></input>
                        </div><br/><br/>
                        <button class="btnSearch btn-info btn-lg" v-on:click="AdvancedSearch()">Search</button>
                        <div class="container"><br/><hr/><br/>
                         <div class="row">
                            <h4>Search result:</h4>    
                         </div><br/>
                         <table style="width: 100%">
                         <th>Prescription datum</th>
                         <tr>lek-cena-tip-opis</tr>
                         <tr>opis</tr>
                         </table><br/>
                         <table style="width: 100%">
                         <th>Report datum -tip</th>
                         <tr>pacijent</tr>
                         <tr>lekar</tr>
                         <tr>opis</tr>
                         </table>
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
        CloneEl: function(el) {
            var clo = el.cloneNode(true);
            return clo;
        },
        DeleteRow: function () {
            this.row -= 1
        },
        AdvancedSearch: function () {
            var advanced = document.getElementById("text1").value + "," + document.getElementById("select1").value
            if (this.second)
                advanced +=";" + document.getElementById("select21").value +","+ document.getElementById("text2").value + "," +  document.getElementById("select22").value
            if (this.third) 
                advanced += ";" + document.getElementById("select31").value + "," + document.getElementById("text3").value+","+ document.getElementById("select32").value
            if (this.fourth) 
                advanced += ";" + document.getElementById("select41").value + "," + document.getElementById("text4").value + "," + document.getElementById("select42").value
            var date = document.getElementById("dateFrom").value + ";" + document.getElementById("dateTo").value
            axios
                .post('http://localhost:49900/user/advancedSearch', advanced, document.getElementById("check").checked,date)
                .then(response => {
                    alert("ok");
                })
                .catch(error => {
                    alert(error)
                })
        }
    }
});