Vue.component("admin", {
    data: function () {
        return {
            surveyText: null,
            doctorId: null,
            statistics: [],
            doctorList: [],
            doctorsList: [],
            maliciousPatients: []
        }
    },
    beforeMount() {
        axios
            .get('/patient/getMaliciousPatients')
            .then(response => {
                this.maliciousPatients = response.data
            })
            .catch(error => {
                alert(error)
            })

        axios
            .get('/survey/getDoctors', { params: { patientId: "001" } })
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
        <!--ICONS-->
            <div>
              <div class="row">
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="ShowStatistics" type="button" class="btn btn-info btn-lg margin form-control" v-on:click="StatisticsShow()"></button>
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
			        <button id="FeedbacksControl" type="button" class="btn btn-info btn-lg margin form-control" v-on:click="FeedbacksShow()"></button>
			        </h3><br/> 
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="Search" type="button" class="btn btn-info btn-lg margin form-control" v-on:click="SearchShow()"></button>
			        </h3><br/> 
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
        <br></br>
        <br></br>
        <br></br>
        <br></br>

    </div>
	`,
    methods: {
        getStatisticsEachQuestion: function () {
            axios
                .get('/survey/getStatistiEachQuestion')
                .then(response => {
                    this.statisticEachQuestion = response.data;
                })

        },
        BlockMaliciousPatient: function (MaliciousPatient) {
            axios
                .put('/patient/blockMaliciousPatient', MaliciousPatient)
                .then(response => {
                    axios
                        .get('/patient/getMaliciousPatients')
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
        StatisticsShow: function () {
            this.$router.push('statistics');
        },
        SearchShow: function () {
            this.$router.push('search');
        },
        FeedbacksShow: function () {
            this.$router.push('feedbackAdmin');
        }
    }


});