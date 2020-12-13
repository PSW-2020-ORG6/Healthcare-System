Vue.component("appointments", {
	data: function () {
		return {
			idPatient: "0002",
			activeAppointments: null,
			canceledAppointments: null,
			pastAppointments: null,
			patients: null,
			doctorsList: null,
			appointment: null,
			sucessFlag: {},
			patientDTO: {}
		}
	},
	beforeMount() {
		axios
			.get('http://localhost:49900/appointment/allAppointmentsByPatientIdActive', { params: { patientId: "0002" } })
			.then(response => {
				this.activeAppointments = response.data
			})

			.catch(error => {
				alert("greska kod activeAppoiuntments")

			})

		axios
			.get('http://localhost:49900/appointment/allAppointmentsByPatientIdCanceled', { params: { patientId: "0002" } })
			.then(response => {
				this.canceledAppointments = response.data

			})
			.catch(error => {
				alert("greska kod canceledAppointments")
			})

		axios
			.get('http://localhost:49900/appointment/allAppointmentsByPatientIdPast', { params: { patientId: "0002" } })
			.then(response => {
				this.pastAppointments = response.data

			})
			.catch(error => {
				alert("greska kod canceledAppointments")
			})
	},
	template: `
	<div>


		<div class="container"><br/>
			
			<p>Active Appointments<p>
			<div>
				<div class="tab-content">
    				<div id="profil" class="container tab-pane active"><br>
    					<div class="container">
							<div class="row">
								<table class="table table-bordered">
									<thead	>
										<tr>
											<th>Date</th>
											<th>Time</th>
											<th>Physitian</th>
											<th>Room</th>
											<th>Procedure</th>
											<th>Urgency</th>
											<th></th>
										</tr>
									</thead>
									<tbody>
										<tr v-for="a in activeAppointments">
											<td>{{DateSplit(a.date)}}</td>
											<td>{{a.timeInterval.time}}</td>
											<td>{{a.physitian.fullName}}</td>
											<td>{{a.room.name}}</td>
											<td>{{a.procedureType.name}}</td>
											<td>{{a.urgency}}</td>
											<td><button type="button" class="btn btn-info btn-lg" v-on:click="cancelAppointment(a)">Cancel</button></td>	
										</tr>
									</tbody>
								</table>
							</div>
						</div>		
					</div>
				</div>
			</div>
		<br></br>
		<p>Canceled Appointments</p>
			<div>
				<div class="tab-content">
    				<div id="profil" class="container tab-pane active"><br>
    					<div class="container">
							<div class="row">
								<table class="table table-bordered">
									<thead>
										<tr>
											<th>Date</th>
											<th>Time</th>
											<th>Physitian</th>
											<th>Room</th>
											<th>Procedure</th>
											<th>Urgency</th>	
										</tr>
									</thead>
									<tbody>
										<tr v-for="a in canceledAppointments">
											<td>{{DateSplit(a.date)}}</td>
											<td>{{a.timeInterval.time}}</td>
											<td>{{a.physitian.fullName}}</td>
											<td>{{a.room.name}}</td>
											<td>{{a.procedureType.name}}</td>
											<td>{{a.urgency}}</td>	
										</tr>
									</tbody>
								</table>
							</div>
						</div>		
					</div>
				</div>
			</div>
			<br></br>

		<p>Past Appointments</p>
			<div>
				<div class="tab-content">
    				<div id="profil" class="container tab-pane active"><br>
    					<div class="container">
							<div class="row">
								<table class="table table-bordered">
									<thead>
										<tr>
											<th>Date</th>
											<th>Time</th>
											<th>Physitian</th>
											<th>Room</th>
											<th>Procedure</th>
											<th>Urgency</th>
											<th></th>
										</tr>
									</thead>
									<tbody>
										<tr v-for="a in pastAppointments">
											<td>{{DateSplit(a.date)}}</td>
											<td>{{a.timeInterval.time}}</td>
											<td>{{a.physitian.fullName}}</td>
											<td>{{a.room.name}}</td>
											<td>{{a.procedureType.name}}</td>
											<td>{{a.urgency}}</td>		
											<td><button type="button" class="btn btn-info btn-lg" v-on:click="SurveyShow()"">Survey</button></td>												
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
				this.feedback.patientId = "0002"
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
		cancelAppointment: function (appointment) {
			axios

				.put("http://localhost:49900/appointment/cancelAppointment", appointment)
				.then(response => {
					axios
						.get('http://localhost:49900/appointment/allAppointmentsByPatientIdActive', { params: { patientId: "0002" } })
						.then(response => {
							this.activeAppointments = response.data
						})

						.catch(error => {
							alert("greska kod activeAppoiuntments")

						})

					axios
						.get('http://localhost:49900/appointment/allAppointmentsByPatientIdCanceled', { params: { patientId: "0002" } })
						.then(response => {
							this.canceledAppointments = response.data

						})
						.catch(error => {
							alert("greska kod canceledAppointments")
						})
				})
		},
		DateSplit: function (date) {
			var dates = (date.split("T")[0]).split("-")
			return dates[2] + "." + dates[1] + "." + dates[0]
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