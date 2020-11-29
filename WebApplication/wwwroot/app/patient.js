Vue.component("patient", {
	data: function () {
		return {
			idPatient:"12",
			approvedFeedbacks: null,
			noapprovedFeedbacks: null,
			patients: null,
			doctorsList: null,
			feedback: {
				text: "",
				approved: false,
				date: new Date().now,
				patientId: "-1"
			},
			patientDTO: {}
		}
	},
	beforeMount() {
		axios
			.get('http://localhost:49900/patient/getPatientById', { params: { patientId: "1111" } })
			.then(response => {
				this.patientDTO = response.data
			})
			.catch(error => {
				alert("Please add patient with id number : 12345")
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
	},
	template: `
	<div>

<!-- Registration Info -->

		<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#registrationInfo">
			  My Informations
			</button>

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

						

				  </div>
				  <div class="modal-footer textAndBackground">
					<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
				  </div>
				</div>
			  </div>
			</div>

	
	<!--END registration info modal-->

		<div>
			<div class="modal fade" tabindex="-1" role="dialog" id="feedbackModal">
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
		<div class="container"><br/>
			<h3 class="text">Comments
				<button type="button" class="btn btn-info btn-lg margin" data-toggle="modal" data-target="#feedbackModal">Add comment</button>
			</h3><br/>
			<h3 class="textSurvey">Survey
				<button type="button" class="btn btn-info btn-lg margin" data-toggle="modal" v-on:click="SurveyShow()"">Take survey</button>
			</h3><br/> 
			<div>
				<div class="tab-content">
    				<div id="profil" class="container tab-pane active"><br>
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
		AddNewFeedback: function (feedback) {
			if (!document.getElementById("anonimous").checked)
				this.feedback.patientId="0003"
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
		SurveyShow: function () {
			axios
				.get('http://localhost:49900/survey/getDoctorsForSurveyList', { params: { patientId: this.idPatient} })
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