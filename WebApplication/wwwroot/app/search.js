Vue.component("search", {
    data: function () {
        return {
            yes: false,
            rowPrescriptio: 0,
            rowReport: 0
        }
    },
    template:
        `
        <div class= "container">
            <br /><h3 class="text">Search</h3><br />
            <ul class="nav nav-tabs" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" data-toggle="tab" href="#simpleSearch">Simple</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" data-toggle="tab" href="#advancedSearch">Advinced</a>
                </li>
            </ul>
            <div>
                <div class="tab-content">
                    <div id="simpleSearch" class="container tab-pane active"><br/>
                        <div class="container">
                            <div class="row">                
                        </div>
                      </div>
                    </div>
                    <div id="advancedSearch" class="container tab-pane fade"><br/>
                        <div class="container">
                        <br/><h4>Prescription</h4><br/>
                            <div class="row">
                                 <table id="prescription" style="width: 100%">
                                    <colgroup>
                                       <col style="width: 20%;">
                                       <col style="width: 50%;">
                                       <col style="width: 30%;">
                                    </colgroup>
                                    <tbody>
                                        <tr>
                                         <td>
                                            <select class="col">
                                              <option disabled>Please select one</option>
                                              <option>AND</option>
                                              <option>OR</option>
                                              <option>AND NOT</option>
                                            </select>
                                        </td>                                    
                                         <td><input type="text" class="col"/></td>
                                         <td>
                                        <select class="col">
                                          <option disabled>Please select one</option>
                                          <option>name</option>
                                          <option>type</option>
                                        </select>
                                        </td>
                                       </tr>
                                     </tbody>
                                  </table>
                            </div>
                            <button v-if="rowPrescriptio<3" class="circle" v-on:click="AddRowPrescription()"><i class="fa fa-plus"></i></button>
                            <br/><br/>
                            <br/><h4>Report</h4><br/>
                            <div class="row">
                                 <table id="report" style="width: 100%">
                                    <colgroup>
                                       <col style="width: 20%;">
                                       <col style="width: 50%;">
                                       <col style="width: 30%;">
                                    </colgroup>
                                    <tbody>
                                        <tr>
                                         <td>
                                            <select class="col">
                                              <option disabled>Please select one</option>
                                              <option>AND</option>
                                              <option>OR</option>
                                              <option>AND NOT</option>
                                            </select>
                                        </td>                                    
                                         <td><input type="text" class="col"/></td>
                                         <td>
                                        <select class="col">
                                          <option disabled>Please select one</option>
                                          <option>patient</option>
                                          <option>specialization</option>
                                          <option>doctor</option>
                                        </select>
                                        </td>
                                       </tr>
                                     </tbody>
                                  </table>
                            </div>
                            <button v-if="rowReport<3" class="circle" v-on:click="AddRowReport()"><i class="fa fa-plus"></i></button>
                        </div>
                         <br/><br/>
                        <button class="btn btn-info btn-lg">Search</button>
                    </div>
                </div>
            </div>
    </div> 
	`,
    methods: {
        AddRowPrescription: function() {
            var root = document.getElementById('prescription').getElementsByTagName('tbody')[0];
            var rows = root.getElementsByTagName('tr');
            this.yes = true;
            var clone = this.CloneEl(rows[rows.length - 1]);
            root.appendChild(clone);
            this.rowPrescriptio += 1;
        },
        AddRowReport: function () {
            var root = document.getElementById('report').getElementsByTagName('tbody')[0];
            var rows = root.getElementsByTagName('tr');
            this.yes = true;
            var clone = this.CloneEl(rows[rows.length - 1]);
            root.appendChild(clone);
            this.rowReport += 1;
        },
        CloneEl: function(el) {
            var clo = el.cloneNode(true);
            return clo;
        }
    }
});