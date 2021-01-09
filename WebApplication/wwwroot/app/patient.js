Vue.component("patient", {
	data: function () {
		return {
			patientDTO: null,
			idPatient: null,
			activeAppointments: null,
			canceledAppointments: null,
			patients: null,
			doctorsList: null,
			appointment: null,
			actionsAndBenefits:null
		}
	},
	beforeMount() {
		axios
			.get('/patient/getActionsAndBenefits', {
				params: { token: localStorage.getItem('token') },
				headers: {
					'Authorization': 'Bearer' + " " + localStorage.getItem('token')
				}
			})
			.then(response => {
				this.actionsAndBenefits = response.data
			})
			.catch(error => {
			})
	},
	template: `
	<div id="Patient">
	
			<br></br>
	<!-- Advertisements -->
		<div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
			 <div class="carousel-inner">
				<div class="carousel-item active" style="height:330px;">
					</br></br></br></br></br>
					<h1> Our health is in our hands!</h1></br>
					</br></br>
				</div>
				<div class="carousel-item" v-for="ac in actionsAndBenefits" style="height:330px;">
					</br>
					 <h2>{{ac.pharmacyName}}</h2></br>
					<h3 class="cc">{{ac.text}}</h3>
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
			<br></br>
			<br></br>
			<!--ICONS ROW 1-->
				<div>
				  <div class="row">
					<div class="col-sm">
					</div>
					<div class="col-sm">
					  <h3>
						<button id="MyInformations" type="button" class="btn btn-info btn-lg margin form-control" data-toggle="modal" v-on:click="AccountInfoShow()"></button>
						</h3><br/> 
					</div>
					<div class="col-sm">
					</div>
					<div class="col-sm">
					  <h3>
						<button id="UserExperiences" type="button" class="btn btn-info btn-lg margin form-control" v-on:click="FeedbackShow()"></button>
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
				  </div>
			</div>
	<br></br>
	<br></br>
		</div>
	</div>

	`,
	methods: {
		AddNewFeedback: function (feedback) {
			if (!document.getElementById("anonimous").checked)
				this.feedback.patientId = this.idPatient
			else
				this.feedback.id = "-1"
			if (feedback.text.localeCompare(null) || feedback.text.localeCompare("")) {
				axios
					.post("/feedback/add", feedback)
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
				.get('/survey/getDoctorsForSurveyList', { params: { patientId: this.idPatient } , 
					headers: {
						'Authorization': 'Bearer' + " " + localStorage.getItem('token')
					}
				})
				.then(response => {
					this.doctorsList = response.data
					if (this.doctorsList.value != null || this.doctorsList != "") {
						this.$router.push('survey');
					} else {
						alert("You have already completed the survey for all available doctors")
					}
				})
				.catch(error => {
				})
		},
		FeedbackShow: function () {
			this.$router.push('feedbackPatient');
		},
		AccountInfoShow: function () {
			this.$router.push('account');
		}
	}
});