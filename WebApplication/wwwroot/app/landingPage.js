﻿Vue.component("landing", {
		data: function () {
		return {
			approvedFeedbacks: null,
			patients: null,
		}
	},
	beforeMount() {
		localStorage.setItem('token', null)
		localStorage.setItem('isLogged', false)
		localStorage.setItem('isAdmin', false)
		localStorage.setItem('isPatient', false)

			axios
				.get('/feedback/approved')
				.then(response => {
					this.approvedFeedbacks = response.data
				})
				.catch(error => {
				})
		axios
			.get('/patient/all', {
				params: { token: localStorage.getItem('token')}
			})
			.then(response => {
				this.patients = response.data
			})
			.catch(error => {
			})
	},
	template: `
	<div id="Landing"></br>
			<a class="text2" style="color:white;font-style:italic">
            Welcome to HealthClinic
            <img src="pictures/logInverted.png" id="clinicLogoPicLP">
			<br>
			Always Caring. Always Here.
			<br></br>
			Wherever the art of Medicine is loved, there is also a love of Humanity.</br> ~Hippocrates
			</a>

	<br><br><br><br><br><br><br><br>
	<div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
	  <div class="carousel-inner">
		<div id="slideLandingPage" class="carousel-item active">
		  		<div style="font-size:34px"><i>What our patients think of us?</i></div>
				<div style="font-size:28px"></div>
		</div>
		<div id="slideLandingPage" class="carousel-item " v-for="a in approvedFeedbacks">
				<div v-for="p in patients">
					<div  v-if="parseInt(a.patientId) != -1 && parseInt(p.id) == parseInt(a.patientId)">
							<div><i>{{p.name}} {{p.surname}} - {{DateSplit(a.date)}}</i></div>
							<div style="font-size:34px"><i>{{a.text}}</i></div>
					  </div>
				</div>
					<div  v-if="parseInt(a.patientId) == -1">
							<div><i>Annonimous - {{DateSplit(a.date)}}</i></div>
							<div  style="font-size:34px"><i>{{a.text}}<i></div>
			  </div>
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
	</div>
</div>

	`,	methods: {
		DateSplit: function (date) {
			var dates = (date.split("T")[0]).split("-")
			return dates[2] + "." + dates[1] + "." + dates[0]
		}
	}
});

