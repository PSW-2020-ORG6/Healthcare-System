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
            doctorsList: [],
            maliciousPatients: [],

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
            .get('http://localhost:49900/patient/getMaliciousPatients')
            .then(response => {
                this.maliciousPatients = response.data
            })
            .catch(error => {
                alert(error)
            })

        axios
            .get('http://localhost:49900/survey/getDoctors', { params: { patientId: "001" } })
            .then(response => {
                this.doctorsList = response.data;


            })
            .catch(error => {
                alert(error)
            })





    },
    template: `
    <div id = "AdminMain">

        <br></br>
        <br></br>
        <br></br>
        <br></br>
        <br></br>
        <!--ICONS-->
            <div>
              <div class="row">
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="ShowStatistics" type="button" class="btn btn-info btn-lg margin form-control" data-toggle="modal" v-on:click="StatisticsShow()"></button>
			        </h3><br/> 
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="MaliciousUsers" type="button" class="btn btn-info btn-lg margin form-control" data-toggle="modal" data-target="#MaliciousUsersModal"></button>
			        </h3><br/> 
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="FeedbacksControl" type="button" class="btn btn-info btn-lg margin form-control" data-toggle="modal" data-target="#FeedbacksModal"></button>
			        </h3><br/> 
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>  
                <div class="col-sm">
                </div>
              </div>
            </div>

        <br></br>
        <br></br>

        <!--MALICIOUS USERS MODAL-->
            <div class="modal fade" id="MaliciousUsersModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalScrollableTitle" aria-hidden="true">
			  <div class="modal-dialog modal-dialog-scrollable" role="document">
				<div class="modal-content">
				  <div class="modal-header textAndBackground">
					<h5 class="modal-title" id="exampleModalScrollableTitle">Malicious Users</h5>
					<button type="button" class="close" data-dismiss="modal" aria-label="Close">
					  <span aria-hidden="true">&times;</span>
					</button>
				  </div>
				  <div class="modal-body">		
                       <div class="tab-content">
    	                    <div id="approved" class="container tab-pane active"><br>
    		                    <div class="container">
	                                    <div class="row">
                                            <table class="table table-bordered">
                                                <thead>
                                                  <tr>
                                                    <th>Patient</th>
                                                    <th colspan="2"></th>
                                                  </tr>
                                                </thead>
                                                <tbody>
                                                  <tr v-for="mp in maliciousPatients">
                                                    <td >{{mp.name}} {{mp.surname}}</td>
                                                    <td style="text-align:center"><button class="btnban form-control" v-on:click="BlockMaliciousPatient(mp)">B L O C K</button></td>  
                                                  </tr>
                                                </tbody>
                                             </table>
	                                    </div>
                                  </div>			     
		                     </div>
                    </div>
				  </div>
				  <div class="modal-footer textAndBackground">
					<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
				  </div>
				</div>
			  </div>
			</div>

        <!--FEEDBACKS MODAL-->
            <div class="modal fade" id="FeedbacksModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalScrollableTitle" aria-hidden="true">
			  <div class="modal-dialog modal-dialog-scrollable modal-xl" role="document">
				<div class="modal-content">
				  <div class="modal-header textAndBackground">
					<h5 class="modal-title" id="exampleModalScrollableTitle">Feedback Control</h5>
					<button type="button" class="close" data-dismiss="modal" aria-label="Close">
					  <span aria-hidden="true">&times;</span>
					</button>
				  </div>
				  <div class="modal-body">		
                                <br/><h3 class="text">Comments</h3><br/>
	                            <ul class="nav nav-tabs" role="tablist">
    	                            <li class="nav-item">
    		                            <a class="nav-link active .cards" data-toggle="tab" href="#approvedF">Approved</a>
    	                            </li>
    	                            <li class="nav-item">
    		                            <a class="nav-link .cards" data-toggle="tab" href="#disapprovedF">Disapproved</a>
    	                            </li>
                                </ul>
                                <div>
                                    <div class="tab-content">
    	                                <div id="approvedF" class="container tab-pane active"><br>
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
		                                <div id="disapprovedF" class="container tab-pane fade"><br>
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
				  <div class="modal-footer textAndBackground">
					<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
				  </div>
				</div>
			  </div>
			</div>
    
        <br></br>
        <br></br>
        <br></br>
        <br></br>

    </div>
	`,
    methods: {
        DateSplit: function (date) {
            var dates = (date.split("T")[0]).split("-")
            return dates[2] + "." + dates[1] + "." + dates[0]
        },
        getStatisticsEachQuestion: function () {
            axios
                .get('http://localhost:49900/survey/getStatistiEachQuestion')
                .then(response => {
                    this.statisticEachQuestion = response.data;
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
        BlockMaliciousPatient: function (MaliciousPatient) {
            axios
                .put('http://localhost:49900/patient/blockMaliciousPatient', MaliciousPatient)
                .then(response => {
                    axios
                        .get('http://localhost:49900/patient/getMaliciousPatients')
                        .then(response => {
                            this.maliciousPatients = response.data
                        })
                        .catch(error => {
                            alert(error)
                        })
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
        },
        StatisticsShow: function () {
            this.$router.push('statistics');
        }

    }


});

