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
                                                <td><input type="text" class="col"/></td>
                                                <td><label>in &nbsp</label>
                                                    <select class="col">
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
                                                <select class="col">
                                                    <option disabled>Please select one</option>
                                                    <option>AND</option>
                                                    <option>OR</option>
                                                    <option>AND NOT</option>
                                                 </select>
                                            </td>                                    
                                            <td><input type="text" class="col"/></td>
                                            <td><label>in &nbsp</label>
                                                <select class="col">
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
                                                <select class="col">
                                                    <option disabled>Please select one</option>
                                                    <option>AND</option>
                                                    <option>OR</option>
                                                    <option>AND NOT</option>
                                                </select>
                                            </td>                                    
                                            <td><input type="text" class="col"/></td>
                                            <td><label>in &nbsp</label>
                                                <select class="col">
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
                                                <select class="col">
                                                    <option disabled>Please select one</option>
                                                    <option>AND</option>
                                                    <option>OR</option>
                                                    <option>AND NOT</option>
                                                </select>
                                             </td>                                    
                                             <td><input type="text" class="col"/></td>
                                             <td><label>in &nbsp</label>
                                                <select class="col">
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
                        
                        <input type="checkbox"/>
                        <label>Approximate search</label>
                        </div><br/><br/>
                        <div class="row">
                            <label>&nbsp&nbsp Datum od &nbsp&nbsp</label><input type="date"></input>
                            <label>&nbsp&nbsp do &nbsp&nbsp</label><input type="date"></input>
                        </div><br/><br/>
                        <button class="btnSearch btn-info btn-lg">Search</button>
                        <div class="container"><br/><hr/><br/>
                         <div class="row">
                            <h4>Rezultat pretrage:</h4>    
                         </div><br/>
                         <table style="width: 100%">
                         <th>Recept DATUM</th>
                         <tr>lek-cena-tip-opis</tr>
                         <tr>opis</tr>
                         </table><br/>
                         <table style="width: 100%">
                         <th>pregeld DATUM -tip</th>
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
        }
    }
});