Vue.component("admin", {
    data: function () {
        return {
            approvedFeedbacks: null,
            disapprovedFeedbacks: null,
            feedback: null,
            patients: null,
            surveyText: null,
            doctorId: null,
            statistics: [],
            doctorList: [],
            doctorsList: []
        }
    },
    beforeMount() {
        axios
            .get('http://localhost:49900/feedback/approved')
            .then(response => {
                this.approvedFeedbacks = response.data
            })
            .catch(error => {
                alert(error)
            })

        axios
            .get('http://localhost:49900/feedback/disapproved')
            .then(response => {
                this.disapprovedFeedbacks = response.data
            })
            .catch(error => {
                alert(error)
            })
        axios
            .get('http://localhost:49900/patient/all')
            .then(response => {
                this.patients = response.data
            })
            .catch(error => {
                alert(error)
            })





        axios
            .get('http://localhost:49900/survey/getDoctors', { params: { patientId: "0003" } })
            .then(response => {
                this.doctorsList = response.data
            })
            .catch(error => {
                alert(error)
            })





    },
    template: `
    <div>
        <br></br>
        <br></br>
        <br></br>
            <div class="row">
                  <div class="col">      
                   </td></div>
                  <div class="col"></div>
                  <div class="col">
                    <select id="doctorSelect" class="browser-default custom-select" v-model = "doctorId">
                         <option div  v-for="(doctor) in doctorsList" v-bind:value="doctor">{{doctor}}</option>
                    </select>
                </div>
                 <div class="col">
                    <button class="btn btn-info btn-lg" v-on:click="getStatistics()">Show statistics</button>
                </div>
                 <div class="col">
  
                </div>
            </div>

         <br></br>
    
        <div >
            <table id="statisticTable" class="table table-bordered  ">
                 <thead>
                         <th >Topic 1 : Doctor</th>
     
                         <th>Topic 2 : Nurse's care</th>

                         <th>Topic 3 : Clinic's hygiene and ambience</th>

                         <th>Topic 4 : Clinic's pharmacy supplies and equipment</th>

                         <th >Topic 5 : Website </th>

                         <th>Topic 6 : General opinion </th>
                 </thead>
                     <tbody>
                          <tr>    
                            <td v-for="s in statistics">{{s}}/5</td>
                         </tr>                      
                     </tbody>
                </table>
        </div>
        <br></br>
        <br></br>
        <br></br>

        <div class="container">
            <br/><h3 class="text">Comments</h3><br/>
	        <ul class="nav nav-tabs" role="tablist">
    	        <li class="nav-item">
    		        <a class="nav-link active" data-toggle="tab" href="#approved">Approved</a>
    	        </li>
    	        <li class="nav-item">
    		        <a class="nav-link" data-toggle="tab" href="#disapproved">Disapproved</a>
    	        </li>
            </ul>
            <div>
                <div class="tab-content">
    	            <div id="approved" class="container tab-pane active"><br>
    		            <div class="container">
	                            <div class="row">
                                    <table class="table table-bordered">
                                        <thead>
                                          <tr>
                                            <th>Comment</th>
                                            <th>Date</th>
                                            <th colspan="2">Patient</th>
                                          </tr>
                                        </thead>
                                        <tbody>
                                          <tr v-for="f in approvedFeedbacks">
                                            <td>{{f.text}}</td>
                                            <td>{{DateSplit(f.date)}}</td>
                                            <td v-for="p in patients" v-if="parseInt(p.id) == parseInt(f.patientId)">{{p.name}} {{p.surname}}</td>
                                            <td v-if="parseInt(f.patientId) == -1">Anonimous</td>
                                            <td style="text-align:center"><button class="btnban form-control" v-on:click="Disapprove(f)">D I S A P P R O V E</button></td>  
                                          </tr>
                                        </tbody>
                                     </table>
	                            </div>
                          </div>			     
		             </div>
		            <div id="disapproved" class="container tab-pane fade"><br>
                        <div class="container">
                            <div class="row">
                                <table class="table table-bordered">
                                    <thead>
                                        <tr>
                                            <th>Comment</th>
                                            <th>Date</th>
                                            <th colspan="2">Patient</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr v-for="f in disapprovedFeedbacks">
                                            <td>{{f.text}}</td>
                                            <td>{{DateSplit(f.date)}}</td>
                                            <td v-for="p in patients" v-if="parseInt(p.id)== parseInt(f.patientId)">{{p.name}} {{p.surname}}</td>
                                            <td v-if="parseInt(f.patientId) == -1">Anonimous</td>
                                            <td style="text-align:center"><button class="btnapprove form-control" v-on:click="Approve(f)">A P P R O V E</button></td>
                                        </tr>
                                     </tbody>
                                 </table> 
                            </div>
                        </div>			
                    </div>
                </div>
            </div>
        </div>
    </div>
	`,
    methods: {
        DateSplit: function (date) {
            var dates = (date.split("T")[0]).split("-")
            return dates[2] + "." + dates[1] + "." + dates[0]
        },
        getStatistics: function () {
            axios
                .get('http://localhost:49900/survey/getStatisticsForDoctor', { params: { doctorId: "Nikola Nikolic"} })
                .then(response => {
                    this.statistics = response.data;
                })

        },
        Approve: function (feedback) {
            axios
                .put('http://localhost:49900/feedback/approve', feedback)
                .then(response => {
                    this.Refresh();
                })
                .catch(error => {
                    alert(error)
                })

        },
        Disapprove: function (feedback) {
            axios
                .put('http://localhost:49900/feedback/approve', feedback)
                .then(response => {
                    this.Refresh();
                })
                .catch(error => {
                    alert(error)
                })
        },
        Refresh: function () {
            axios
                .get('http://localhost:49900/feedback/approved')
                .then(response => {
                    this.approvedFeedbacks = response.data
                })
                .catch(error => {
                    alert(error)
                })

            axios
                .get('http://localhost:49900/feedback/disapproved')
                .then(response => {
                    this.disapprovedFeedbacks = response.data
                })
                .catch(error => {
                    alert(error)
                })
        }
    }
});