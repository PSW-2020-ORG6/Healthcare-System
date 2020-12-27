Vue.component("patient", {
	data: function () {
		return {
			patientDTO: null,
			idPatient: "96736fd7-3018-4f3f-a14b-35610a1c8959",
			approvedFeedbacks: null,
			noapprovedFeedbacks: null,
			activeAppointments: null,
			canceledAppointments: null,
			patients: null,
			doctorsList: null,
			feedback: {
				text: "",
				approved: false,
				date: new Date().now,
				patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959"
			},
			appointment: null			
		}
	},
	beforeMount() {
		axios
			.get('http://localhost:49900/patient/getPatientById', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
			.then(response => {
				this.patientDTO = response.data
			})
			.catch(error => {
				alert("Please add patient with id number : 96736fd7-3018-4f3f-a14b-35610a1c8959")
			})

		axios
			.get('http://localhost:49900/feedback/approved')
			.then(response => {
				this.approvedFeedbacks = response.data
			})
			.catch(error => {
				alert(error.response.data)
			})
		axios
			.get('http://localhost:49900/patient/all')
			.then(response => {
				this.patients = response.data
			})
			.catch(error => {
				alert(error.response.data)
			})

		axios
			.get('http://localhost:49900/appointment/allAppointmentsByPatientIdActive', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
			.then(response => {
				this.activeAppointments = response.data
			})

			.catch(error => {
				alert("greska kod activeAppoiuntments")
			})

		axios
			.get('http://localhost:49900/appointment/allAppointmentsByPatientIdCanceled', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
			.then(response => {
				this.canceledAppointments = response.data
			})
			.catch(error => {
				alert("greska kod canceledAppointments")
			})
	},
	template: `
	<div id="Patient">
	
        <br></br>
<!-- Advertisements -->
    <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
      <div class="carousel-inner">
        <div class="carousel-item active" style="height:330px;">
            </br>
            <h3> Vitamin D3 1000 IU</h3></br>
            Vitamin D3 1000 IU doprinosi normalnoj funkciji imunog sistema,</br> koštano-mišićnog sistema, smanjenju gubitka koštane mase kod žena u post-menopauzalnom periodu.</br>
            Podrška imunom sistemu, kao i kod stanja kao što su osteopenija, osteoporoza, autoimuna, kardiovaskularna i maligna oboljenja.
        </br></br>
        </div>
        <div class="carousel-item" v-for="it in [0,1]" style="height:330px;">
            </br>
            <h3>Oligovit Complex Galenika</h3></br>
            Oligovit dražeje se primenjuju:</br>
        - Kao dodatak ishrani u stanjima neadekvatne ishrane (u toku dijete, gladovanja)</br>
        - Kao dopuna u vitaminima i mineralima u toku trudnoće i dojenja</br>
        - Kod premorenosti posle teškog fizičkog napora</br>
        - U stanjima oporavka posle: bolesti praćenih visokim temperaturama, hirurških zahvata</br>
        - Kod zaostajanja u rastenju, nedostatka apetita, gubitka u telesnoj masi</br>
        - Kod deficita nastalog zbog gastrointestinalnih i hepatobilijarnih bolesti</br>
        - Kod patoloških stanja (hipertireoidizam, stres itd.) u kojima su povećane potrebe za vitaminima i mineralima.
        </br></br>
        </div>
      </div>
      <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
      </a>
      <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
      </a>
    </div></br>
        <br></br>
        <!--ICONS ROW 1-->
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
			        <button id="MyInformations" type="button" class="btn btn-info btn-lg margin form-control" data-toggle="modal" data-target="#registrationInfo"></button>
			        </h3><br/> 
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="LeaveComment" type="button" class="btn btn-info btn-lg margin form-control" data-toggle="modal" data-target="#CommentModal"></button>
			        </h3><br/> 
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="UserExperiences" type="button" class="btn btn-info btn-lg margin form-control" data-toggle="modal" data-target="#FeedbacksModal"></button>
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
<br></br>
<br></br>
	<!--ICONS ROW 2-->
			<div class="row">
                <div class="col-sm">
                </div>
                <div class="col-sm">
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
                  <h3>
			        <button id="AppointmentsShow" type="button" class="btn btn-info btn-lg margin form-control" v-on:click="AppointmentsShow()"></button>
			        </h3><br/> 
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="SurveyShow" type="button" class="btn btn-info btn-lg margin form-control" v-on:click="SurveyShow()"></button>
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
</br>

<!-- Registration Info -->

			<div class="modal fade" id="registrationInfo" tabindex="-1" role="dialog" aria-labelledby="exampleModalScrollableTitle" aria-hidden="true">
			  <div class="modal-dialog modal-dialog-scrollable" role="document">
				<div class="modal-content">
				  <div class="modal-header textAndBackground">
					<h5 class="modal-title" id="exampleModalScrollableTitle">User info</h5>
					<button type="button" class="close" data-dismiss="modal" aria-label="Close">
					  <span aria-hidden="true">&times;</span>
					</button>
				  </div>
				  <div class="modal-body">
							<td><img  :src = "patientDTO.image" class = "form-control inputImage" style = "display:flex" width="100" heigh="50" /></td>
							<div class="input-group-prepend">
								<td>&nbsp;</td>
							</div>
							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Name</span>
							  </div>
							  <input type="text"  v-model="patientDTO.name" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Surname</span>
							  </div>
							  <input type="text"  v-model="patientDTO.surname" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">UCIN</span>
							  </div>
							  <input type="text"  v-model="patientDTO.id" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Date of Birth</span>
							  </div>
							  <input type="text"  v-model="patientDTO.dateOfBirth" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Place of birth</span>
							  </div>
							  <input type="text"  v-model="patientDTO.placeOfBirth" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Municipality of birth</span>
							  </div>
							  <input type="text"  v-model="patientDTO.municipalityOfBirth" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">State of birth</span>
							  </div>
							  <input type="text"  v-model="patientDTO.stateOfBirth" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Nationality</span>
							  </div>
							  <input type="text"  v-model="patientDTO.nationality" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Citizenship</span>
							  </div>
							  <input type="text"  v-model="patientDTO.citizenship" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend ">
								<span class="input-group-text width" id="basic-addon3">Address</span>
							  </div>
							  <input type="text"  v-model="patientDTO.address.street" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Place of residence</span>
							  </div>
							  <input type="text"  v-model="patientDTO.placeOfResidence" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Municipality of residence</span>
							  </div>
							  <input type="text"  v-model="patientDTO.municipalityOfResidence" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">State of residence</span>
							  </div>
							  <input type="text"  v-model="patientDTO.stateOfResidence" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Profesion</span>
							  </div>
							  <input type="text"  v-model="patientDTO.profession" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Employment status</span>
							  </div>
							  <input type="text"  v-model="patientDTO.employmentStatus" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Marital status</span>
							  </div>
							  <input type="text"  v-model="patientDTO.maritalStatus" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Contact number</span>
							  </div>
							  <input type="text"  v-model="patientDTO.contact" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Email</span>
							  </div>
							  <input type="text"  v-model="patientDTO.email" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Gender</span>
							  </div>
							  <input type="text"  v-model="patientDTO.gender" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Health insurance number</span>
							  </div>
							  <input type="text"  v-model="patientDTO.healthInsuranceNumber" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Family diseases</span>
							  </div>
							  <input type="text"  v-model="patientDTO.familyDiseases" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Personal diseases</span>
							  </div>
							  <input type="text"  v-model="patientDTO.personalDiseases" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Chosen doctor</span>
							  </div>
							  <input type="text"  v-model="patientDTO.chosenDoctor" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

				  </div>
				  <div class="modal-footer textAndBackground">
					<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
				  </div>
				</div>
			  </div>
			</div>

	
	<!--END registration info modal-->

	<!-- Leave Comment -->
		<div>
			<div class="modal fade" tabindex="-1" role="dialog" id="CommentModal">
				<div class="modal-dialog" role="document">
					<div class="modal-content">
						<div class="modal-header" id="feedbackModalHeader">
							<h5 class="modal-title">Leave a comment</h5>
							<button type="button" class="close" data-dismiss="modal" aria-label="Close">
								<span aria-hidden="true">&times;</span>
							</button>
						</div>
						<div class="modal-body" id="feedbackModalBody">
							<label>Enter your comment here:</label>
							<textarea class="form-control" v-model="feedback.text" rows="4" cols="50"></textarea>
							<br/><br/>
							<input type="checkbox" id="anonimous">	
							<label> Anonimous</label><br>
						</div>
						<div class="modal-footer" id="feedbackModalFooter">
							<button type="button" class="btn btn-info btn-lg " v-on:click="AddNewFeedback(feedback)">Send</button>
							<button type="button" class="btn btn-info btn-lg " data-dismiss="modal">Cancel</button>
						</div>
					</div>
				</div>
			</div>  
		</div>
<!--END Leave Comment -->

<!--User feedbacks -->
		<div>
			<div class="modal fade" tabindex="-1" role="dialog" id="FeedbacksModal">
				<div class="modal-dialog  modal-xl" role="document">
					<div class="modal-content">
						<div class="modal-header" id="feedbackModalHeader">
							<h5 class="modal-title">User experiences</h5>
							<button type="button" class="close" data-dismiss="modal" aria-label="Close">
								<span aria-hidden="true">&times;</span>
							</button>
						</div>
						<div class="modal-body" id="feedbackModalBody">
								<div class="tab-content" >
											<div class="row" >
												<table class="table table-bordered tableBorder" style="width:500px;height:400px" Align = "center" id="UserExp">
													<tbody>
														<tr v-for="a in approvedFeedbacks" class="xx">
															<template v-for="p in patients">
															<td v-if="parseInt(a.patientId) != -1 && parseInt(p.id) == parseInt(a.patientId)">{{p.name}} {{p.surname}}
															&nbsp&nbsp&nbsp&nbsp {{DateSplit(a.date)}}</br></br>
															{{a.text}}</td>
															</template>
															<td v-if="parseInt(a.patientId) == -1">Anonimous
															<!--<template v-if="parseInt(a.patientId) == -1">Anonimous</template>-->
												&nbsp&nbsp&nbsp&nbsp {{DateSplit(a.date)}}</br></br>
											{{a.text}}</td>
                                        </tr>
									</tbody>
								</table>	
									</div>
								</div>
							</div>
						</div>
						<div class="modal-footer" id="feedbackModalFooter">
							<button type="button" class="btn btn-info btn-lg " data-dismiss="modal">Cancel</button>
						</div>
					</div>
				</div>
			</div>  
		</div>
<!--END User comments -->

	</div>

	`,
	methods: {
		AddNewFeedback: function (feedback) {
			if (!document.getElementById("anonimous").checked)
				this.feedback.patientId = "0003"
			else
				this.feedback.id = "-1"
			if (feedback.text.localeCompare(null) || feedback.text.localeCompare("")) {
				axios
					.post("http://localhost:49900/feedback/add", feedback)
					.then(response => {
						this.feedback.text = null;
						$('#feedbackModal').modal('hide')
					})
					.catch(error => {
						alert("You need to enter a comment first.");
					})
			}
			else
				alert("You need to enter a comment first.");
		},
		DateSplit: function (date) {
			var dates = (date.split("T")[0]).split("-")
			return dates[2] + "." + dates[1] + "." + dates[0]
		},
		SearchShow: function () {
			this.$router.push('search');
		},
		AppointmentsShow: function () {
			this.$router.push('appointments');
		},
		SurveyShow: function () {
			axios
				.get('http://localhost:49900/survey/getDoctorsForSurveyList', { params: { patientId: this.idPatient } })
				.then(response => {
					this.doctorsList = response.data
					if (this.doctorsList.value != null || this.doctorsList != "") {
						this.$router.push('survey');
					} else {
						alert("You have already completed the survey for all available doctors")
					}
				})
				.catch(error => {
					alert(error)
				})

		}
	}
});